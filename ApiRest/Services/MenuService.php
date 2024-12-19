<?php
    require_once($ProjectPath.'/Database/conexion.php');
    require_once(__DIR__.'/Actions.php');

    class MenuService extends Actions{

        public function __construct(){
            $dataBase = new Connection();
            //Las columnas son solo para los methodos get osease los select que traen la info de la base de datos
            parent::__construct('menu','id,MenuName,MenuOrder,Path,IconName, ClassName, Path',$dataBase->getConnection());
        }

        public function getMenuByRol($idRol){
            $stm = $this->DbConection->prepare(" SELECT c.id, 
                                                        c.MenuName,
                                                        c.ClassName,
                                                        c.Path,
                                                        c.MenuOrder,
                                                        c.IconName
                                                   FROM rol_menu as a
                                             INNER JOIN rol AS b ON a.id_Rol = b.id
                                             INNER JOIN menu AS c ON a.id_Menu = c.id
                                                  WHERE a.id_Rol = $idRol
                                               ORDER BY c.MenuOrder;");
            $stm->execute();
            return $stm->fetchAll(PDO::FETCH_ASSOC);
        }

        function newMenuToRol($idRol,$MenuList){
            $x =0;
            $query = "";

            foreach($MenuList as $_menu){
                $query .= "insert into rol_menu (id_Rol,id_Menu) value (:idRol{$x},:idMenu{$x});";
                $x += 1;
            }

            $x = 0;
            $stm =  $this-> DbConection->prepare($query);

            foreach($MenuList as $_menu){
                $stm->bindValue(":idRol{$x}", $idRol, PDO::PARAM_INT);
                $stm->bindValue(":idMenu{$x}", $_menu["id"], PDO::PARAM_INT);
                $x +=1;
            }
            $stm->execute();
        }

        function updateMenusForRol($idRole, $newMenuList){
            $this->DbConection->beginTransaction();

             // Obtener los menús actualmente asociados al rol
            $query = "SELECT id_Menu FROM rol_menu WHERE id_Rol = :id_Rol";
            $stm = $this->DbConection->prepare($query);
            $stm->bindValue(':id_Rol', $idRole, PDO::PARAM_INT);
            $stm->execute();
            $currentMenuList = $stm->fetchAll(PDO::FETCH_COLUMN); 

            // Determinar las relaciones a mantener, agregar y eliminar
            $menusToAdd = array_diff($newMenuList, $currentMenuList);       // Menús nuevos
            $menusToRemove = array_diff($currentMenuList, $newMenuList);   // Menús a eliminar
            
            //Eliminar las relacciones que ya no existen
            if (!empty($menusToRemove)) {
                $deleteQuery = "DELETE FROM rol_menu WHERE id_Rol = :id_Rol AND id_Menu = :id_Menu";
                $stm = $this->DbConection->prepare($deleteQuery);
                foreach ($menusToRemove as $menuId) {
                    $stm->bindValue(':id_Rol', $idRole, PDO::PARAM_INT);
                    $stm->bindValue(':id_Menu', $menuId, PDO::PARAM_INT);
                    $stm->execute();
                }
            }

            // Agregar nuevas relaciones
            if (!empty($menusToAdd)) {
                $insertQuery = "INSERT INTO rol_menu (id_Rol, id_Menu) VALUES (:id_Rol, :id_Menu)";
                $stm = $this->DbConection->prepare($insertQuery);
                foreach ($menusToAdd as $menuId) {
                    $stm->bindValue(':id_Rol', $idRole, PDO::PARAM_INT);
                    $stm->bindValue(':id_Menu', $menuId, PDO::PARAM_INT);
                    $stm->execute();
                    
                }
            }

            $this->DbConection->commit();

        }

    }

?>
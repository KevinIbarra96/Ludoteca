<?php
    require_once($ProjectPath.'/Database/conexion.php');
    require_once(__DIR__.'/Actions.php');

    class MenuService extends Actions{

        public function __construct(){
            $dataBase = new Connection();
            //Las columnas son solo para los methodos get osease los select que traen la info de la base de datos
            parent::__construct('menu','MenuName, Rol, Path',$dataBase->getConnection());
        }

        public function getMenuByRol($idRol){
            $stm = $this->DbConection->prepare(" select c.id, 
                                                        c.MenuName,
                                                        c.ClassName,
                                                        c.Path,
                                                        c.MenuOrder,
                                                        C.IconName
                                                   from rol_menu as a
                                             inner join rol as b on a.id_Rol = b.id
                                             inner join menu as c on a.id_Menu = c.id
                                                  where a.id_Rol = $idRol
                                               Order by c.MenuOrder;");
            $stm->execute();
            return $stm->fetchAll(PDO::FETCH_ASSOC);
        }

    }
?>
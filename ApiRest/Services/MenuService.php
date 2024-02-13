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
            $stm = $this->DbConection->prepare("Select id, MenuName,ClassName,Path,MenuOrder from menu where status = 1 and Rol = $idRol order by MenuOrder");
            $stm->execute();
            return $stm->fetchAll(PDO::FETCH_ASSOC);
        }

    }
?>
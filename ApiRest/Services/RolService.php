<?php
    require_once($ProjectPath.'/Database/conexion.php');
    require_once(__DIR__.'/Actions.php');

    require 'MenuService.php';

    class RolService extends Actions{

        public function __construct(){
            $dataBase = new Connection();
            //Las columnas son solo para los methodos get osease los select que traen la info de la base de datos
            parent::__construct('rol','id,RolName, status',$dataBase->getConnection());
        }

        function addNewRol($DataBody){
            $MS = new MenuService();

            $stm =  $this-> DbConection->prepare("insert into rol (RolName)
                                                                   value (:RolName);");
            $stm->bindValue(':RolName', $DataBody["RolName"], PDO::PARAM_STR);
            $stm->execute();

            $query ="Select max(id) as id from rol;";
            $stm = $this->DbConection->prepare($query);
            $stm->execute();

            $RolResponse = $stm->fetchAll(PDO::FETCH_ASSOC);
            $idRol = $RolResponse[0];

            $MS->newMenuToRol($idRol["id"],$DataBody["MenuList"]);
            
            return $RolResponse;

        }


    }
?>
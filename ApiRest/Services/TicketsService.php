<?php
    require_once($ProjectPath.'/Database/conexion.php');
    require_once(__DIR__.'/Actions.php');

    class TicketsService extends Actions{

        public function __construct(){
            $dataBase = new Connection();
            parent::__construct('tickets','id, nombre, idvisita, fecha_creacion,  ruta, status',$dataBase->getConnection());
        }
        function getNewFolio(){
            $query ="Select max(id)+1 as id from tickets ";
            $stm = $this->DbConection->prepare($query);
            $stm->execute();
            return $stm->fetchAll(PDO::FETCH_ASSOC);

        }

    }
?>
<?php
        
    require_once($ProjectPath.'/Database/conexion.php');
    require_once(__DIR__.'/Actions.php');

    class ServiciosService extends Actions{


        public function __construct(){
            $dataBase = new Connection();
            //Las columnas son solo para los methodos get osease los select que traen la info de la base de datos
            parent::__construct('servicios','ServicioName, Tiempo, status',$dataBase->getConnection());
        }


    }
?>
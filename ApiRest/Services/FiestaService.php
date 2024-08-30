<?php
    require_once($ProjectPath.'/Database/conexion.php');
    require_once(__DIR__.'/Actions.php');

    class FiestaService extends Actions{

        public function __construct(){
            $dataBase = new Connection();
            //Las columnas son solo para los methodos get osease los select que traen la info de la base de datos
            parent::__construct('Fiestas','FiestaName, Description, Precio',$dataBase->getConnection());
        }
    }
?>
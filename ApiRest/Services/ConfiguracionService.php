<?php
    require_once($ProjectPath.'/Database/conexion.php');
    require_once(__DIR__.'/Actions.php');

    class ConfiguracionService extends Actions{

        public function __construct(){
            $dataBase = new Connection();
            //Las columnas son solo para los methodos get osease los select que traen la info de la base de datos
            parent::__construct('Configuracion','id, ConfigName, ConfigDescripcion, ConfigStringValue, ConfigBoolValue, ConfigIntValue, ConfigDecimalValue',$dataBase->getConnection());
        }

    }
?>
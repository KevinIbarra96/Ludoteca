<?php
    require_once(__DIR__.'/Actions.php');

    class HijoService extends Actions {
        public function __construct(PDO $Conection){
            parent::__construct('hijos','NombreHijo,Papa,Mama,FechaNac,status',$Conection);
        }
    }



?>
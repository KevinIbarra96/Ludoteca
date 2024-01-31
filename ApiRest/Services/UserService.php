<?php
    
    require_once(__DIR__.'/Actions.php');

    class UserService extends Actions{

        public function __construct(PDO $Conection){
            //Las columnas son solo para los methodos get osease los select que traen la info de la base de datos
            parent::__construct('users','UserName, Password, idRol, status',$Conection);
        }


    }
?>
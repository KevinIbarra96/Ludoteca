<?php
    
    require_once(__DIR__.'/Actions.php');

    class UserService extends Actions{

        public function __construct(PDO $Conection){
            parent::__construct('users','UserName, Password, idRol, status',$Conection);
        }

    }
?>
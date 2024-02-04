<?php
    
    require_once(__DIR__.'/Actions.php');

    class MenuService extends Actions{

        public function __construct(PDO $Conection){
            //Las columnas son solo para los methodos get osease los select que traen la info de la base de datos
            parent::__construct('menu','MenuName, Rol, Path',$Conection);
        }


    }
?>
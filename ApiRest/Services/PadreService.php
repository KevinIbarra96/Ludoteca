<?php
    
    require_once(__DIR__.'/Actions.php');

    class PadreService extends Actions{

        public function __construct(PDO $Conection){
            parent::__construct('padres','PadreName, Address, Telefeno, status',$Conection);
        }

    }
?>
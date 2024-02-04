<?php
    require_once(__DIR__.'/Actions.php');

    class ProductoService extends Actions{
        public function __construct(PDO $Connection){
            parent::__construct('productos','ProductoName,Cantidad,Precio,status',$Connection);

    }
}


?>
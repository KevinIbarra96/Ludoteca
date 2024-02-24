<?php
    
    require_once($ProjectPath.'/Database/conexion.php');
    require_once(__DIR__.'/Actions.php');

    class ProductoService extends Actions{
        public function __construct(){
            $database = new Connection();
            parent::__construct('productos','id,ProductoName,Cantidad,Precio',$database->getConnection());

    }

    function increaseCantidadProduct($id,$cantidad){
        $stm = $this->DbConection->prepare("update productos set Cantidad = $cantidad+Cantidad where id = $id");
        $stm->execute();
    }


}
?>
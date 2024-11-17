<?php
    
    require_once($ProjectPath.'/Database/conexion.php');
    require_once(__DIR__.'/Actions.php');

    class ProductoService extends Actions{
        public function __construct(){
            $database = new Connection();
            parent::__construct('productos','id,ProductoName,Cantidad,Precio',$database->getConnection());

    }

    function modificarProductoVisita($dataBody){        
        $stm = $this->DbConection->prepare("update visita_producto set precioProductoVisita = :precioProductoVisita, CantidadProductoVisita = :CantidadProductoVisita, id_Producto =:id_Producto where id_Visita=:id_Visita");
        
        $stm->bindValue(':precioProductoVisita', $dataBody["precioProducto"], PDO::PARAM_INT);
        $stm->bindValue(':CantidadProductoVisita', $dataBody["cantidadProducto"], PDO::PARAM_INT);
        $stm->bindValue(':id_Producto', $dataBody["idProducto"], PDO::PARAM_INT);
        $stm->bindValue(':id_Visita', $dataBody["idVisita"], PDO::PARAM_INT);
        
        $stm->execute();
    }

    function newVisitaProducto($idVisita,$Productos){
        $x = 0;
        $query = "";
        
        foreach($Productos as $_produc){
            $query .= "insert into visita_producto (id_Visita, 
                                                    id_Producto, 
                                                    precioProductoVisita, 
                                                    CantidadProductoVisita) 
                                                    values (:id_Visita{$x}, 
                                                            :id_Producto{$x}, 
                                                            :precioProductoVisita{$x}, 
                                                            :CantidadProductoVisita{$x});";
            $x +=1;
        }

        $x = 0;
        $stm =  $this-> DbConection->prepare($query);
        foreach($Productos as $_produc){
            $stm->bindValue(":id_Visita{$x}", $idVisita, PDO::PARAM_INT);
            $stm->bindValue(":id_Producto{$x}", $_produc["id_Producto"], PDO::PARAM_INT);
            $stm->bindValue(":precioProductoVisita{$x}", $_produc["precioProductoVisita"], PDO::PARAM_INT);
            $stm->bindValue(":CantidadProductoVisita{$x}", $_produc["CantidadProductoVisita"], PDO::PARAM_INT);
            $x +=1;
        }

        $stm->execute();
    }

    function increaseCantidadProduct($id,$cantidad){
        $stm = $this->DbConection->prepare("update productos set Cantidad = Cantidad + $cantidad where id = $id");
        $stm->execute();
    }

    function DecreaseCantidadProductCobrado($Productos){
        foreach($Productos as $_produc){
            $stm = $this->DbConection->prepare("update productos set Cantidad = Cantidad - ". $_produc["CantidadProductoVisita"] ." where id = ". $_produc["id_Producto"] ." ");
            $stm->execute();
        }
    }

    function getAllProductsforEachVisit($idVisita){
            $stm = $this->DbConection->prepare("select a.id_Producto, 
                                                       b.ProductoName,
                                                       a.precioProductoVisita,
                                                       a.CantidadProductoVisita
                                                 from  visita_producto as a
                                            inner join productos as b on b.id = a.id_Producto
                                                 where a.id_Visita = :idvisita;");
            $stm->bindValue(':idvisita', $idVisita, PDO::PARAM_INT);            
            $stm->execute();
            $errorInfo = $stm->errorInfo();
            if ($errorInfo[0] !== '00000') {
                throw new Exception("Ah ocurrido un error: ".$errorInfo[2]);
            }

            return $stm->fetchAll(PDO::FETCH_ASSOC);

    }


}
?>
<?php
    require_once($ProjectPath.'/Database/conexion.php');
    require_once(__DIR__.'/Actions.php');

    require 'ProductoService.php';

    class VentasService extends Actions{

        public function __construct(){
            $dataBase = new Connection();
            //Las columnas son solo para los methodos get osease los select que traen la info de la base de datos
            parent::__construct('ventas','id, Total, Fecha,status',$dataBase->getConnection());
        }

        function getAllVentasCustom(){
            $stm =  $this-> DbConection->prepare("select id,
                                                                Fecha,
                                                                Total
                                                           from ventas
                                                        where status = 1 and date( Fecha) = Date(Now()) order by Fecha Asc;");

            $stm->execute();
            $Ventas = $stm->fetchAll(PDO::FETCH_ASSOC);
            $errorInfo = $stm->errorInfo();
            if ($errorInfo[0] !== '00000') {
                throw new Exception("Ah ocurrido un error: ".$errorInfo[2]);
            }

            $resultados = [];

            $PS = new ProductoService();

            foreach($Ventas as $venta){
                $venta["Productos"] = $PS->getAllProductsforEachVenta($venta["id"]);
                array_push($resultados, $venta);
            }

            unset($venta);

            return $resultados;

        }

        function nuevaVenta($dataBody){

            $PS = new ProductoService();

            $stm =  $this-> DbConection->prepare("insert into ventas(Total, 
                                                                            Fecha)
	                                                                 value (:Total, 
                                                                            :Fecha);
                                                ");
            $stm->bindValue(':Total', $dataBody["Total"], PDO::PARAM_INT);
            $stm->bindValue(':Fecha', $dataBody["Fecha"], PDO::PARAM_STMT);
            $stm->execute();

            //Get new If for item created
            $query ="Select max(id) as id from ventas ";
            $stm = $this->DbConection->prepare($query);
            $stm->execute();

            $VentaResponse = $stm->fetchAll(PDO::FETCH_ASSOC);
            $idVenta = $VentaResponse[0];

            $PS->newVentaProducto($idVenta["id"],$dataBody["Productos"]);

            return $VentaResponse;
        }

    }
?>
<?php

    $pt = explode('\\',__DIR__);

    //Esta configuracion es la requerida para el servicio
    //$pt = explode('/',__DIR__);

    $ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3].'/'.$pt[4];
    //$ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3];

    require_once($ProjectPath.'/Database/conexion.php');
    require_once($ProjectPath.'/Services/VentasService.php');
    require_once($ProjectPath.'/Models/ResponseModel.php');

    class VentasController{

        function home(){
            echo 'Ventas Controller Home';
        }

        function getAllVentas(){

            $Response = new ResponseModel();

            try{
                $database = new Connection();
                $VentasSvc = new VentasService();
                $Response->Rbody = $VentasSvc->getAllVentasCustom();

                $Response->Rcode = 200;
                $Response->Rmessage = "All Gafete listed";
                                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                $database->closeConection();
                echo json_encode($Response);
            }
            /*echo '<prev>';
                var_dump($Gafete);
            echo '</prev>';*/
        }

        function addNewVenta(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'Total' =>$BodyRequest['Total'],
                    'Fecha' =>$BodyRequest['Fecha'],
                    'Productos' =>$BodyRequest['Productos']
                ];

                $database = new Connection();
                $VentasSvc = new VentasService();
                $Response->Rbody = $VentasSvc->nuevaVenta($dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Gafete created";

                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }

    }
?>
<?php

    $pt = explode('\\',__DIR__);
    //$ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3].'/'.$pt[4];
    $ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3];

    //echo $ProjectPath;

    require_once($ProjectPath.'/Database/conexion.php');
    require_once($ProjectPath.'/Services/OfertasService.php');
    require_once($ProjectPath.'/Models/ResponseModel.php');

    class OfertasController{

        function home(){
            echo 'Ofertas Controller Home';
        }

        function getAllOfertas(){

            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $OfertasSvc = new OfertasService();
                $Response->Rbody = $OfertasSvc->getAll();

                $Response->Rcode = 200;
                $Response->Rmessage = "All Ofertas listed";
                                
            }catch(Exception $ex){
                $Response->Rcode = 402;-
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                $database->closeConection();
                echo json_encode($Response);
            }
            /*echo '<prev>';
                var_dump($Ofertas);
            echo '</prev>';*/
        }

        function getAllActiveOfertas(){

            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $OfertasSvc = new OfertasService();
                $Response->Rbody = $OfertasSvc->getAll();

                $Response->Rcode = 200;
                $Response->Rmessage = "All Ofertas listed";
                                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                $database->closeConection();
                echo json_encode($Response);
            }
            /*echo '<prev>';
                var_dump($Ofertas);
            echo '</prev>';*/
        }

        function getOfertasById(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $OfertasSvc = new OfertasService();
                $Response->Rbody = $OfertasSvc->getById($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Ofertas Founded";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function addNewOfertas(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'OfertaName' =>$BodyRequest['OfertaName'],
                    'Descripcion' =>$BodyRequest['Descripcion'],
                    'Tiempo' =>$BodyRequest['Tiempo'],
                    'totalDescuento' =>$BodyRequest['totalDescuento'],
                ];

                $database = new Connection();
                $OfertasSvc = new OfertasService();
                $Response->Rbody =$OfertasSvc->new($dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Ofertas created";

                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function editOfertas(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'OfertaName' =>$BodyRequest['OfertaName'],
                    'Descripcion' =>$BodyRequest['Descripcion'],
                    'Tiempo' =>$BodyRequest['Tiempo'],
                    'totalDescuento' =>$BodyRequest['totalDescuento'],
                ];

                $database = new Connection();
                $OfertasSvc = new OfertasService();
                $OfertasSvc->update($BodyRequest['id'],$dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Ofertas Updated";

                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function deleteOfertas(){
            $Response = new ResponseModel();
            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $OfertasSvc = new OfertasService();
                $OfertasSvc->delete($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Ofertas Deleted";
                
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
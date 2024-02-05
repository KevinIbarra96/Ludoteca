<?php

    $pt = explode('\\',__DIR__);
    $ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3].'/'.$pt[4];

    //echo $ProjectPath;

    require_once($ProjectPath.'/Database/conexion.php');
    require_once($ProjectPath.'/Services/ServiciosService.php');
    require_once($ProjectPath.'/Models/ResponseModel.php');

    class ServiciosController{

        function home(){
            echo 'Servicios Controller Home';
        }

        function getAllServicios(){

            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $ServiciosSvc = new ServiciosService();
                $Response->Rbody = $ServiciosSvc->getAll();

                $Response->Rcode = 200;
                $Response->Rmessage = "All Servicios listed";
                                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                $database->closeConection();
                echo json_encode($Response);
            }
            /*echo '<prev>';
                var_dump($Servicios);
            echo '</prev>';*/
        }

        function getServiciosById(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $ServiciosSvc = new ServiciosService();
                $Response->Rbody = $ServiciosSvc->getById($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Servicios Founded";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function addNewServicios(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'ServicioName' =>$BodyRequest['ServicioName'],
                    'Tiempo' =>$BodyRequest['Tiempo'],
                    'status' =>$BodyRequest['status']
                ];

                $database = new Connection();
                $ServiciosSvc = new ServiciosService();
                $ServiciosSvc->new($dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Servicios created";

                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function editServicios(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'ServicioName' =>$BodyRequest['ServicioName'],
                    'Tiempo' =>$BodyRequest['Tiempo'],
                    'status' =>$BodyRequest['status']
                ];

                $database = new Connection();
                $ServiciosSvc = new ServiciosService();
                $ServiciosSvc->update($BodyRequest['id'],$dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Servicios Updated";

                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function deleteServicios(){
            $Response = new ResponseModel();
            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $ServiciosSvc = new ServiciosService();
                $Response->Rbody = $ServiciosSvc->delete($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Servicios Deleted";
                
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
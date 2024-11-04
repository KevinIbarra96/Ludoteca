<?php

    $pt = explode('\\',__DIR__);
    //$ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3].'/'.$pt[4];
    $ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3];

    //echo $ProjectPath;

    require_once($ProjectPath.'/Database/conexion.php');
    require_once($ProjectPath.'/Services/TipoServicioService.php');
    require_once($ProjectPath.'/Models/ResponseModel.php');

    class TipoServicioController{

        function home(){
            echo 'TipoServicio Controller Home';
        }

        function getAllTipoServicio(){

            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $TipoServicioSvc = new TipoServicioService();
                $Response->Rbody = $TipoServicioSvc->getAll();

                $Response->Rcode = 200;
                $Response->Rmessage = "All TipoServicio listed";
                                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                $database->closeConection();
                echo json_encode($Response);
            }
            /*echo '<prev>';
                var_dump($TipoServicio);
            echo '</prev>';*/
        }
        function getAllActiveTipoServicio(){

                $Response = new ResponseModel();
    
                try{            
                    $database = new Connection();
                    $TipoServicioSvc = new TipoServicioService();
                    $Response->Rbody = $TipoServicioSvc->getAllActive();
    
                    $Response->Rcode = 200;
                    $Response->Rmessage = "All TipoServicio listed";
                                    
                }catch(Exception $ex){
                    $Response->Rcode = 402;
                    $Response->Rmessage = $ex->getMessage();
                    $Response->RerrorCode = $ex->getCode();
                }finally{
                    $database->closeConection();
                    echo json_encode($Response);
                }
                /*echo '<prev>';
                    var_dump($TipoServicio);
                echo '</prev>';*/
            }

        function getTipoServicioById(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $TipoServicioSvc = new TipoServicioService();
                $Response->Rbody = $TipoServicioSvc->getById($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "TipoServicio Founded";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function addNewTipoServicio(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'TipoServicioName' =>$BodyRequest['TipoServicioName'],
                    'status' =>$BodyRequest['status'],
                ];

                $database = new Connection();
                $TipoServicioSvc = new TipoServicioService();
                $TipoServicioSvc->new($dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "TipoServicio created";

                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function editTipoServicio(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'TipoServicioName' =>$BodyRequest['TipoServicioName'],
                    'status' =>$BodyRequest['status'],
                ];

                $database = new Connection();
                $TipoServicioSvc = new TipoServicioService();
                $TipoServicioSvc->update($BodyRequest['id'],$dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "TipoServicio Updated";

                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function deleteTipoServicio(){
            $Response = new ResponseModel();
            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $TipoServicioSvc = new TipoServicioService();
                $TipoServicioSvc->delete($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "TipoServicio Deleted";
                
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
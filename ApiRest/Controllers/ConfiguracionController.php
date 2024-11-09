<?php

    $pt = explode('\\',__DIR__);
    $ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3].'/'.$pt[4];
    //$ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3];

    //echo $ProjectPath;

    require_once($ProjectPath.'/Database/conexion.php');
    require_once($ProjectPath.'/Services/ConfiguracionService.php');
    require_once($ProjectPath.'/Models/ResponseModel.php');

    class ConfiguracionController{

        function home(){
            echo 'Configuracion Controller Home';
        }

        function getAllConfiguracion(){

            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $ConfiguracionSvc = new ConfiguracionService();
                $Response->Rbody = $ConfiguracionSvc->getAll();

                $Response->Rcode = 200;
                $Response->Rmessage = "All Configuracion listed";
                                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                $database->closeConection();
                echo json_encode($Response);
            }
            /*echo '<prev>';
                var_dump($Configuracion);
            echo '</prev>';*/
        }

        function getAllActiveConfiguracion(){

            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $ConfiguracionSvc = new ConfiguracionService();
                $Response->Rbody = $ConfiguracionSvc->getAllActive();

                $Response->Rcode = 200;
                $Response->Rmessage = "All Active Configuracion listed";
                                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                $database->closeConection();
                echo json_encode($Response);
            }
            /*echo '<prev>';
                var_dump($Configuracion);
            echo '</prev>';*/
        }

        function getConfiguracionById(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $ConfiguracionSvc = new ConfiguracionService();
                $Response->Rbody = $ConfiguracionSvc->getById($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Configuracion Founded";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function addNewConfiguracion(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'ConfiguracionName' =>$BodyRequest['ConfiguracionName'],
                    'status' =>$BodyRequest['status'],
                ];

                $database = new Connection();
                $ConfiguracionSvc = new ConfiguracionService();
                $ConfiguracionSvc->new($dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Configuracion created";

                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function editConfiguracion(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'id' =>$BodyRequest['id'],
                    'ConfigName' =>$BodyRequest['ConfigName'],
                    'ConfigDescripcion' =>$BodyRequest['ConfigDescripcion'],
                    'ConfigStringValue' =>$BodyRequest['ConfigStringValue'],
                    'ConfigBoolValue' =>$BodyRequest['ConfigBoolValue'],
                    'ConfigIntValue' =>$BodyRequest['ConfigIntValue'],
                    'ConfigDecimalValue' =>$BodyRequest['ConfigDecimalValue']
                ];

                $database = new Connection();
                $ConfiguracionSvc = new ConfiguracionService();
                $ConfiguracionSvc->update($BodyRequest['id'],$dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Configuracion Updated";

                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function deleteConfiguracion(){
            $Response = new ResponseModel();
            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $ConfiguracionSvc = new ConfiguracionService();
                $ConfiguracionSvc->delete($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Configuracion Deleted";
                
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
<?php

    $pt = explode('\\',__DIR__);
    $ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3].'/'.$pt[4];
    //$ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3];

    //echo $ProjectPath;

    require_once($ProjectPath.'/Database/conexion.php');
    require_once($ProjectPath.'/Services/RolService.php');
    require_once($ProjectPath.'/Models/ResponseModel.php');

    class RolController{

        function home(){
            echo 'Rol Controller Home';
        }

        function getAllRol(){

            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $RolSvc = new RolService();
                $Response->Rbody = $RolSvc->getAll();

                $Response->Rcode = 200;
                $Response->Rmessage = "All Rol listed";
                                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                $database->closeConection();
                echo json_encode($Response);
            }
            /*echo '<prev>';
                var_dump($Rol);
            echo '</prev>';*/
        }
        function getAllActiveRol(){

            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $RolSvc = new RolService();
                $Response->Rbody = $RolSvc->getAllActive();

                $Response->Rcode = 200;
                $Response->Rmessage = "All Rol listed";
                                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                $database->closeConection();
                echo json_encode($Response);
            }
            /*echo '<prev>';
                var_dump($Rol);
            echo '</prev>';*/
        }        

        function getRolById(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $RolSvc = new RolService();
                $Response->Rbody = $RolSvc->getById($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Rol Founded";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function addNewRol(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'RolName' =>$BodyRequest['RolName'],
                    'MenuList' =>$BodyRequest['MenuList']
                ];

                $database = new Connection();
                $RolSvc = new RolService();
                $Response->Rbody = $RolSvc->addNewRol($dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Rol created";

                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function editRol(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'RolName' =>$BodyRequest['RolName'],
                    'status' =>$BodyRequest['status'],
                ];

                $database = new Connection();
                $RolSvc = new RolService();
                $RolSvc->update($BodyRequest['id'],$dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Rol Updated";

                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function deleteRol(){
            $Response = new ResponseModel();
            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $RolSvc = new RolService();
                $RolSvc->delete($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Rol Deleted";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
    }
<?php

    $pt = explode('\\', __DIR__);
    $ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3].'/'.$pt[4];

    require_once($ProjectPath.'/Database/conexion.php');
    require_once($ProjectPath.'/Database/HijoService.php');
    require_once($ProjectPath.'/Database/ResponseModel.php');
    
    class hijosController {
        function home () {
            echo 'Hijos Controller Home';
        }
        function getAllHijos(){
            $Response = new ResponseModel();

            try {
                $database = new Connection();
                $hijoSvc = new HijoService($database->getConnection());
                $Response->Rbody = $hijoSvc->getAll();
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "All User listed";
            }catch(Exception $ex){
                $Response -> Rcode = 402;
                $Response -> Rmessage = $ex->getMessage();
                $Response -> RerrorCode = $ex->getCode();
            } finally{
                echo json_encode($Response);
            }

        }
        function getHijoById(){
            $Response =  new ResponseModel();

            try {
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database =  new Connection();
                $hijoSvc = new HijoService($database->getConnection());
                $Response -> Rbody = $hijoSvc->getById($BodyRequest['id']);
                $database -> closeConection();

                $Response -> Rcode = 200;
                $Response -> Rmessage = "Hijo Founded";
            } catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        
        function addNewHijo(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $dataBody = [
                    'NombreHijo' =>$BodyRequest['NombreHijo'],
                    'Papa' =>$BodyRequest['Papa'],
                    'Mama'=>$BodyRequest['Mama'],
                    'FechaNac' =>$BodyRequest['FechaNac']
                ];

                $database = new Connection();
                $hijoSvc = new HijoService($database->getConnection());   
                $hijoSvc-> new ($dataBody);
                $database-> closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Hijo Inserted";

            } catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function editHijo(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $dataBody = [
                    'NombreHijo' =>$BodyRequest['NombreHijo'],
                    'Papa' =>$BodyRequest['Papa'],
                    'Mama'=>$BodyRequest['Mama'],
                    'FechaNac' =>$BodyRequest['FechaNac']
                ];

                $database = new Connection();
                $hijoSvc = new HijoService($database->getConnection());   
                $hijoSvc-> update($BodyRequest['id'], $dataBody);
                $database-> closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Hijo Updated";
            }catch (Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function deleteHijo(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents("php://input"),true);
                $database =  new Connection();
                $hijoSvc=new HijoService($database->getConnection());
                $Response-> Rbody = $hijoSvc->delete($BodyRequest['id']);
                $database ->closeConection();

                $Response -> Rcode = 402;
                $Response -> Rmessage = "Hijo Deleted";
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
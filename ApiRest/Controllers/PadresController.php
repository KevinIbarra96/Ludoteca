<?php

$pt = explode('\\',__DIR__);
$ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3].'/'.$pt[4];

require_once($ProjectPath.'/Database/conexion.php');
require_once($ProjectPath.'/Services/UserService.php');
require_once($ProjectPath.'/Models/ResponseModel.php');

class PadresController {

    function home() {
        echo 'Padres controller home';
    }

    function getAllPadres(){
        $Response = new ResponseModel();
        try{
            $database = new Connection();
            $userSvc = new UserService($database->getConnection());
            $Response->Rbody = $userSvc->getAll();
            $database->closeConection();

            $Response->Rcode = 200;
            $Response->Rmessage = "All Padres listed correctly";
        }catch(Exception $ex){
            $Response->Rcode = 402;
            $Response->Rmessage= $ex->getMessage();
            $Response->RerrorCode = $ex->getCode();

        } finally{
            echo json_encode($Response);
        }

    }
    
    function getPadresById(){
        $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $userSvc = new UserService($database->getConnection());
                $Response->Rbody = $userSvc->getById($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "User Founded";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }

    }
    function addNewPadres(){
        $Response = new ResponseModel();
            
        try{
            
        }
        echo 'addNewUser';
    }
    function edditPadres(){
        echo 'edditUser';
    }
    function deletePadres(){
        echo 'deleteUser';
    }
}


?>
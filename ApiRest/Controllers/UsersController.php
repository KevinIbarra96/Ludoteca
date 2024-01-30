<?php

    $pt = explode('\\',__DIR__);
    $ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3].'/'.$pt[4];

    //echo $ProjectPath;

    require_once($ProjectPath.'/Database/conexion.php');
    require_once($ProjectPath.'/Services/UserService.php');
    require_once($ProjectPath.'/Models/ResponseModel.php');

    class usersController{

        function home(){
            echo 'User Controller Home';
        }

        function getAllUsers(){

            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $userSvc = new UserService($database->getConnection());
                $Response->Rbody = $userSvc->getAll();
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "All User listed correctly";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
            /*echo '<prev>';
                var_dump($Users);
            echo '</prev>';*/
        }

        function getUserById(){
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
        function addNewUser(){
            echo 'addNewUser';
        }
        function edditUser(){
            echo 'edditUser';
        }
        function deleteUser(){
            echo 'deleteUser';
        }
    }
?>
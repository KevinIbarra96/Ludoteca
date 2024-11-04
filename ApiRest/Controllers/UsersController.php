<?php

    $pt = explode('\\',__DIR__);
    //$ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3].'/'.$pt[4];

    $ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3];

    //echo $ProjectPath;

    require_once($ProjectPath.'/Database/conexion.php');
    require_once($ProjectPath.'/Services/UserService.php');
    require_once($ProjectPath.'/Models/ResponseModel.php');

    class UsersController{

        function home(){
            echo 'User Controller Home';
        }
        
        function Login(){
            $Response = new ResponseModel();
            

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $userName = $BodyRequest['UserName'];
                $password = $BodyRequest['Password'];
                //creamos instancia del servicio de user
                $userSvc = new UserService();
                $Response = $userSvc->LoginService($userName, $password);
                
                $Response->Rcode = 200;
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }

        function getUsersAndRol(){
            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $userSvc = new UserService();
                $Response->Rbody = $userSvc->getUsersAndRol();
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "All User listed";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }

        function getAllUsers(){

            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $userSvc = new UserService();
                $Response->Rbody = $userSvc->getAll();
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "All User listed";
                
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

        function getAllActiveUsers(){

            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $userSvc = new UserService();
                $Response->Rbody = $userSvc->getAllActive();
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "All User listed";
                
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
                $userSvc = new UserService();
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
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'UserName' =>$BodyRequest['UserName'],
                    'Password' =>$BodyRequest['Password'],
                    'idRol' =>$BodyRequest['idRol']
                ];

                $database = new Connection();
                $userSvc = new UserService();                
                $userSvc->new($dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "User Inserted";

                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function editUser(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'UserName' =>$BodyRequest['UserName'],
                    'Password' =>$BodyRequest['Password'],
                    'idRol' =>$BodyRequest['idRol']
                ];
                        /*echo '<prev>';
                var_dump($RequestBody);
            echo '</prev>';*/
                $database = new Connection();
                $userSvc = new UserService();                
                $userSvc->update($BodyRequest['id'],$dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "User Updated";

                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function deleteUser(){
            $Response = new ResponseModel();
            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $userSvc = new UserService();
                $userSvc->delete($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "User Deleted";
                
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
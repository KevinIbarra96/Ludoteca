<?php

    $pt = explode('\\',__DIR__);

    //Esta configuracion es la requerida para el servicio
    //$pt = explode('/',__DIR__);

    $ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3].'/'.$pt[4];

    //$ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3];
    //$ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2];

    require_once($ProjectPath.'/Database/conexion.php');
    require_once($ProjectPath.'/Services/MenuService.php');
    require_once($ProjectPath.'/Models/ResponseModel.php');

    class MenuController{

        function home(){
            echo 'Menu Controller Home';
        }

        function getAllMenu(){

            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $MenuSvc = new MenuService();
                $Response->Rbody = $MenuSvc->getAll();

                $Response->Rcode = 200;
                $Response->Rmessage = "All Menu listed";
                                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                $database->closeConection();
                echo json_encode($Response);
            }
            /*echo '<prev>';
                var_dump($Menu);
            echo '</prev>';*/
        }

        function getAllActiveMenu(){

            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $MenuSvc = new MenuService();
                $Response->Rbody = $MenuSvc->getAllActive();

                $Response->Rcode = 200;
                $Response->Rmessage = "All Menu listed";
                                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                $database->closeConection();
                echo json_encode($Response);
            }
            /*echo '<prev>';
                var_dump($Menu);
            echo '</prev>';*/
        }

        function getMenuByRol(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $MenuSvc = new MenuService();
                $Response->Rbody = $MenuSvc->getMenuByRol($BodyRequest['idRol']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Menu Founded";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function getMenuById(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $MenuSvc = new MenuService();
                $Response->Rbody = $MenuSvc->getById($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Menu Founded";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function addNewMenu(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'MenuName' =>$BodyRequest['MenuName'],
                    'Path' =>$BodyRequest['Path'],
                    'Rol' =>$BodyRequest['Rol']
                ];

                $database = new Connection();
                $MenuSvc = new MenuService();                
                $Response->Rbody = $MenuSvc->new($dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Menu created";

                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function editMenu(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'MenuName' =>$BodyRequest['MenuName'],
                    'Path' =>$BodyRequest['Path'],
                    'Rol' =>$BodyRequest['Rol']
                ];

                $database = new Connection();
                $MenuSvc = new MenuService();                
                $MenuSvc->update($BodyRequest['id'],$dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Menu Updated";

                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function deleteMenu(){
            $Response = new ResponseModel();
            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $MenuSvc = new MenuService();
                $MenuSvc->delete($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Menu Deleted";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
    }
<?php

    $pt = explode('\\',__DIR__);

    //Esta configuracion es la requerida para el servicio
    //$pt = explode('/',__DIR__);

    $ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3];
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

                $database = new Connection();
                $RolSvc = new RolService();
                $MenuSvc = new MenuService();
                // Verificar si se debe actualizar el nombre del rol
                if (isset($BodyRequest['Rol']) && !empty($BodyRequest['Rol'])) {

                    $RolSvc->updateRol($BodyRequest['Rol']);
                }else{
                    throw new Exception("Rol no puede estar vacio", 405);
                }

                if (isset($BodyRequest['MenuList']) && is_array($BodyRequest['MenuList'])) {
                    $MenuSvc->updateMenusForRol($BodyRequest['Rol']["id"], $BodyRequest['MenuList']);
                }else{
                    throw new Exception("Lista de Menu no puede estar vacio", 405);
                }
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Rol y menús actualizados correctamente";

                
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
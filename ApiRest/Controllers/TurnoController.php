<?php

    $pt = explode('\\',__DIR__);

    //Esta configuracion es la requerida para el servicio
    //$pt = explode('/',__DIR__);

    $ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3].'/'.$pt[4];
    //$ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3];

    //echo $ProjectPath;

    require_once($ProjectPath.'/Database/conexion.php');
    require_once($ProjectPath.'/Services/TurnoService.php');
    require_once($ProjectPath.'/Models/ResponseModel.php');

    class TurnoController{

        function home(){
            echo 'Turno Controller Home';
        }

        function getAllTurno(){

            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $TurnoSvc = new TurnoService();
                $Response->Rbody = $TurnoSvc->getAll();

                $Response->Rcode = 200;
                $Response->Rmessage = "All Turno listed";
                                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                $database->closeConection();
                echo json_encode($Response);
            }
            /*echo '<prev>';
                var_dump($Turno);
            echo '</prev>';*/
        }
        function getAllActiveTurno(){

                $Response = new ResponseModel();
    
                try{            
                    $database = new Connection();
                    $TurnoSvc = new TurnoService();
                    $Response->Rbody = $TurnoSvc->getAllActive();
    
                    $Response->Rcode = 200;
                    $Response->Rmessage = "All Turno listed";
                                    
                }catch(Exception $ex){
                    $Response->Rcode = 402;
                    $Response->Rmessage = $ex->getMessage();
                    $Response->RerrorCode = $ex->getCode();
                }finally{
                    $database->closeConection();
                    echo json_encode($Response);
                }
                /*echo '<prev>';
                    var_dump($Turno);
                echo '</prev>';*/
            }

        function getTurnoById(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $TurnoSvc = new TurnoService();
                $Response->Rbody = $TurnoSvc->getById($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Turno Founded";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function addNewTurno(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'NombreTurno' =>$BodyRequest['NombreTurno']
                ];

                $database = new Connection();
                $TurnoSvc = new TurnoService();
                $TurnoSvc->new($dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Turno created";

                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function editTurno(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'NombreTurno' =>$BodyRequest['NombreTurno']
                ];

                $database = new Connection();
                $TurnoSvc = new TurnoService();
                $TurnoSvc->update($BodyRequest['id'],$dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Turno Updated";

                
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
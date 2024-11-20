<?php

    $pt = explode('\\',__DIR__);

    //Esta configuracion es la requerida para el servicio
    //$pt = explode('/',__DIR__);

    $ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3].'/'.$pt[4];
    //$ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3];

    //echo $ProjectPath;

    require_once($ProjectPath.'/Database/conexion.php');
    require_once($ProjectPath.'/Services/FiestaService.php');
    require_once($ProjectPath.'/Models/ResponseModel.php');

    class FiestaController{

        function home(){
            echo 'Fiesta Controller Home';
        }

        function getAllFiesta(){

            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $FiestaSvc = new FiestaService();
                $Response->Rbody = $FiestaSvc->getAll();

                $Response->Rcode = 200;
                $Response->Rmessage = "All Fiesta listed";
                                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                $database->closeConection();
                echo json_encode($Response);
            }
            /*echo '<prev>';
                var_dump($Fiesta);
            echo '</prev>';*/
        }
        function getAllActiveFiesta(){

                $Response = new ResponseModel();
    
                try{            
                    $database = new Connection();
                    $FiestaSvc = new FiestaService();
                    $Response->Rbody = $FiestaSvc->getallFiestasActive();
    
                    $Response->Rcode = 200;
                    $Response->Rmessage = "All Fiesta listed";
                                    
                }catch(Exception $ex){
                    $Response->Rcode = 402;
                    $Response->Rmessage = $ex->getMessage();
                    $Response->RerrorCode = $ex->getCode();
                }finally{
                    $database->closeConection();
                    echo json_encode($Response);
                }
                /*echo '<prev>';
                    var_dump($Fiesta);
                echo '</prev>';*/
            }


            function getFechasProgramadas(){

                $Response = new ResponseModel();
    
                try{            
                    $database = new Connection();
                    $FiestaSvc = new FiestaService();
                    $Response->Rbody = $FiestaSvc->getFechasProgramadas();
    
                    $Response->Rcode = 200;
                    $Response->Rmessage = "All Fiesta listed";
                                    
                }catch(Exception $ex){
                    $Response->Rcode = 402;
                    $Response->Rmessage = $ex->getMessage();
                    $Response->RerrorCode = $ex->getCode();
                }finally{
                    $database->closeConection();
                    echo json_encode($Response);
                }
                /*echo '<prev>';
                    var_dump($Fiesta);
                echo '</prev>';*/
            }


        function getFiestaById(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $FiestaSvc = new FiestaService();
                $Response->Rbody = $FiestaSvc->getById($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Fiesta Founded";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function addNewFiesta(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'IdServicio' =>$BodyRequest['IdServicio'],
                    'Fecha' =>$BodyRequest['Fecha'],
                    'Anticipo' =>$BodyRequest['Anticipo'],
                    'IdTurno' =>$BodyRequest['IdTurno'],
                    'Hijo' => $BodyRequest['Hijo'],
                    'TipoComida' =>$BodyRequest['TipoComida'],
                    'NinosAdicionales' =>$BodyRequest['NinosAdicionales'],
                    'Tematica' =>$BodyRequest['Tematica'],
                    'EdadACumplir' =>$BodyRequest['EdadACumplir'],
                    'Total' =>$BodyRequest['Total']
                ];

                $database = new Connection();
                $FiestaSvc = new FiestaService();
                $Response->Rbody = $FiestaSvc->ProgramarFiesta($dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Fiesta created";

                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function editFiesta(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'idServicio' =>$BodyRequest['IdServicio'],
                    'Fecha' =>$BodyRequest['Fecha'],
                    'Anticipo' =>$BodyRequest['Anticipo'],
                    'idTurno' =>$BodyRequest['IdTurno'],
                    'TipoComida' =>$BodyRequest['TipoComida'],
                    'NinosAdicionales' =>$BodyRequest['NinosAdicionales'],
                    'Tematica' =>$BodyRequest['Tematica'],
                    'EdadACumplir' =>$BodyRequest['EdadACumplir'],
                    'Total' =>$BodyRequest['Total']
                ];

                $database = new Connection();
                $FiestaSvc = new FiestaService();
                $FiestaSvc->update($BodyRequest['id'],$dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Fiesta Updated";

                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function deleteFiesta(){
            $Response = new ResponseModel();
            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $FiestaSvc = new FiestaService();
                $FiestaSvc->delete($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Fiesta Deleted";
                
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
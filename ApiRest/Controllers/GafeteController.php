<?php

    $pt = explode('\\',__DIR__);
    //$ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3].'/'.$pt[4];
    $ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3];

    //echo $ProjectPath;

    require_once($ProjectPath.'/Database/conexion.php');
    require_once($ProjectPath.'/Services/GafeteService.php');
    require_once($ProjectPath.'/Models/ResponseModel.php');

    class GafeteController{

        function home(){
            echo 'Gafete Controller Home';
        }

        function getGafeteNoAsignado(){
            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $GafeteSvc = new GafeteService();
                $Response->Rbody = $GafeteSvc->getGafeteNoAsignado();

                $Response->Rcode = 200;
                $Response->Rmessage = "All Gafete UnAssigned listed";
                                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                $database->closeConection();
                echo json_encode($Response);
            }
        }

        function getAllGafete(){

            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $GafeteSvc = new GafeteService();
                $Response->Rbody = $GafeteSvc->getAll();

                $Response->Rcode = 200;
                $Response->Rmessage = "All Gafete listed";
                                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                $database->closeConection();
                echo json_encode($Response);
            }
            /*echo '<prev>';
                var_dump($Gafete);
            echo '</prev>';*/
        }

        function getAllActiveGafete(){

            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $GafeteSvc = new GafeteService();
                $Response->Rbody = $GafeteSvc->getAllActive();

                $Response->Rcode = 200;
                $Response->Rmessage = "All Gafete listed";
                                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                $database->closeConection();
                echo json_encode($Response);
            }
            /*echo '<prev>';
                var_dump($Gafete);
            echo '</prev>';*/
        }

        function getGafeteById(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $GafeteSvc = new GafeteService();
                $Response->Rbody = $GafeteSvc->getById($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Gafete Founded";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function addNewGafete(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'GafeteName' =>$BodyRequest['GafeteName'],
                    'status' =>$BodyRequest['status'],
                ];

                $database = new Connection();
                $GafeteSvc = new GafeteService();
                $GafeteSvc->new($dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Gafete created";

                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function editGafete(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'GafeteName' =>$BodyRequest['GafeteName'],
                    'status' =>$BodyRequest['status'],
                ];

                $database = new Connection();
                $GafeteSvc = new GafeteService();
                $GafeteSvc->update($BodyRequest['id'],$dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Gafete Updated";

                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function deleteGafete(){
            $Response = new ResponseModel();
            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $GafeteSvc = new GafeteService();
                $GafeteSvc->delete($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Gafete Deleted";
                
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
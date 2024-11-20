<?php

$pt = explode('\\',__DIR__);

//Esta configuracion es la requerida para el servicio
//$pt = explode('/',__DIR__);

$ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3].'/'.$pt[4];

//$ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3];

require_once($ProjectPath.'/Database/conexion.php');
require_once($ProjectPath.'/Services/PadreService.php');
require_once($ProjectPath.'/Models/ResponseModel.php');

class PadresController {

    function home() {
        echo 'Padres controller home';
    }


    function getPadreByPhone(){
        $Response = new ResponseModel();
        try{
            $BodyRequest = json_decode(file_get_contents('php://input'),true);
            $database = new Connection();
            $padreSvc = new PadreService();
            $Response->Rbody = $padreSvc->getPadreByPhone($BodyRequest['phone']);
            $database->closeConection();

            $Response->Rcode = 200;
            $Response->Rmessage = "Padre Encontrado";
        }catch(Exception $ex){
            $Response->Rcode = 402;
            $Response->Rmessage= $ex->getMessage();
            $Response->RerrorCode = $ex->getCode();

        } finally{
            echo json_encode($Response);
        }        
    }

    function getAllPadres(){
        $Response = new ResponseModel();
        try{
            $database = new Connection();
            $padreSvc = new PadreService();
            $Response->Rbody = $padreSvc->getAll();
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

    function getAllActivePadres(){
        $Response = new ResponseModel();
        try{
            $database = new Connection();
            $padreSvc = new PadreService();
            $Response->Rbody = $padreSvc->getAllActive();
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
    
    function getPadreById(){
        $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $padreSvc = new PadreService();
                $Response->Rbody = $padreSvc->getById($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Padres Founded";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }

    }
    function addNewPadre(){
        $Response = new ResponseModel();
            
        try{
            $BodyRequest = json_decode(file_get_contents('php://input'),true);

            $dataBody = [
                'PadreName' => $BodyRequest["PadreName"],
                'Address' => $BodyRequest["Address"],
                'Telefono' => $BodyRequest["Telefono"]
            ];

            $database = new Connection();
            $padreSvc = new PadreService();                
            $Response->Rbody = $padreSvc->new($dataBody);
            $database->closeConection();

            $Response->Rcode = 200;
            $Response->Rmessage = "Padre Inserted";
        }catch(Exception $ex){
            $Response->Rcode = 402;
            $Response->Rmessage = $ex->getMessage();
            $Response->RerrorCode = $ex->getCode();
        } finally{
            echo json_encode($Response);
        }
    }
     
    function editPadre(){
        $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'PadreName' => $BodyRequest['PadreName'],
                    'Address' => $BodyRequest['Address'],
                    'Telefono' => strval($BodyRequest['Telefono']) 
                ];

                $database = new Connection();
                $padreSvc = new PadreService();                
                $padreSvc->update($BodyRequest['id'],$dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Padres updated";

                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
    }
    function deletePadre(){
        $Response = new ResponseModel();
            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $padreSvc = new PadreService();
                $padreSvc->delete($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Padre Deleted";
                
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

<?php
     $pt = explode('\\',__DIR__);
     $ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3].'/'.$pt[4];

    require_once($ProjectPath.'/Database/conexion.php');
    require_once($ProjectPath.'/Services/VisitaService.php');
    require_once($ProjectPath.'/Models/ResponseModel.php');

    class visitasController{

        function home(){
            echo 'Visitas Controller Home';
        }

        function getAllVisitas(){

            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $visitaSvc = new VisitaService($database->getConnection());
                $Response->Rbody = $visitaSvc->getAll();
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "All visitas listed";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
            
        }

        function getVisitaById(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $visitaSvc = new VisitaService($database->getConnection());
                $Response->Rbody = $visitaSvc->getById($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Visita Founded";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function addNewVisita(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'Hijo' =>$BodyRequest['Hijo'],
                    'Servicio' =>$BodyRequest['Servicio'],
                    'Productos' =>$BodyRequest['Productos'],
                    'HoraEntrada' => $BodyRequest['HoraEntrada'],
                    'HoraSalida' => $BodyRequest['HoraSalidad'],
                    'Oferta' => $BodyRequest['Oferta']

                ];

                $database = new Connection();
                $visitaSvc = new VisitaService($database->getConnection());                
                $visitaSvc->new($dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Visita Inserted";

                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function editVisita(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'Hijo' =>$BodyRequest['Hijo'],
                    'Servicio' =>$BodyRequest['Servicio'],
                    'Productos' =>$BodyRequest['Productos'],
                    'HoraEntrada' => $BodyRequest['HoraEntrada'],
                    'HoraSalida' => $BodyRequest['HoraSalidad'],
                    'Oferta' => $BodyRequest['Oferta']
                ];

                $database = new Connection();
                $visitaSvc = new VisitaService($database->getConnection());                
                $visitaSvc->update($BodyRequest['id'],$dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Visita Updated";

                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function deleteVisita(){
            $Response = new ResponseModel();
            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $visitaSvc = new VisitaService($database->getConnection());
                $Response->Rbody = $visitaSvc->delete($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Visita Deleted";
                
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
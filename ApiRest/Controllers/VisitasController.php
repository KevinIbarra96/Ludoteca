<?php
    $pt = explode('\\',__DIR__);
    $ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3].'/'.$pt[4];

    require_once($ProjectPath.'/Database/conexion.php');
    require_once($ProjectPath.'/Services/VisitaService.php');
    require_once($ProjectPath.'/Models/ResponseModel.php');

    class VisitasController{

        function home(){
            echo 'Visitas Controller Home';
        }

        function cobrarVisitas(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'id' =>$BodyRequest['id'],
                    'GafeteId' => $BodyRequest['GafeteId'],
                    'HoraSalida' => $BodyRequest['HoraSalida'],
                    'Productos' => $BodyRequest['Productos'],
                    'Total' => $BodyRequest['Total'],
                    'TiempoTotal' => $BodyRequest['TiempoTotal'],
                    'TiempoExcedido' => $BodyRequest['TiempoExcedido']
                ];
                
                $database = new Connection();
                $visitaSvc = new VisitaService();                
                $visitaSvc->cobrarVisitas($dataBody["id"],$dataBody["Total"],$dataBody["GafeteId"],$BodyRequest['Productos'],$BodyRequest['TiempoExcedido'],$dataBody["HoraSalida"],$dataBody["TiempoTotal"]);
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

        function addServicioToVisita(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'id' =>$BodyRequest['id'],
                    'Servicios' => $BodyRequest['Servicios'],                    
                ];

                $database = new Connection();
                $visitaSvc = new VisitaService();
                $visitaSvc->addServicioToVisita($dataBody["id"],$dataBody["Servicios"]);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Servicio Agregado";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }

        function addProductosToVisita(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'id' =>$BodyRequest['id'],
                    'Productos' => $BodyRequest['productos'],                    
                ];

                $database = new Connection();
                $visitaSvc = new VisitaService();
                $visitaSvc->addProductoToVisita($dataBody["id"],$dataBody["Productos"]);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "producto Agregado";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }

        function ingresarNuevaVisita(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'id' =>$BodyRequest['id'],
                    'HoraEntrada' =>$BodyRequest['HoraEntrada'],
                    'Oferta' =>$BodyRequest['Oferta'],
                    'Hijos' => $BodyRequest['Hijos'],
                    'Servicios' => $BodyRequest['Servicios'],
                    'Padres' => $BodyRequest['Padres'],
                    'Productos' => $BodyRequest['Productos'],
                    'Total' => $BodyRequest['Total'],
                    'GafeteId' => $BodyRequest['GafeteId'],
                    'NumeroGafete' => $BodyRequest['NumeroGafete']
                ];

                $database = new Connection();
                $visitaSvc = new VisitaService();                
                $Response->Rbody = $visitaSvc->ingresarVisita($dataBody);
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

        function getVisitasActivas(){
            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $visitaSvc = new VisitaService();
                $Response->Rbody = $visitaSvc->getVisitasActivas();
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

        function getAllVisitas(){

            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $visitaSvc = new VisitaService();
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

        function getAllActiveVisitas(){

            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $visitaSvc = new VisitaService();
                $Response->Rbody = $visitaSvc->getAllActive();
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
                $visitaSvc = new VisitaService();
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
                    'HoraSalida' => $BodyRequest['HoraSalida'],
                    'Oferta' => $BodyRequest['Oferta']

                ];

                $database = new Connection();
                $visitaSvc = new VisitaService();                
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
                    'HoraSalida' => $BodyRequest['HoraSalida'],
                    'Oferta' => $BodyRequest['Oferta']
                ];

                $database = new Connection();
                $visitaSvc = new VisitaService();                
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
                $visitaSvc = new VisitaService();
                $visitaSvc->delete($BodyRequest['id']);
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
        function getAllCompletedVisitas(){

            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $visitaSvc = new VisitaService();
                $Response->Rbody = $visitaSvc-> getVisitasCompleted();
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "All visitas completed listed";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
            
        }
        function getVisitaCompleteByDate(){
            $Response = new ResponseModel();
            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $visitaSvc = new VisitaService();
                $fecha = date('Y-m-d', strtotime($BodyRequest['HoraEntrada']));
                $Response->Rbody = $visitaSvc->getVisitasCompletedByDate($fecha);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Visitas completadas listadas por fecha";
                
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
<?php
    $pt = explode('\\',__DIR__);
    $ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3].'/'.$pt[4];

    //$ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3];

    require_once($ProjectPath.'/Database/conexion.php');
    require_once($ProjectPath.'/Services/TicketsService.php');
    require_once($ProjectPath.'/Models/ResponseModel.php');

    class TicketsController{
        
        function home(){
            echo 'Tickets Controller home';
        }

        function getAllTickets(){
            $Response =  new ResponseModel();

            try{
                $database = new Connection();
                $ticketsSvc =  new TicketsService();
                $Response->Rbody = $ticketsSvc->getAll();
                $database-> closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "All Tickets listed";
            } catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }


        }
        function getAllActiveTickets(){
            $Response = new ResponseModel();
            try{
                $database = new Connection();
                $ticketsSvc = new TicketsService();
                $Response->Rbody = $ticketsSvc->getAllActive();
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "All Tickets Active listed";
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();

            }finally{
                echo json_encode($Response);
            }
        }
        function getTicketById(){
            $Response = new ResponseModel();
            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $ticketsSvc = new TicketsService();
                $Response->Rbody = $ticketsSvc->getById($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Ticket found";
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();

            }finally{
                echo json_encode($Response);
            }   
        }
        function addNewTicket(){
            $Response = new ResponseModel();
            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $dataBody = [
                    'nombre' => $BodyRequest['nombre'],
                    'idvisita' => $BodyRequest['idvisita'],
                    'fecha_creacion' => $BodyRequest['fecha_creacion'],
                    'ruta' => $BodyRequest['ruta']
                ];

                $database = new Connection();
                $ticketsSvc = new TicketsService();
                $Response->Rbody = $ticketsSvc->new($dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Ticket inserted";
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();

            }finally{
                echo json_encode($Response);
            }
        }
        function editTicket(){
            $Response = new ResponseModel();
            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $dataBody = [
                    'nombre' => $BodyRequest['nombre'],
                    'idvisita' => $BodyRequest['idvisita'],
                    'fecha_creacion' => $BodyRequest['fecha_creacion'],
                    'ruta' => $BodyRequest['ruta']
                ];
                
                $database = new Connection();
                $ticketsSvc = new TicketsService();
                $ticketsSvc->update($BodyRequest['id'],$dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Ticket Updated";
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();

            }finally{
                echo json_encode($Response);
            }
        }
        function deleteTicket(){
            $Response = new ResponseModel();
            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                
                $database = new Connection();
                $ticketsSvc = new TicketsService();
                $ticketsSvc->delete($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Ticket Deleted";
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();

            }finally{
                echo json_encode($Response);
            }
        }
        function getNewFolio(){
            $Response = new ResponseModel();
            try{
                $database = new Connection();
                $ticketsSvc = new TicketsService();
                $Response->Rbody = $ticketsSvc->getNewFolio();
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "New Folio";
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
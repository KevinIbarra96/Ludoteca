<?php

    require_once($ProjectPath.'/Database/conexion.php');
    require_once(__DIR__.'/Actions.php');

    require 'PadreService.php';
    require 'ProductoService.php';
    require 'HijoService.php';
    require 'ServiciosService.php';
    require 'GafeteService.php';
    require 'OfertasService.php';

    class VisitaService extends Actions{

        public function __construct(){
            $database = new Connection();
            parent::__construct('visitas','Hijo,Servicio,Productos,HoraEntrada,HoraSalida,Oferta,TiempoTotal, status',$database->getConnection());
        }

        function cobrarVisitas($idVisita,$total,$idGafete,$Productos,$TiempoExcedido,$HoraSalida,$TiempoTotal){
            $stm = $this->DbConection->prepare("update visitas set HoraSalida = :HoraSalida,TiempoTotal = :TiempoTotal,status =2,Total=:Total,TiempoExcedido=:TiempoExcedido where id=:idVisita");
            $stm->bindValue(':idVisita', $idVisita, PDO::PARAM_INT);
            $stm->bindValue(':HoraSalida', $HoraSalida, PDO::PARAM_STR);
            $stm->bindValue(':Total', $total, PDO::PARAM_INT);
            $stm->bindValue(':TiempoTotal', $TiempoTotal, PDO::PARAM_INT);
            $stm->bindValue(':TiempoExcedido', $TiempoExcedido, PDO::PARAM_INT);
            $stm->execute();
            
            $GS = new GafeteService();
            $PS = new ProductoService();
            
            $GS->updateAsNotAsignado($idGafete);
            $PS->DecreaseCantidadProductCobrado($Productos);
        }

        function addServicioToVisita($idVisita,$servicios){

            $SS = new ServiciosService();
            $SS->newVisitaServicios($idVisita,$servicios);

        }

        function addProductoToVisita($idVisita,$productos){
            
            $PS = new ProductoService();
            $PS->newVisitaProducto($idVisita,$productos);

        }


        function ingresarVisita($visita){
            $HS = new HijoService();
            $PS = new ProductoService();
            $SS = new ServiciosService();
            $GS = new GafeteService();

            $stm =  $this-> DbConection->prepare("insert into visitas(GafeteId,
                                                                      NumeroGafete,
                                                                      HoraEntrada,
                                                                      Oferta,
                                                                      Total)
                                                                value (:GafeteId,
                                                                      :NumeroGafete,
                                                                      :HoraEntrada,
                                                                      :Oferta,
                                                                      :Total);");
            $stm->bindValue(':GafeteId', $visita["GafeteId"], PDO::PARAM_INT);
            $stm->bindValue(':NumeroGafete', $visita["NumeroGafete"], PDO::PARAM_INT);
            $stm->bindValue(':HoraEntrada', $visita["HoraEntrada"], PDO::PARAM_STR);
            $stm->bindValue(':Oferta', $visita["Oferta"][0]["id"], PDO::PARAM_INT);
            $stm->bindValue(':Total', $visita["Total"], PDO::PARAM_INT);
            $stm->execute();

            $query ="Select max(id) as id,NOW() as HoraEntrada from visitas;";
            $stm = $this->DbConection->prepare($query);
            $stm->execute();
            $VisitaResponse = $stm->fetchAll(PDO::FETCH_ASSOC);
            $idVisita = $VisitaResponse[0];

            $HS->newVisitaHijo($idVisita["id"],$visita["Hijos"]);
            $PS->newVisitaProducto($idVisita["id"],$visita["Productos"]);
            $SS->newVisitaServicios($idVisita["id"],$visita["Servicios"]);
            $GS->updateAsAsignado($visita["GafeteId"]);

            return $VisitaResponse;
        }

        function getVisitasActivas(){

            $stm =  $this-> DbConection->prepare("select a.id,
                                                         a.HoraEntrada,
                                                         a.HoraSalida,
                                                         a.GafeteId,
                                                         a.Oferta as IdOferta,
                                                         a.NumeroGafete,
                                                         b.OfertaName,
                                                         a.TiempoExcedido,
                                                         a.TiempoTotal
                                                    from visitas as a
                                              inner join ofertas as b on b.id = a.Oferta
                                                   where a.status = 1;");
            $stm->execute();
            
            $Visitas = $stm->fetchAll(PDO::FETCH_ASSOC);
            $errorInfo = $stm->errorInfo();
            if ($errorInfo[0] !== '00000') {
                throw new Exception("Ah ocurrido un error: ".$errorInfo[2]);
            }

            $resultados = [];

            $HS = new HijoService();
            $PadreS = new PadreService();
            $PS = new ProductoService();
            $SS = new ServiciosService();
            $OS = new OfertasService();

            foreach($Visitas as $visita){
                $visita["Hijos"] = $HS->getHijosbyVisita($visita['id']);
                
                foreach($visita["Hijos"] as $hijos){
                    $visita["Padres"] = $PadreS->getPadresbyidfromHijos($hijos['mama'],$hijos['papa']);
                    break;
                }

                $visita["Productos"] = $PS->getAllProductsforEachVisit($visita['id']);
                $visita["Servicios"] = $SS->getAllServiceByEachVisit($visita['id']);
                $visita["Oferta"] = $OS->getById($visita['IdOferta']);
                $visita["Timer"] = null;
                array_push($resultados, $visita); // Agregar la visita con las propiedades adicionales al nuevo array
            }
            
            unset($visita);

            return $resultados;

        }
        function getVisitasCompleted(){

            $stm =  $this-> DbConection->prepare("select a.id,
                                                         a.HoraEntrada,
                                                         a.HoraSalida,
                                                         a.GafeteId,
                                                         a.Oferta as IdOferta,
                                                         a.NumeroGafete,
                                                         b.OfertaName,
                                                         a.TiempoTotal,
                                                         a.Total
                                                    from visitas as a
                                              inner join ofertas as b on b.id = a.Oferta
                                                   where a.status = 2
                                                   AND DATE(a.HoraEntrada) = CURDATE()
                                                   ORDER BY a.HoraEntrada ASC;");
            $stm->execute();
            
            $Visitas = $stm->fetchAll(PDO::FETCH_ASSOC);
            $errorInfo = $stm->errorInfo();
            if ($errorInfo[0] !== '00000') {
                throw new Exception("Ah ocurrido un error: ".$errorInfo[2]);
            }

            $resultados = [];

            $HS = new HijoService();
            $PadreS = new PadreService();
            $PS = new ProductoService();
            $SS = new ServiciosService();
            $OS = new OfertasService();

            foreach($Visitas as $visita){
                $visita["Hijos"] = $HS->getHijosbyVisita($visita['id']);
                
                foreach($visita["Hijos"] as $hijos){
                    $visita["Padres"] = $PadreS->getPadresbyidfromHijos($hijos['mama'],$hijos['papa']);
                    break;
                }

                $visita["Productos"] = $PS->getAllProductsforEachVisit($visita['id']);
                $visita["Servicios"] = $SS->getAllServiceByEachVisit($visita['id']);
                $visita["Oferta"] = $OS->getById($visita['IdOferta']);
                $visita["Timer"] = null;
                array_push($resultados, $visita); // Agregar la visita con las propiedades adicionales al nuevo array
            }
            
            unset($visita);

            return $resultados;

        }
        function getVisitasCompletedByDate($fecha) {
            $stm = $this->DbConection->prepare("
                SELECT a.id,
                       a.HoraEntrada,
                       a.HoraSalida,
                       a.GafeteId,
                       a.Oferta AS IdOferta,
                       a.NumeroGafete,
                       b.OfertaName,
                       a.TiempoTotal,
                       a.Total
                  FROM visitas AS a
            INNER JOIN ofertas AS b ON b.id = a.Oferta
                 WHERE a.status = 2
                   AND DATE(a.HoraEntrada) = :fecha
              ORDER BY a.HoraEntrada ASC;
            ");
        
            $stm->bindParam(':fecha', $fecha, PDO::PARAM_STR);

            $stm->execute();
        
            $Visitas = $stm->fetchAll(PDO::FETCH_ASSOC);
            $errorInfo = $stm->errorInfo();
            if ($errorInfo[0] !== '00000') {
                throw new Exception("Ocurrió un error: " . $errorInfo[2]);
            }
        
            $resultados = [];
        
            $HS = new HijoService();
            $PadreS = new PadreService();
            $PS = new ProductoService();
            $SS = new ServiciosService();
            $OS = new OfertasService();
        
            foreach ($Visitas as $visita) {
                $visita["Hijos"] = $HS->getHijosbyVisita($visita['id']);
                
                foreach ($visita["Hijos"] as $hijos) {
                    $visita["Padres"] = $PadreS->getPadresbyidfromHijos($hijos['mama'], $hijos['papa']);
                    break;
                }
        
                $visita["Productos"] = $PS->getAllProductsforEachVisit($visita['id']);
                $visita["Servicios"] = $SS->getAllServiceByEachVisit($visita['id']);
                $visita["Oferta"] = $OS->getById($visita['IdOferta']);
                $visita["Timer"] = null;
        
                array_push($resultados, $visita);
            }
        
            unset($visita);
        
            return $resultados;
        }
        function getVisitasCompletedByDateRange($horaEntrada, $HoraSalida) {
            $stm = $this->DbConection->prepare("
                SELECT a.id,
                    a.HoraEntrada,
                    a.HoraSalida,
                    a.GafeteId,
                    a.Oferta AS IdOferta,
                    a.NumeroGafete,
                    b.OfertaName,
                    a.TiempoTotal,
                    a.Total
                FROM visitas AS a
                INNER JOIN ofertas AS b ON b.id = a.Oferta
                WHERE a.status = 2
                AND DATE(a.HoraEntrada) BETWEEN :horaEntrada AND :HoraSalida
                ORDER BY a.HoraEntrada ASC;
            ");
            $stm->bindParam(':horaEntrada', $horaEntrada);
            $stm->bindParam(':HoraSalida', $HoraSalida);
            $stm->execute();

            $Visitas = $stm->fetchAll(PDO::FETCH_ASSOC);
            $errorInfo = $stm->errorInfo();
            if ($errorInfo[0] !== '00000') {
                throw new Exception("Ocurrió un error: " . $errorInfo[2]);
            }
            $resultados = [];
        
            $HS = new HijoService();
            $PadreS = new PadreService();
            $PS = new ProductoService();
            $SS = new ServiciosService();
            $OS = new OfertasService();
        
            foreach ($Visitas as $visita) {
                $visita["Hijos"] = $HS->getHijosbyVisita($visita['id']);
                
                foreach ($visita["Hijos"] as $hijos) {
                    $visita["Padres"] = $PadreS->getPadresbyidfromHijos($hijos['mama'], $hijos['papa']);
                    break;
                }
        
                $visita["Productos"] = $PS->getAllProductsforEachVisit($visita['id']);
                $visita["Servicios"] = $SS->getAllServiceByEachVisit($visita['id']);
                $visita["Oferta"] = $OS->getById($visita['IdOferta']);
                $visita["Timer"] = null;
        
                array_push($resultados, $visita);
            }
        
            unset($visita);
        
            return $resultados;

        }
        
    }
?>
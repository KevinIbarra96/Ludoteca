<?php

    require_once($ProjectPath.'/Database/conexion.php');
    require_once(__DIR__.'/Actions.php');

    require 'PadreService.php';
    require 'ProductoService.php';
    require 'HijoService.php';
    require 'ServiciosService.php';
    require 'GafeteService.php';

    class VisitaService extends Actions{

        public function __construct(){
            $database = new Connection();
            parent::__construct('visitas','Hijo,Servicio,Productos,HoraEntrada,HoraSalida,Oferta, status',$database->getConnection());
        }

        function cobrarVisitas($idVisita,$total,$idGafete){
            $stm = $this->DbConection->prepare("update visitas set HoraSalida = NOW(),status =0,Total=:Total where id=:idVisita");
            $stm->bindValue(':idVisita', $idVisita, PDO::PARAM_INT);
            $stm->bindValue(':Total', $total, PDO::PARAM_INT);
            $stm->execute();
            
            $GS = new GafeteService();
            $GS->updateAsNotAsignado($idGafete);
        }

        function ingresarVisita($visita){
            $HS = new HijoService();
            $PadreS = new PadreService();
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
                                                                      NOW(),
                                                                      :Oferta,
                                                                      :Total);");
            $stm->bindValue(':GafeteId', $visita["GafeteId"], PDO::PARAM_INT);
            $stm->bindValue(':NumeroGafete', $visita["NumeroGafete"], PDO::PARAM_INT);
            $stm->bindValue(':Oferta', $visita["Oferta"], PDO::PARAM_INT);
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
                                                         A.NumeroGafete,
                                                         b.OfertaName
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

            foreach($Visitas as $visita){
                $visita["Hijos"] = $HS->getHijosbyVisita($visita['id']);
                
                foreach($visita["Hijos"] as $hijos){
                    $visita["Padres"] = $PadreS->getPadresbyidfromHijos($hijos['mama'],$hijos['papa']);
                    break;
                }

                $visita["Productos"] = $PS->getAllProductsforEachVisit($visita['id']);
                $visita["Servicios"] = $SS->getAllServiceByEachVisit($visita['id']);
                $visita["Timer"] = null;
                array_push($resultados, $visita); // Agregar la visita con las propiedades adicionales al nuevo array
            }
            
            unset($visita);

            return $resultados;

        }
    }
?>
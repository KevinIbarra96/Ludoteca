<?php

    require_once($ProjectPath.'/Database/conexion.php');
    require_once(__DIR__.'/Actions.php');

    require 'PadreService.php';
    require 'ProductoService.php';
    require 'HijoService.php';
    require 'ServiciosService.php';

    class VisitaService extends Actions{

        public function __construct(){
            $database = new Connection();
            parent::__construct('visitas','Hijo,Servicio,Productos,HoraEntrada,HoraSalida,Oferta, status',$database->getConnection());
        }

        function ingresarVisita($visita){
            $HS = new HijoService();
            $PadreS = new PadreService();
            $PS = new ProductoService();
            $SS = new ServiciosService();

            $stm =  $this-> DbConection->prepare("insert into visitas(HoraEntrada,
                                                                      Oferta,
                                                                      Total)
                                                                value (NOW(),
                                                                      :Oferta,
                                                                      :Total);");
            $stm->bindValue(':Oferta', $visita["Oferta"], PDO::PARAM_INT);
            $stm->bindValue(':Total', $visita["Total"], PDO::PARAM_INT);
            $stm->execute();

            $query ="Select max(id) as id from visitas;";
            $stm = $this->DbConection->prepare($query);
            $stm->execute();
            $newId = $stm->fetchAll(PDO::FETCH_ASSOC);
            $idVisita = $newId[0];

            $HS->newVisitaHijo($idVisita["id"],$visita["Hijos"]);
            $PS->newVisitaProducto($idVisita["id"],$visita["Productos"]);
            $SS->newVisitaServicios($idVisita["id"],$visita["Servicios"]);

            return $newId;
        }

        function getVisitasActivas(){
            $stm =  $this-> DbConection->prepare("select a.id,
                                                         a.HoraEntrada,
                                                         a.HoraSalida,
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
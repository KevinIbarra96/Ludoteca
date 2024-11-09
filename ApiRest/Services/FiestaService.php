<?php
    require_once($ProjectPath.'/Database/conexion.php');
    require_once(__DIR__.'/Actions.php');

    require 'PadreService.php';
    require 'HijoService.php';
    require 'ServiciosService.php';

    class FiestaService extends Actions{

        public function __construct(){
            $dataBase = new Connection();
            //Las columnas son solo para los methodos get osease los select que traen la info de la base de datos
            parent::__construct('fiestas','id, idServicio, idTurno, Fecha, Tematica, EdadACumplir, TipoComida, NinosAdicionales, Anticipo, Total, status',$dataBase->getConnection());
        }

        function ProgramarFiesta($fiesta):array{

            $HS = new HijoService();
            $SS = new ServiciosService();

            $stm =  $this-> DbConection->prepare("insert into fiestas(idServicio, 
                                                                            idTurno, 
                                                                            Fecha, 
                                                                            Tematica, 
                                                                            EdadACumplir, 
                                                                            TipoComida, 
                                                                            NinosAdicionales, 
                                                                            Anticipo, 
                                                                            Total)
	                                                                 value (:idServicio, 
                                                                            :idTurno, 
                                                                            :Fecha, 
                                                                            :Tematica, 
                                                                            :EdadACumplir, 
                                                                            :TipoComida, 
                                                                            :NinosAdicionales, 
                                                                            :Anticipo,
                                                                            :Total
                                                                            );");
            $stm->bindValue(':idServicio', $fiesta["IdServicio"], PDO::PARAM_INT);
            $stm->bindValue(':idTurno', $fiesta["IdTurno"], PDO::PARAM_INT);
            $stm->bindValue(':Fecha', $fiesta["Fecha"], PDO::PARAM_STR);
            $stm->bindValue(':Tematica', $fiesta["Tematica"], PDO::PARAM_STR);
            $stm->bindValue(':EdadACumplir', $fiesta["EdadACumplir"], PDO::PARAM_INT);
            $stm->bindValue(':TipoComida', $fiesta["TipoComida"], PDO::PARAM_STR);
            $stm->bindValue(':NinosAdicionales', $fiesta["NinosAdicionales"], PDO::PARAM_INT);
            $stm->bindValue(':Anticipo', $fiesta["Anticipo"], PDO::PARAM_STR);
            $stm->bindValue(':Total', $fiesta["Total"], PDO::PARAM_INT);
            $stm->execute();

            $query ="Select max(id) as id from fiestas;";
            $stm = $this->DbConection->prepare($query);
            $stm->execute();
            $FiestaResponse = $stm->fetchAll(PDO::FETCH_ASSOC);
            $idFiesta = $FiestaResponse[0];

            $HS->newFiestaHijo($idFiesta["id"],$fiesta["Hijo"]);

            return $FiestaResponse;

        }

        function getallFiestasActive(){
            $stm =  $this-> DbConection->prepare("Select a.id,
                                                                a.idServicio,
                                                                a.idTurno,
                                                                c.ServicioName as NombreServicio,
                                                                a.Fecha,
                                                                a.Tematica,
                                                                a.EdadACumplir,
                                                                a.TipoComida,
                                                                a.NinosAdicionales,
                                                                a.Anticipo,
                                                                a.total,
                                                                a.status 
                                                           from fiestas as a
                                                     inner join servicios as c on c.id = a.idServicio
                                                          where a.status = 1 and a.fecha > NOW() 
                                                       order by a.Fecha ;");
            $stm->execute();

            $Fiestas = $stm->fetchAll(PDO::FETCH_ASSOC);
            $errorInfo = $stm->errorInfo();
            if ($errorInfo[0] !== '00000') {
                throw new Exception("Ah ocurrido un error: ".$errorInfo[2]);
            }

            $resultados = [];

            $HS = new HijoService();
            $SS = new ServiciosService();
            $PadreS = new PadreService();

            foreach($Fiestas as $Fiesta){
                $Fiesta["Hijo"] = $HS->getHijosbyFiesta($Fiesta['id']) ;
                
                foreach($Fiesta["Hijo"] as $hijos){
                    $Fiesta["Padre"] = $PadreS->getPadresbyidfromHijos($hijos['mama'],$hijos['papa']);
                    break;
                }

                $Fiesta["Servicio"] = $SS->getById($Fiesta['idServicio'])[0];
                array_push($resultados, $Fiesta); // Agregar la Fiesta con las propiedades adicionales al nuevo array

            }

            unset($Fiesta);

            return  $resultados;
        }

        function getFechasProgramadas(){
            $stm =  $this-> DbConection->prepare("Select fecha
                                                           from fiestas as a                                                     
                                                          where fecha > NOW() and
                                                                status = 1;");
            $stm->execute();
            $fechas = $stm->fetchAll(PDO::FETCH_ASSOC);

            // Extraer solo los valores de 'fecha' en un array simple
            $fechas_solo = array_map(function($row) {
                return $row['fecha'];
            }, $fechas);

            return $fechas_solo;

        }

    }
?>
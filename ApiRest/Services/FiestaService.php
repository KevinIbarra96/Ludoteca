<?php
    require_once($ProjectPath.'/Database/conexion.php');
    require_once(__DIR__.'/Actions.php');

    class FiestaService extends Actions{

        public function __construct(){
            $dataBase = new Connection();
            //Las columnas son solo para los methodos get osease los select que traen la info de la base de datos
            parent::__construct('Fiestas','id, idHijo, idServicio, Fecha,Anticipo,Total, status',$dataBase->getConnection());
        }

        function getallFiestasActive(){
            $stm =  $this-> DbConection->prepare("Select a.id, 
                                                                a.idHijo,
                                                                b.NombreHijo as NombreHijo,
                                                                a.idServicio,
                                                                c.ServicioName as NombreServicio,
                                                                a.Fecha,
                                                                a.Anticipo,
                                                                a.total,
                                                                a.status 
                                                           from fiestas as a
                                                     inner join hijos as b on a.idHijo = b.id
                                                     inner join servicios as c on c.id = a.idServicio;
                                                          where a.status = 1 and a.fecha > NOW()");
            $stm->execute();
            return  $stm->fetchAll(PDO::FETCH_ASSOC);
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
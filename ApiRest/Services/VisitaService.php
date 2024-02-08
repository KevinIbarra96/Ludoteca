<?php
//$ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3].'/'.$pt[4];
$ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3];
    
    require_once($ProjectPath.'/Database/conexion.php');
    require_once(__DIR__.'/Actions.php');


    class VisitaService extends Actions{

        public function __construct(){
            $database = new Connection();
            parent::__construct('visitas','Hijo,Servicio,Productos,HoraEntrada,HoraSalida,Oferta, status',$database->getConnection());
        }

    }
?>
<?php
    
    require_once(__DIR__.'/Actions.php');

    class VisitaService extends Actions{

        public function __construct(PDO $Conection){
            parent::__construct('visitas','Hijo,Servicio,Productos,HoraEntrada,HoraSalida,Oferta, status',$Conection);
        }

    }
?>
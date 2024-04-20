<?php
    require_once($ProjectPath.'/Database/conexion.php');
    require_once(__DIR__.'/Actions.php');

    class GafeteService extends Actions{

        public function __construct(){
            $dataBase = new Connection();
            //Las columnas son solo para los methodos get osease los select que traen la info de la base de datos
            parent::__construct('gafetes','id, Numero, Asignado, status',$dataBase->getConnection());
        }

        public function getGafeteNoAsignado(){
            $stm = $this->DbConection->prepare("select id,
                                                       Numero,
                                                       Asignado
                                                  from gafetes
                                                 where Asignado = 0;");
            $stm->execute();
            return $stm->fetchAll(PDO::FETCH_ASSOC);
        }

        public function updateAsAsignado($idGafete){
            $stm = $this->DbConection->prepare("update gafetes set Asignado = 1 where id=:idGafete");
            $stm->bindValue(':idGafete', $idGafete, PDO::PARAM_INT);
            $stm->execute();
        }

        public function updateAsNotAsignado($idGafete){
            $stm = $this->DbConection->prepare("update gafetes set Asignado = 0 where id=:idGafete");
            $stm->bindValue(':idGafete', $idGafete, PDO::PARAM_INT);
            $stm->execute();
        }

    }
?>
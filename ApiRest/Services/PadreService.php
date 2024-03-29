<?php

require_once($ProjectPath.'/Database/conexion.php');
require_once(__DIR__.'/Actions.php');

    class PadreService extends Actions{

        public function __construct(){
            $database = new Connection();
            parent::__construct('padres','PadreName, Address, Telefono, status',$database->getConnection());
        }

        function getPadreByPhone($_phone){
            $stm = $this->DbConection->prepare("select id,
                                                       PadreName,
                                                       Address,
                                                       Telefono
                                                  from padres 
                                                 where Telefono = :Telefono");

            $stm->bindValue(':Telefono', $_phone, PDO::PARAM_INT);            
            $stm->execute();
            $errorInfo = $stm->errorInfo();
            if ($errorInfo[0] !== '00000') {
                throw new Exception("Ah ocurrido un error: ".$errorInfo[2]);
            }
            return $stm->fetchAll(PDO::FETCH_ASSOC);
        }

        function getPadresbyidfromHijos($IdMama,$IdPapa){
            $stm = $this->DbConection->prepare("SELECT id,
                                                       PadreName,
                                                       Address,
                                                       Telefono
                                                  FROM padres
                                                 WHERE id IN (:papa, :mama)
                                                   AND status = 1;");
            $stm->bindValue(':mama', $IdPapa, PDO::PARAM_INT);
            $stm->bindValue(':papa', $IdMama, PDO::PARAM_INT);
            $stm->execute();
            $errorInfo = $stm->errorInfo();
            if ($errorInfo[0] !== '00000') {
                throw new Exception("Ah ocurrido un error: ".$errorInfo[2]);
            }

            return $stm->fetchAll(PDO::FETCH_ASSOC);
    }

    }
?>
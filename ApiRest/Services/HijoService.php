<?php
    require_once($ProjectPath.'/Database/conexion.php');
    require_once(__DIR__.'/Actions.php');

    class HijoService extends Actions {
        public function __construct(){
            $database = new Connection();
            parent::__construct('hijos','NombreHijo,Papa,Mama,fechaNac',$database->getConnection());
        }

        function newVisitaHijo($idVisita,$Hijos){
            $x = 0;
            $query = "";
            
            foreach($Hijos as $_hijo){
                $query .= "insert into visita_hijo (id_Visita,
                                                    id_Hijo) value (:id_Visita{$x},
                                                                    :id_Hijo{$x});";
                $x +=1;
            }

            $x = 0;
            $stm =  $this-> DbConection->prepare($query);
            foreach($Hijos as $_hijo){                
                $stm->bindValue(":id_Visita{$x}", $idVisita, PDO::PARAM_INT);
                $stm->bindValue(":id_Hijo{$x}", $_hijo["id"], PDO::PARAM_INT);
                $x +=1;
            }
            $stm->execute();
        }

        function newFiestaHijo($idFiesta,$Hijos){
            $x = 0;
            $query = "";
            
            foreach($Hijos as $_hijo){
                $query .= "insert into fiesta_hijo (id_Fiesta,
                                                    id_Hijo) value (:id_Fiesta{$x},
                                                                    :id_Hijo{$x});";
                $x +=1;
            }

            $x = 0;
            $stm =  $this-> DbConection->prepare($query);
            foreach($Hijos as $_hijo){                
                $stm->bindValue(":id_Fiesta{$x}", $idFiesta, PDO::PARAM_INT);
                $stm->bindValue(":id_Hijo{$x}", $_hijo["id"], PDO::PARAM_INT);
                $x +=1;
            }
            $stm->execute();
        }

        function getHijoByPadreId($idPadre){
            $stm = $this->DbConection->prepare("select id,
                                                       NombreHijo,
                                                       Papa,
                                                       Mama,
                                                       fechaNac
                                                  from hijos
                                                 where Papa = :idPadre or 
                                                       Mama = :idPadre;");
            $stm->bindValue(':idPadre', $idPadre, PDO::PARAM_INT);
            $stm->execute();
            $errorInfo = $stm->errorInfo();
            if ($errorInfo[0] !== '00000') {
                throw new Exception("Ah ocurrido un error: ".$errorInfo[2]);
            }

            return $stm->fetchAll(PDO::FETCH_ASSOC);
        }
        
        function getHijosbyVisita($idVisita){
            $stm = $this->DbConection->prepare("select b.id,
                                                       b.NombreHijo,
                                                       b.papa,
                                                       b.mama,
                                                       b.fechaNac
                                                  from visita_hijo as a
                                            inner join hijos as b on b.id = a.id_Hijo
                                                 where a.id_Visita = :idvisita;");
            $stm->bindValue(':idvisita', $idVisita, PDO::PARAM_INT);
            $stm->execute();
            $errorInfo = $stm->errorInfo();
            if ($errorInfo[0] !== '00000') {
                throw new Exception("Ah ocurrido un error: ".$errorInfo[2]);
            }

            return $stm->fetchAll(PDO::FETCH_ASSOC);
        }

        function getHijosbyFiesta($idFiesta){
            $stm = $this->DbConection->prepare("SELECT b.id,
                                                              b.NombreHijo,
                                                              b.papa,
                                                              b.mama,
                                                              b.fechaNac
                                                         FROM fiesta_hijo as a
                                                   inner join hijos as b on a.id_Hijo = b.id
                                                        where id_fiesta = :idFiesta;");
            $stm->bindValue(':idFiesta', $idFiesta, PDO::PARAM_INT);
            $stm->execute();
            $errorInfo = $stm->errorInfo();
            if ($errorInfo[0] !== '00000') {
                throw new Exception("Ah ocurrido un error: ".$errorInfo[2]);
            }

            return $stm->fetchAll(PDO::FETCH_ASSOC);
        }
    }

?>
<?php
        
    require_once($ProjectPath.'/Database/conexion.php');
    require_once(__DIR__.'/Actions.php');

    class ServiciosService extends Actions{


        public function __construct(){
            $dataBase = new Connection();
            //Las columnas son solo para los methodos get osease los select que traen la info de la base de datos
            parent::__construct('servicios','id, ServicioName, Descripcion, Precio, Tiempo,IdTipoServicio',$dataBase->getConnection());
        }

        function newVisitaServicios($idVisita,$Servicios){
            $x = 0;
            $query = "";
            
            foreach($Servicios as $_serv){
                $query .= "insert into visita_servicios (Visita_Id, 
                                                        Servicio_Id, 
                                                        Servicio_Precio) 
                                                        value (:Visita_Id{$x}, 
                                                                :Servicio_Id{$x}, 
                                                                :Servicio_Precio{$x});";
                $x +=1;
            }
            
            $x = 0;
            $stm =  $this-> DbConection->prepare($query);
            foreach($Servicios as $_serv){                
                $stm->bindValue(":Visita_Id{$x}", $idVisita, PDO::PARAM_INT);
                $stm->bindValue(":Servicio_Id{$x}", $_serv["Servicio_Id"], PDO::PARAM_INT);
                $stm->bindValue(":Servicio_Precio{$x}", $_serv["Servicio_Precio"], PDO::PARAM_INT);
                $x +=1;
            }
            $stm->execute();
        }

        function setNewPrecio($id,$Precio){
            $stm = $this->DbConection->prepare("update servicios set Precio = $Precio where id = $id");
            $stm->execute();
        }

        function getAllServiceByEachVisit($IdVisita){
            $stm = $this->DbConection->prepare("select a.Servicio_Id,
                                                       a.Servicio_Precio,
                                                       b.ServicioName,
                                                       b.Tiempo
                                                  from visita_servicios as a
                                            inner join servicios as b on b.id = a.Servicio_id
                                                 where a.Visita_Id = :idvisita;");
            $stm->bindValue(':idvisita', $IdVisita, PDO::PARAM_INT);
            $stm->execute();
            $errorInfo = $stm->errorInfo();
            if ($errorInfo[0] !== '00000') {
                throw new Exception("Ah ocurrido un error: ".$errorInfo[2]);
            }

            return $stm->fetchAll(PDO::FETCH_ASSOC);
        }

    }
?>
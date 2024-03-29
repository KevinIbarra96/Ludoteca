<?php
//$ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3].'/'.$pt[4];
$ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3];

//echo $ProjectPath;

require_once($ProjectPath.'/Database/conexion.php');
require_once(__DIR__.'/Actions.php');
require_once($ProjectPath.'/Models/ResponseModel.php');

    class UserService extends Actions{
        
        public function __construct(){
            $database = new Connection();
            parent::__construct('users','UserName, Password, idRol, status',$database->getConnection());
        }

        function LoginService($userName,$pass){
            try{
                $Response = new ResponseModel();
                $query = "SELECT u.id, u.UserName, u.Password, u.idRol, u.status, r.RolName
                FROM users u
                INNER JOIN rol r ON u.idRol= r.Id                
                WHERE u.UserName = :userName";
                $stmt = $this->DbConection->prepare($query);
                $stmt->bindParam(':userName', $userName, PDO::PARAM_STR);
                $stmt->execute();

                $userData = $stmt->fetchAll(PDO::FETCH_ASSOC);
                
                //Si userData es vacía entonces el usuario es incorrecto, por que no existe el usuario                
                if ($userData==null) {
                    $Response-> Rmessage = "Usuario incorrecto";
                    return $Response;
                }
                if ($userData[0]['status'] == 0) {
                    $Response-> Rmessage = "El usuario {$userName} está inhabilitado";
                    return $Response;
                }
                if ($userData[0]['Password'] != $pass) {
                    $Response-> Rmessage ="Contraseña incorrecta";
                    return $Response;
                }
                
            $Response-> Rmessage = "Usuario {$userData[0]['UserName']} conectado correctamente";
            $Response-> Rbody    = $userData;
            return $Response;
            }catch(Exception $ex) {
                $Response -> Rmessage = $ex->getMessage() ;
                $Response -> Rbody = [];
                return $Response;
            }
            }
           
        }
        

    
?>
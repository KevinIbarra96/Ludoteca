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
                $query = "SELECT * FROM users WHERE UserName = :userName";
                $stmt = $this->DbConection->prepare($query);
                $stmt->bindParam(':userName', $userName, PDO::PARAM_STR);
                $stmt->execute();

                $userData = $stmt->fetch(PDO::FETCH_ASSOC);

                if(!$userData){
                    throw new Exception("Usuario no encontrado");
                }
                if ($userData['Password'] !== $pass) {
                    throw new Exception("Contraseña incorrecta");
                }
                
                // Usuario y contraseña coinciden
                return "Usuario conectado";
                } catch(Exception $ex) {
                // Manejo de errores
                throw  $ex;
                }

            }
        }

    
?>
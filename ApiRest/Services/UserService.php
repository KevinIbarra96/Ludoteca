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
                $query = "SELECT id, UserName, Password, status FROM users WHERE UserName = :userName";
                $stmt = $this->DbConection->prepare($query);
                $stmt->bindParam(':userName', $userName, PDO::PARAM_STR);
                $stmt->execute();

                $userData = $stmt->fetch(PDO::FETCH_ASSOC);

                if (!$userData) {
                    return "Usuario incorrecto";
                }
                if ($userData['status'] == 0) {
                    return"El usuario '{$userName}' está inhabilitado";
                }
                if ($userData['Password'] !== $pass) {
                    return"Contraseña incorrecta";
                }
            // Usuario conectado correctamente
            return "Usuario '{$userData['UserName']}' conectado correctamente";
            }catch(Exception $ex) {
                throw $ex;
            }
            }
        }

    
?>
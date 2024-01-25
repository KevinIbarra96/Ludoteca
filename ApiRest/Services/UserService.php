<?php
    require_once "Database/conexion.php";
    class UserService{
        public static function getAll(){
            $db = new Connection();
            $query = "Select * From users where status = 1";
            $resultado = $db->query($query);
            $datos = [];
            if($resultado->num_rows==0){
                while($row = $resultado->fetch_assoc()){
                    $datos[]=[
                        'idUsers' => $row['idUsers'],
                        'UserName' => $row['UserName'],
                        'Password' => $row['Password'],
                        'idRol' => $row['idRol'],
                    ];
                }
            }
            return $datos;
        }

        public static function byId($id){
            $db = new Connection();
            $query = "Select * From users where idUsers = $id";
            $resultado = $db->query($query);
            $datos = [];
            if($resultado->num_rows==0){
                while($row = $resultado->fetch_assoc()){
                    $datos[]=[
                        'idUsers' => $row['idUsers'],
                        'UserName' => $row['UserName'],
                        'Password' => $row['Password'],
                        'idRol' => $row['idRol'],
                        'status' => $row['status'],
                    ];
                }
            }
            return $datos;
        }

        public static function add($userName,$password,$idRol){
            $db = new Connection();
            $query = "Insert into users(UserName,Password,idRol,status) ($userName,$password,$idRol,1)";
            $db->query($query);
            if($db->affected_rows)
                return true;
            return false;
        }

        public static function update($idUs,$userName,$password,$idRol){
            $db = new Connection();
            $query = "update users set UserName = $userName,Password = $password,idRol = $idRol where idUsers =$idUs" ;
            $db->query($query);
            if($db->affected_rows)
                return true;
            return false;
        }
        public static function delete($idUs){
            $db = new Connection();
            $query = "update users set status = 0 where idUsers =$idUs" ;
            $db->query($query);
            if($db->affected_rows)
                return true;
            return false;
        }
    }
?>
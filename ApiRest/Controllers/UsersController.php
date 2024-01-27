<?php

    require_once(__DIR__."/services/UserService.php");    

    class usersController{        

        public function home(){
            $userService = new UserService();
            echo 'User Controller Home';
        }

        public function getAllUsers(){            
            echo 'GetAllUsers';
        }

        public function getUserById(){            
            echo 'getUserById';
        }
        public function addNewUser(){
            echo 'addNewUser';
        }
        public function edditUser(){
            echo 'edditUser';
        }
        public function deleteUser(){
            echo 'deleteUser';
        }
    }
?>
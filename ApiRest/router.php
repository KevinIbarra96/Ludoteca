<?php
    class Router{
        private $controller;
        private $method;



        public function __construct(){
            $this->mathcRoute();
        }

        public function mathcRoute(){
            $url = explode('/', URL);

            $this->controller = !empty($url[1]) ? $url[1]:'Users';
            $this->method = !empty($url[2]) ? $url[2] : 'home';

            $this->controller = $this->controller .'Controller';
            echo __DIR__.'/Controllers/'.$this->controller.'.php';

            require_once(__DIR__.'/Controllers/'.$this->controller.'.php');

        }
        public function run(){
            $controller = new $this->controller();
            $method = $this->method;
            $controller->$method();
        }
    }

?>
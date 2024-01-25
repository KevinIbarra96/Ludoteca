<?php

require_once "config.php";

/*$conexion = new mysqli(DB_SERVER,DB_SERVER_USERNAME,DB_SERVER_PASSWORD,DB_DATABASE,DB_PORT);

if(!$conexion){
	echo "Error de Conexion";
}*/

class Connection extends mysqli {


	function __construct(){
		parent:: __construct(DB_SERVER,DB_SERVER_USERNAME,DB_SERVER_PASSWORD,DB_DATABASE,DB_PORT);
		$this->set_charset('utf8');
		$this->connect_error == null ? 'Conexion Existosa a la DB' : die('Error al conectarse a la DB');
	}
}

?>

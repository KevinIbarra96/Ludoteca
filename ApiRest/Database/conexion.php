<?php

require_once "config.php";

/*class Connection extends mysqli {


	public function __construct(){
		parent:: __construct(DB_SERVER,DB_SERVER_USERNAME,DB_SERVER_PASSWORD,DB_DATABASE,DB_PORT);
		$this->set_charset('utf8');
		$this->connect_error == null ? 'Conexion Existosa a la DB' : die('Error al conectarse a la DB');
	}
}*/

	class Connection{

		private $Conection;

		public function __construct(){
			$options = [
				PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION,
				PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC
			];

			$this->Conection = new PDO("mysql:host=".DB_SERVER.";port=".DB_PORT.";dbname=".DB_DATABASE,DB_SERVER_USERNAME,DB_SERVER_PASSWORD);
			$this->Conection->exec("SET CHARACTER SET UTF8");
		}
		
		public function getConnection(){
			return $this->Conection;
		}

		public function closeConection(){
			$this->Conection = null;
		}

	}

?>

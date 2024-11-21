<?php

require_once $ProjectPath."/Database/config.php";

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

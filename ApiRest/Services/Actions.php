<?php
    //Class which handle all commun action for each services
    Class Actions{
        protected $id;
        protected $tableName;
        protected $DbConection;
        protected $columns;

        public function __construct($id,$tableName,$columns,PDO $dbCoection){
            $this->id= $id;
            $this->tableName = $tableName;
            $this->DbConection = $dbCoection;
            $this->columns = $columns;
        }

        public function getAll(){
            $stm = $this->DbConection->prepare("Select {$this->columns} from {$this->tableName} where status = 1");
            $stm->execute();
            return $stm->fetchAll(PDO::FETCH_ASSOC);
        }
        public function getById($idget){
            echo $idget;
            $stm = $this->DbConection->prepare("Select {$this->columns} from {$this->tableName} where status = 1 and id = $idget");
            $stm->execute();
            return $stm->fetchAll(PDO::FETCH_ASSOC);
        }
    }
?>
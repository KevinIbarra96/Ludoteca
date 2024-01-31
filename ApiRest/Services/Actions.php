<?php
    //Class which handle all commun action for each services
    Class Actions{
        protected $tableName;
        protected $DbConection;
        protected $columns;

        public function __construct($tableName,$columns,PDO $dbCoection){
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
            $stm = $this->DbConection->prepare("Select {$this->columns} from {$this->tableName} where status = 1 and id = $idget");
            $stm->execute();
            return $stm->fetchAll(PDO::FETCH_ASSOC);
        }
        public function delete($idget){
            $stm = $this->DbConection->prepare("update users set status = 0 where id = $idget");
            $stm->execute();
            return $stm->fetchAll(PDO::FETCH_ASSOC);
        }
        public function update($idget,$data){
            $query = "update {$this->tableName} set ";
            foreach($data as $column => $value){
                $query .= "{$column} = :{$column},";
            }
            $query = trim($query,',');
            $query .= "=status = 1 where id = $idget";
            $stm = $this->DbConection->prepare($query);
            foreach($data as $column => $value){
                $stm->bindValue(":{$column}", $value);
            }
            $stm->execute();
        }
        public function new($data){
            $query ="insert into {$this->tableName} (";
            foreach($data as $column => $value){
                $query .= "$column,";
            }
            $query = trim($query,',');
            $query .=") values (";

            foreach($data as $column => $value){
                $query .= ":$column,";
            }
            $query = trim($query,',');
            $query .=")";

            //echo $query;
            $stm = $this->DbConection->prepare($query);
            foreach($data as $column => $value){
                $stm->bindValue(":{$column}", $value);
            }
            $stm->execute();
        }
    }
?>
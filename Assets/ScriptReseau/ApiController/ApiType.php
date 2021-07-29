<?php

    require_once __DIR__.'./../Database/Database.php';

    class ApiType
    {
        private $dbInstance;

        public function __construct()
        {
            $this->dbInstance = Database::getInstance();
        }

        public function getOne(array $options = null)
        {
            $pdo = $this->dbInstance->getPdo();

            $pdo->prepare();
        }

        public function getAll(string $table, array $columns = null, array $params = null)
        {
            $select = $this->getColumns($columns);
            $table = " FROM $table";
            $where = $this->getParams($params);
        }

        /**
         * @param array|null $columns
         * @return string
         */
        private function getColumns(array $columns = null): string
        {
            $select = 'SELECT';
            if ($columns != null)
            {

                // Select some columns
                foreach ($columns as $value)
                {
                    $select .= " $value";
                }
            }
            else
            {
                // Select all columns
                $select = "$select *";
            }
            return $select;
        }

        /**
         * @param array|null $params
         * @return string
         */
        private function getParams(array $params = null): string
        {
            $param = null;

            if ($params != null);
            {
                $param = 'WHERE';
                foreach ($params as $key => $value)
                {
                    $param .= " $key = ?";
                }
            }
            return $param;
        }
    }
<?php

    class Database
    {
        private $PDOInstance;
        private static $instance = null;

        const DEFAULT_SQL_USER = 'root';

        const DEFAULT_SQL_HOST = 'localhost';

        const DEFAULT_SQL_PASS = '';

        const DEFAULT_SQL_DB = 'projectAnnual';

        public function __construct()
        {
            $this->PDOInstance = new PDO('mysql:dbname='.self::DEFAULT_SQL_DB.';host='.self::DEFAULT_SQL_HOST,
                                self::DEFAULT_SQL_USER,
                                self::DEFAULT_SQL_PASS);
        }

        public static function getInstance()
        {
            if (is_null(self::$instance))
            {
                $newInstance = __CLASS__;
                self::$instance = new $newInstance;
            }
            return self::$instance;
        }

        public function __clone()
        {
            throw new Exception('Cannot clone this object');
        }

        public function getPdo()
        {
            return $this->PDOInstance;
        }
    }
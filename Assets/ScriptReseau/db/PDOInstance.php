<?php

namespace database;

use PDO;

class PDOInstance extends PDO
{
    private static $instance = null;

    public function __construct($path, $name, $password = null) {
        parent::__construct($path, $name, $password);
    }

    public static function getInstance() {
        if (is_null(self::$instance)){
            self::$instance = new PDOInstance('mysql:host=localhost;dbname=projetannuel', 'root');
        }
        return self::$instance;
    }
}
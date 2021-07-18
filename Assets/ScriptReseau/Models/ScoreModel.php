<?php

namespace Models;

use database\PDOInstance;

require_once './db/PDOInstance.php';

class ScoreModel
{
    private $pdo;

    public function __construct()
    {
        $this->pdo = PDOInstance::getInstance();
    }
}
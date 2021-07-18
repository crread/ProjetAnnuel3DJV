<?php

namespace Controllers;

require_once './ScoreController.php';
require_once './MapController.php';
require_once './UserController.php';

class PutController extends ControllerCore
{
    public function __construct($request)
    {
        parent::__construct($request);
    }
}
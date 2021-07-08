<?php

use Controllers\GetController;
use Controllers\PostController;

require_once './Controllers/GetController.php';
require_once './Controllers/PostController.php';

$controller = null;

switch($_SERVER['REQUEST_METHOD'])
{
    case 'POST':
        $controller = new PostController($_REQUEST);
        break;
    case 'GET':
        $controller = new GetController($_REQUEST);
        break;
    default:
        break;
}

$controller->loadModel();
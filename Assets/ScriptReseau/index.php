<?php

use Controllers\GetController;
use Controllers\PostController;

require_once './Controllers/GetController.php';
require_once './Controllers/PostController.php';

$controller = null;

function neutralizeFieldsFromClients(array $fields)
{
    foreach ($fields as $key => $value)
    {
        if ($key != "password") {
            $fields[$key] = htmlspecialchars($value);
        }
    }
    return $fields;
}

$_GET = neutralizeFieldsFromClients($_GET);
$_POST = neutralizeFieldsFromClients($_POST);

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
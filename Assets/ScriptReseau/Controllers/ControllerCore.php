<?php

namespace Controllers;

require_once "MapController.php";
require_once "ScoreController.php";
require_once "UserController.php";

class ControllerCore
{
    protected $dataToReturn;
    protected $request;
    protected $post;
    protected $get;
    protected $model;
    protected $controller;

    public function __construct($request)
    {
        $this->request = $request;
        $this->dataToReturn = array();

        $this->get = $_GET;
        $this->post = $_POST;
    }

    protected function redirectionWithUrl()
    {
        if (isset($this->get['entity']) && !empty($this->get['entity']))
        {
            switch($this->get['entity'])
            {
                case 'user':
                    $this->controller = new UserController($this->request);
                    break;
                case 'map':
                    $this->controller = new MapController($this->request);
                    break;
                case 'score':
//                    $this->controller = new ScoreController($this->request);
                    break;
                default:
                    return false;
            }
        }
        return true;
    }

    protected function errorRequest(array $errorData)
    {
        foreach ($errorData as $key => $value) {
            $this->dataToReturn[$key] = $value;
        }
    }

    protected function returnRequest()
    {
        http_response_code($this->dataToReturn['httpCode']);

        header("Content-Type: application/json");
        header("Access-Control-Allow-Origin: *");
        header("Access-Control-Allow-Methods: POST, GET");

        header("application/json");
        echo json_encode($this->dataToReturn);
    }
}
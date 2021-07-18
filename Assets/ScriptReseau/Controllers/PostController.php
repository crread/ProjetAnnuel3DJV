<?php

namespace Controllers;

require_once "ControllerCore.php";

require_once "MapController.php";
require_once "ScoreController.php";
require_once "UserController.php";

class PostController extends ControllerCore
{
    public function __construct($request)
    {
        parent::__construct($request);
    }

    public function loadModel()
    {
        if ($this->redirectionWithUrl())
        {
            switch($this->get['type'])
            {
                case 'create':
                    if ($this->get['entity'] == 'user') {
                        $this->dataToReturn = $this->controller->createUser();
                    } else if ($this->get['entity'] == 'map') {
                        $this->dataToReturn = $this->controller->createMap();
                    } else if ($this->get['entity'] == 'score') {
                        $this->dataToReturn = $this->controller->createScore();
                    }
                    break;
                case 'get':
                    if ($this->get['entity'] == 'user') {
                        $this->dataToReturn = $this->controller->getUser();
                    } else if ($this->get['entity'] == 'map') {
                        $this->dataToReturn = $this->controller->getMap();
                    } else if ($this->get['entity'] == 'score') {
                        $this->dataToReturn = $this->controller->getScore();
                    }
                    break;
                case 'update':
                    if ($this->get['entity'] == 'user') {
                        $this->dataToReturn = $this->controller->updateUser();
                    } else if ($this->get['entity'] == 'map') {
                        $this->dataToReturn = $this->controller->updateMap();
                    } else if ($this->get['entity'] == 'score') {
                        $this->dataToReturn = $this->controller->updateScore();
                    }
                    break;
                default:
                    $this->errorRequest(array(
                        'httpCode' => 400,
                        'message' => "Cannot find that data",
                    ));
                    break;
            }
        }
        else
        {
            $this->errorRequest(array(
                'httpCode' => 404,
                'message' => "Cannot find this",
            ));
        }

        $this->returnRequest();
    }
}
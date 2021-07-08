<?php

namespace Controllers;

require_once "ControllerCore.php";

require_once "MapController.php";
require_once "ScoreController.php";
require_once "UserController.php";

class GetController extends ControllerCore
{
    public function __construct($request)
    {
        parent::__construct($request);
    }

    public function loadModel()
    {
        if ($this->redirectionWithUrl())
        {
            switch($this->get['entity'])
            {
                case 'user':
                    $this->dataToReturn = $this->controller->getUser();
                    break;
                case 'score':
                    $this->dataToReturn = $this->controller->getMap();
                    break;
                case 'map':
                    $this->dataToReturn = $this->controller->getScore();
                    break;
                default:
                    $this->errorRequest(array(
                        'errorCode' => 400,
                        'messageError' => "Cannot find that data",
                    ));
                    break;
            }
        }
        else
        {
            $this->errorRequest(array(
                'errorCode' => 404,
                'messageError' => "Cannot find this",
            ));
        }

        $this->returnRequest();
    }
}
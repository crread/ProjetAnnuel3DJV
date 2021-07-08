<?php

namespace Controllers;

use Models\MapModel;

require_once "ControllerCore.php";

require_once './Models/MapModel.php';

class MapController extends ControllerCore
{
    const URL_UPLOAD_REPO = "./../uploads/maps/";

    public function __construct($request)
    {
        parent::__construct($request);
        $this->model = new MapModel();
    }

    public function getMap()
    {
        $responseModel = $this->model->getMap($this->post);

        if ($responseModel != null)
        {
            $this->dataToReturn['email'] = $responseModel['email'];
            $this->dataToReturn['name'] = $responseModel['name'];
        }
        else
        {
            $this->errorRequest(array(
                'errorCode' => 404,
                'messageError' => "This map doesn't exist"
            ));
        }

        return $this->dataToReturn;
    }

    public function createMap()
    {
        print_r($_FILES);

        $responseModel = $this->model->createMap($this->post);

        if ($responseModel != null)
        {
            $this->dataToReturn['email'] = $responseModel['email'];
            $this->dataToReturn['name'] = $responseModel['name'];
        }
        else
        {
            $this->errorRequest(array(
                'errorCode' => 500,
                'messageError' => "cannot create this"
            ));
        }
    }
}
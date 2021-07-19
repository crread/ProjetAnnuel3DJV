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
            $this->dataToReturn['httpCode'] = 200;
            $this->dataToReturn['message'] = "map created successfully";
        }
        else
        {
            $this->errorRequest(array(
                'httpCode' => 404,
                'message' => "This map doesn't exist"
            ));
        }

        return $this->dataToReturn;
    }

    public function createMap()
    {
        $responseModel = $this->model->createMap($this->post);

        if ($responseModel != null)
        {
            $this->dataToReturn['httpCode'] = 200;
            $this->dataToReturn['message'] = "map created successfully";
        }
        else
        {
            $this->errorRequest(array(
                'httpCode' => 500,
                'message' => "cannot create this"
            ));
        }
    }
}
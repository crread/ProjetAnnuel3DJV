<?php


namespace Controllers;

use Models\UserModel;

require_once "ControllerCore.php";

require_once './Models/UserModel.php';

class UserController extends ControllerCore
{
    public function __construct($request)
    {
        parent::__construct($request);
        $this->model = new UserModel();
    }

    public function getUser()
    {
        $responseModel = $this->model->getUser($this->post);

        if ($responseModel != null)
        {
            $this->dataToReturn['email'] = $responseModel['email'];
            $this->dataToReturn['name'] = $responseModel['name'];
        }
        else
        {
            $this->errorRequest(array(
                'errorCode' => 404,
                'messageError' => "This user doesn't exist"
            ));
        }

        return $this->dataToReturn;
    }

    public function createUser()
    {
        $responseModel = $this->model->createUser($this->post);

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
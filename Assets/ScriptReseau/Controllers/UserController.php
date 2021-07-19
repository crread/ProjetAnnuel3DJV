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

        if ($responseModel != null && password_verify($this->post["password"], $responseModel["password"]))
        {
            $this->dataToReturn['email'] = $responseModel['email'];
            $this->dataToReturn['name'] = $responseModel['name'];
            $this->dataToReturn['httpCode'] = 200;
            $this->dataToReturn['message'] = "User found";
        }
        else
        {
            $this->errorRequest(array(
                'httpCode' => 404,
                'message' => "error happened, try again please"
            ));
        }

        return $this->dataToReturn;
    }

    public function createUser()
    {
        $responseModel = $this->model->createUser($this->post);

        if ($responseModel != null)
        {
            if ($responseModel != "Already exist")
            {
                $this->dataToReturn['email'] = $responseModel['email'];
                $this->dataToReturn['name'] = $responseModel['name'];
                $this->dataToReturn['httpCode'] = 200;
                $this->dataToReturn['message'] = "Created successfully";
            }
            else
            {
                $this->errorRequest(array(
                    'httpCode' => 500,
                    'message' => "Already exist"
                ));
            }
        }
        else
        {
            $this->errorRequest(array(
                'httpCode' => 500,
                'message' => "cannot create this"
            ));
        }

        return $this->dataToReturn;
    }
}
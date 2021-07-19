<?php

namespace Models;

use database\PDOInstance;

require_once './db/PDOInstance.php';

class UserModel
{
    private $pdo;

    public function __construct()
    {
        $this->pdo = PDOInstance::getInstance();
    }

    public function getUser($data)
    {
        $request = $this->pdo->prepare('SELECT email, name, password FROM user WHERE email = :email');
        $request->execute(array(':email' => $data['email']));
        return $request->fetch(PDOInstance::FETCH_ASSOC);
    }

    public function createUser($data)
    {
        if ($this->getUser($data)) {
            return "Already exist";
        }

        $data['password'] = password_hash($data['password'], PASSWORD_BCRYPT);

        $request = $this->pdo->prepare('INSERT INTO user(name, password, email) VALUES(:name, :password, :email)');
        $response = $request->execute([':email' =>$data['email'],
                           ':password' =>$data['password'],
                           ':name' => $data['name']]);

        if ($response)
        {
            return $this->getUser($data);
        }

        return null;
    }
}
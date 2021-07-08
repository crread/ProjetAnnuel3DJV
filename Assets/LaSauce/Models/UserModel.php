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
        $responses = $request->fetchAll(PDOInstance::FETCH_ASSOC);

        if (count($responses) > 0)
        {
            $password = password_hash($data['password'], PASSWORD_BCRYPT, array( 'cost' => 13));
            foreach ($responses as $response)
            {
                if (password_verify($response['password'], $password))
                {
                    return $response;
                }
            }
        }
        return null;
    }

    public function createUser($data)
    {
        $request = $this->pdo->prepare('INSERT INTO user(name, password, email) VALUES(:name, :password, :email)');
        $response = $request->execute([':email' => $data['email'],
                           ':password' => $data['password'],
                           ':name' => "lel"]);

        if ($response)
        {
            return $this->getUser($data);
        }

        return null;
    }
}
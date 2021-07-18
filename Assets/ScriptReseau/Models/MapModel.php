<?php

namespace Models;

use database\PDOInstance;

require_once './db/PDOInstance.php';

class MapModel
{
    private $pdo;

    public function __construct()
    {
        $this->pdo = PDOInstance::getInstance();
    }

    public function getMap($data)
    {
        $request = $this->pdo->prepare('SELECT map_name, FROM map WHERE map_name = :map_name');
        $request->execute(array(':map_name' => $data['email']));
        $response = $request->fetchAll(PDOInstance::FETCH_ASSOC);

        if (count($response) > 0)
        {
            return $response;
        }

        return null;
    }

    public function createMap($data)
    {
        $date = date("Y-m-d H:i:s");

        $request = $this->pdo->prepare('INSERT INTO map(description, created_at, updated_at, map_name, creator_id) 
                                              VALUES(:description, :createdAt, :updatedAt, :mapName, :creatorId)');

        $response = $request->execute([':description' => $data['description'],
                                       ':mapName' => $data['mapName'],
                                       ':createdAt' => $date,
                                       ':updatedAt' => $date,
                                       ':creatorId' => $data['userId']]);

        if ($response)
        {
            return true;
        }

        return null;
    }
}
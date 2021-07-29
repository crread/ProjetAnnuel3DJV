<?php

    require_once __DIR__.'./../ApiController/MapApi.php';

    class Router
    {
        public function __construct()
        {
        }

        public function run()
        {
            if (isset($_GET['url']) && !empty($_GET['url']))
            {
                $url = $_GET['url'];

                if ($url = "/getMaps")
                {
                    $api =  new MapApi();
                    $api->getListMap();
                }
            }
        }
    }
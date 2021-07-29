<?php

    class Map
    {
        private $id;
        private $map;
        private $thumbnail;
        private $created_at;
        private $created_by;

        /**
         * @return mixed
         */
        public function getId()
        {
            return $this->id;
        }

        /**
         * @param mixed $id
         */
        public function setId($id)
        {
            $this->id = $id;
        }

        /**
         * @return mixed
         */
        public function getMap()
        {
            return $this->map;
        }

        /**
         * @param mixed $map
         */
        public function setMap($map)
        {
            $this->map = $map;
        }

        /**
         * @return mixed
         */
        public function getCreatedAt()
        {
            return $this->created_at;
        }

        /**
         * @param mixed $created_at
         */
        public function setCreatedAt($created_at)
        {
            $this->created_at = $created_at;
        }

        /**
         * @return mixed
         */
        public function getCreatedBy()
        {
            return $this->created_by;
        }

        /**
         * @param mixed $created_by
         */
        public function setCreatedBy($created_by)
        {
            $this->created_by = $created_by;
        }

        /**
         * @return mixed
         */
        public function getThumbnail()
        {
            return $this->thumbnail;
        }

        /**
         * @param mixed $thumbnail
         */
        public function setThumbnail($thumbnail)
        {
            $this->thumbnail = $thumbnail;
        }
    }
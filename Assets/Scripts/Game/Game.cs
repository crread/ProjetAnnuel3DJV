using System;
using System.Linq;
using Game.Minions;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace Game
{
    public class Game : MonoBehaviour
    {
        public Player player;
        public GameObject prefabFlag;
        public Camera raycastCamera;
        public CanvasManager canvasManager;
        public GameObject menuCanvas;
        public float timerInSeconds;

        private Flag.Flag _selectedFlag;
        private MinionSelectorField _currentMinionFieldSelected;
        private string _typeSelected = "";
        private DDOL _ddol;

        private void Start()
        {
            _ddol = GameObject.Find("Preload").GetComponent<DDOL>();
            UpdateFieldsMaximumCanvas();
        }

        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menuCanvas.SetActive(!menuCanvas.activeInHierarchy);
                Time.timeScale = menuCanvas.activeInHierarchy ? 0 : 1;
            }
            
            if (timerInSeconds > 0)
            {
                timerInSeconds -= Time.deltaTime;
                canvasManager.DisplayTimer(timerInSeconds);
            }
            else
            {
                timerInSeconds = 0;
                EndGame(false);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    if (canvasManager.fireFieldFlag.gameObject.activeInHierarchy)
                    {
                        canvasManager.FieldSelected("fireFlag");
                        _currentMinionFieldSelected = canvasManager.fireFieldFlag;
                        _typeSelected = "fireFlag";
                    }
                }
                else
                {
                    canvasManager.FieldSelected("fire");
                    _currentMinionFieldSelected = canvasManager.fireField;
                    _typeSelected = "fire";
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    if (canvasManager.airFieldFlag.gameObject.activeInHierarchy)
                    {
                        canvasManager.FieldSelected("airFlag");
                        _currentMinionFieldSelected = canvasManager.airFieldFlag;
                        _typeSelected = "airFlag";
                    }
                }
                else
                {
                    canvasManager.FieldSelected("air");
                    _currentMinionFieldSelected = canvasManager.airField;
                    _typeSelected = "air";
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    if (canvasManager.waterFieldFlag.gameObject.activeInHierarchy)
                    {
                        canvasManager.FieldSelected("waterFlag");
                        _currentMinionFieldSelected = canvasManager.waterFieldFlag;
                        _typeSelected = "waterFlag";
                    }
                }
                else
                {
                    canvasManager.FieldSelected("water");
                    _currentMinionFieldSelected = canvasManager.waterField;
                    _typeSelected = "water";
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    if (canvasManager.earthFieldFlag.gameObject.activeInHierarchy)
                    {
                        canvasManager.FieldSelected("earthFlag");
                        _currentMinionFieldSelected = canvasManager.earthFieldFlag;
                        _typeSelected = "earthFlag";
                    }
                }
                else
                {
                    canvasManager.FieldSelected("earth");
                    _currentMinionFieldSelected = canvasManager.earthField;
                    _typeSelected = "earth";
                }
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (_currentMinionFieldSelected)
                {
                    var currentMaximumMinionsFollowing = GetMaximumFollowingMinionsByType();
                    _currentMinionFieldSelected.selectedMinionsField.text =
                        currentMaximumMinionsFollowing.ToString();
                }
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (_currentMinionFieldSelected)
                {
                    var currentMaximumMinionsFollowing = GetMaximumFollowingMinionsByType() / 2;
                    _currentMinionFieldSelected.selectedMinionsField.text =
                        currentMaximumMinionsFollowing.ToString();
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_currentMinionFieldSelected)
                {
                    var currentValueSelected = Int32.Parse(_currentMinionFieldSelected.selectedMinionsField.text);
                    var currentMaximumMinionsFollowing = GetMaximumFollowingMinionsByType();

                    if (currentValueSelected < currentMaximumMinionsFollowing)
                    {
                        currentValueSelected += 1;
                        _currentMinionFieldSelected.selectedMinionsField.text = currentValueSelected.ToString();
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (_currentMinionFieldSelected)
                {
                    var currentValue = Int32.Parse(_currentMinionFieldSelected.selectedMinionsField.text);

                    if (currentValue > 0)
                    {
                        currentValue -= 1;
                        _currentMinionFieldSelected.selectedMinionsField.text = currentValue.ToString();
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_selectedFlag != null)
                {
                    canvasManager.SetBackgroundFieldsToFalse();
                    _selectedFlag = null;
                    canvasManager.airFieldFlag.gameObject.SetActive(false);
                    canvasManager.earthFieldFlag.gameObject.SetActive(false);
                    canvasManager.fireFieldFlag.gameObject.SetActive(false);
                    canvasManager.waterFieldFlag.gameObject.SetActive(false);
                }
            }

            if (Input.GetMouseButton(0))
            {
                var ray = raycastCamera.ScreenPointToRay(Input.mousePosition);
                var layerMask = 1 << 12;
                layerMask = ~layerMask;
                Physics.Raycast(ray, out var hit, float.MaxValue, layerMask);

                if (hit.transform && hit.transform.gameObject.layer == 13)
                {
                    _selectedFlag = hit.transform.gameObject.GetComponent<Flag.Flag>();
                    UpdateFieldsFlagMaximumCanvas(_selectedFlag);

                    canvasManager.airFieldFlag.gameObject.SetActive(true);
                    canvasManager.earthFieldFlag.gameObject.SetActive(true);
                    canvasManager.fireFieldFlag.gameObject.SetActive(true);
                    canvasManager.waterFieldFlag.gameObject.SetActive(true);

                    UpdateFieldsMaximumCanvas();
                }
                else if (hit.transform && hit.transform.gameObject.layer == 9)
                {
                    player.GetComponent<NavMeshAgent>().destination = hit.point;
                }
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (_selectedFlag == null)
                {
                    var airMinionsSelected = Int32.Parse(canvasManager.airField.selectedMinionsField.text);
                    var waterMinionsSelected = Int32.Parse(canvasManager.waterField.selectedMinionsField.text);
                    var fireMinionsSelected = Int32.Parse(canvasManager.fireField.selectedMinionsField.text);
                    var earthMinionsSelected = Int32.Parse(canvasManager.earthField.selectedMinionsField.text);
                    var totalMinionsSelected = airMinionsSelected + waterMinionsSelected + fireMinionsSelected +
                                               earthMinionsSelected;

                    if (totalMinionsSelected > 0)
                    {
                        Vector3 position = Vector3.negativeInfinity;

                        var ray = raycastCamera.ScreenPointToRay(Input.mousePosition);
                        var layerMask = 1 << 12;
                        layerMask = ~layerMask;
                        Physics.Raycast(ray, out var hit, float.MaxValue, layerMask);

                        if (hit.transform.gameObject.layer == 9)
                        {
                            position = hit.point;
                        }

                        if (position != Vector3.negativeInfinity)
                        {
                            Collider[] listCollider = Physics.OverlapSphere(player.playerTransform.position, 100,
                                LayerMask.GetMask("Minion"));
                            position.y += 1;
                            GameObject newFlag = Instantiate(prefabFlag, position, Quaternion.identity);
                            Flag.Flag flagScript = newFlag.GetComponent<Flag.Flag>();

                            var minions = listCollider
                                .Where(minion =>
                                    minion.GetComponent<Minion>().instanceIdObjectToFollow == player.currentId)
                                .ToArray();

                            player.earthMinionsFollowing -= earthMinionsSelected;
                            player.fireMinionsFollowing -= fireMinionsSelected;
                            player.airMinionsFollowing -= airMinionsSelected;
                            player.waterMinionsFollowing -= waterMinionsSelected;

                            flagScript.currentId = newFlag.GetInstanceID();

                            foreach (var minion in minions)
                            {
                                var minionScript = minion.GetComponent<Minion>();
                                switch (minionScript.typeMinion)
                                {
                                    case "fire":
                                        if (fireMinionsSelected > 0)
                                        {
                                            fireMinionsSelected -= 1;
                                            minionScript.SetPositionObjectToFollow(flagScript.currentId,
                                                newFlag.transform);
                                            flagScript.fireMinionsFollowing += 1;
                                            totalMinionsSelected -= 1;
                                        }

                                        break;
                                    case "air":
                                        if (airMinionsSelected > 0)
                                        {
                                            airMinionsSelected -= 1;
                                            minionScript.SetPositionObjectToFollow(flagScript.currentId,
                                                newFlag.transform);
                                            flagScript.airMinionsFollowing += 1;
                                            totalMinionsSelected -= 1;
                                        }

                                        break;
                                    case "earth":
                                        if (earthMinionsSelected > 0)
                                        {
                                            earthMinionsSelected -= 1;
                                            minionScript.SetPositionObjectToFollow(flagScript.currentId,
                                                newFlag.transform);
                                            flagScript.earthMinionsFollowing += 1;
                                            totalMinionsSelected -= 1;
                                        }

                                        break;
                                    case "water":
                                        if (waterMinionsSelected > 0)
                                        {
                                            waterMinionsSelected -= 1;
                                            minionScript.SetPositionObjectToFollow(flagScript.currentId,
                                                newFlag.transform);
                                            flagScript.waterMinionsFollowing += 1;
                                            totalMinionsSelected -= 1;
                                        }

                                        break;
                                }

                                if (totalMinionsSelected <= 0)
                                {
                                    break;
                                }
                            }

                            UpdateFieldsMaximumCanvas();
                        }
                    }
                }
                else
                {
                    var airMinionsSelected = Int32.Parse(canvasManager.airField.selectedMinionsField.text);
                    var waterMinionsSelected = Int32.Parse(canvasManager.waterField.selectedMinionsField.text);
                    var fireMinionsSelected = Int32.Parse(canvasManager.fireField.selectedMinionsField.text);
                    var earthMinionsSelected = Int32.Parse(canvasManager.earthField.selectedMinionsField.text);
                    var totalMinionsSelected = airMinionsSelected + waterMinionsSelected + fireMinionsSelected +
                                               earthMinionsSelected;

                    if (totalMinionsSelected > 0)
                    {
                        Collider[] listCollider = Physics.OverlapSphere(player.playerTransform.position, 40,
                            LayerMask.GetMask("Minion"));
                        Flag.Flag flagScript = _selectedFlag.GetComponent<Flag.Flag>();

                        var minions = listCollider
                            .Where(minion =>
                                minion.GetComponent<Minion>().instanceIdObjectToFollow == player.currentId)
                            .ToArray();

                        player.earthMinionsFollowing -= earthMinionsSelected;
                        player.fireMinionsFollowing -= fireMinionsSelected;
                        player.airMinionsFollowing -= airMinionsSelected;
                        player.waterMinionsFollowing -= waterMinionsSelected;

                        foreach (var minion in minions)
                        {
                            var minionScript = minion.GetComponent<Minion>();
                            switch (minionScript.typeMinion)
                            {
                                case "fire":
                                    if (fireMinionsSelected > 0)
                                    {
                                        fireMinionsSelected -= 1;
                                        minionScript.SetPositionObjectToFollow(flagScript.currentId,
                                            _selectedFlag.transform);
                                        flagScript.fireMinionsFollowing += 1;
                                        totalMinionsSelected -= 1;
                                    }

                                    break;
                                case "air":
                                    if (airMinionsSelected > 0)
                                    {
                                        airMinionsSelected -= 1;
                                        minionScript.SetPositionObjectToFollow(flagScript.currentId,
                                            _selectedFlag.transform);
                                        flagScript.airMinionsFollowing += 1;
                                        totalMinionsSelected -= 1;
                                    }

                                    break;
                                case "earth":
                                    if (earthMinionsSelected > 0)
                                    {
                                        earthMinionsSelected -= 1;
                                        minionScript.SetPositionObjectToFollow(flagScript.currentId,
                                            _selectedFlag.transform);
                                        flagScript.earthMinionsFollowing += 1;
                                        totalMinionsSelected -= 1;
                                    }

                                    break;
                                case "water":
                                    if (waterMinionsSelected > 0)
                                    {
                                        waterMinionsSelected -= 1;
                                        minionScript.SetPositionObjectToFollow(flagScript.currentId,
                                            _selectedFlag.transform);
                                        flagScript.waterMinionsFollowing += 1;
                                        totalMinionsSelected -= 1;
                                    }

                                    break;
                            }
                        }
                    }

                    var airMinionsSelectedFromFlag =
                        Int32.Parse(canvasManager.airFieldFlag.selectedMinionsField.text);
                    var waterMinionsSelectedFromFlag =
                        Int32.Parse(canvasManager.waterFieldFlag.selectedMinionsField.text);
                    var fireMinionsSelectedFromFlag =
                        Int32.Parse(canvasManager.fireFieldFlag.selectedMinionsField.text);
                    var earthMinionsSelectedFromFlag =
                        Int32.Parse(canvasManager.earthFieldFlag.selectedMinionsField.text);
                    var totalMinionsSelectedFromFlag = airMinionsSelectedFromFlag + waterMinionsSelectedFromFlag +
                                                       fireMinionsSelectedFromFlag + earthMinionsSelectedFromFlag;

                    if (totalMinionsSelectedFromFlag > 0)
                    {
                        Collider[] listCollider = Physics.OverlapSphere(_selectedFlag.transform.position, 40,
                            LayerMask.GetMask("Minion"));

                        var minions = listCollider
                            .Where(minion =>
                                minion.GetComponent<Minion>().instanceIdObjectToFollow == _selectedFlag.currentId)
                            .ToArray();

                        player.earthMinionsFollowing += earthMinionsSelectedFromFlag;
                        player.fireMinionsFollowing += fireMinionsSelectedFromFlag;
                        player.airMinionsFollowing += airMinionsSelectedFromFlag;
                        player.waterMinionsFollowing += waterMinionsSelectedFromFlag;

                        foreach (var minion in minions)
                        {
                            var minionScript = minion.GetComponent<Minion>();
                            switch (minionScript.typeMinion)
                            {
                                case "fire":
                                    if (fireMinionsSelectedFromFlag > 0)
                                    {
                                        fireMinionsSelectedFromFlag -= 1;
                                        minionScript.SetPositionObjectToFollow(player.currentId,
                                            player.playerTransform);
                                        totalMinionsSelectedFromFlag -= 1;
                                    }

                                    break;
                                case "air":
                                    if (airMinionsSelectedFromFlag > 0)
                                    {
                                        airMinionsSelectedFromFlag -= 1;
                                        minionScript.SetPositionObjectToFollow(player.currentId,
                                            player.playerTransform);
                                        totalMinionsSelectedFromFlag -= 1;
                                    }

                                    break;
                                case "earth":
                                    if (earthMinionsSelectedFromFlag > 0)
                                    {
                                        earthMinionsSelectedFromFlag -= 1;
                                        minionScript.SetPositionObjectToFollow(player.currentId,
                                            player.playerTransform);
                                        totalMinionsSelectedFromFlag -= 1;
                                    }

                                    break;
                                case "water":
                                    if (waterMinionsSelectedFromFlag > 0)
                                    {
                                        waterMinionsSelectedFromFlag -= 1;
                                        minionScript.SetPositionObjectToFollow(player.currentId,
                                            player.playerTransform);
                                        totalMinionsSelectedFromFlag -= 1;
                                    }

                                    break;
                            }

                            if (totalMinionsSelectedFromFlag <= 0)
                            {
                                break;
                            }
                        }

                        canvasManager.SetBackgroundFieldsToFalse();
                        canvasManager.airFieldFlag.gameObject.SetActive(false);
                        canvasManager.earthFieldFlag.gameObject.SetActive(false);
                        canvasManager.fireFieldFlag.gameObject.SetActive(false);
                        canvasManager.waterFieldFlag.gameObject.SetActive(false);
                        _selectedFlag = null;
                        UpdateFieldsMaximumCanvas();
                    }
                }
            }

            MakeMinionsFollowPlayer();

        }

        /// <summary>
        /// return maximum minions of a type following player of a flag
        /// </summary>
        /// <returns>minionsQuantity</returns>
        private int GetMaximumFollowingMinionsByType()
        {
            var minionsQuantity = 0;

            switch (_typeSelected)
            {
                case "fire":
                    minionsQuantity = player.fireMinionsFollowing;
                    break;
                case "air":
                    minionsQuantity = player.airMinionsFollowing;
                    break;
                case "earth":
                    minionsQuantity = player.earthMinionsFollowing;
                    break;
                case "water":
                    minionsQuantity = player.waterMinionsFollowing;
                    break;
                case "fireFlag":
                    minionsQuantity = _selectedFlag.fireMinionsFollowing;
                    break;
                case "airFlag":
                    minionsQuantity = _selectedFlag.airMinionsFollowing;
                    break;
                case "earthFlag":
                    minionsQuantity = _selectedFlag.earthMinionsFollowing;
                    break;
                case "waterFlag":
                    minionsQuantity = _selectedFlag.waterMinionsFollowing;
                    break;
            }

            return minionsQuantity;
        }

        /// <summary>
        /// Control if minions are around the player and make them follow him if space key has been tapped
        /// </summary>
        private void MakeMinionsFollowPlayer()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var position = player.playerTransform.position;
                player.ResetMaxFollowing();
                Collider[] listCollider = Physics.OverlapSphere(position, 30, LayerMask.GetMask("Minion"));
                foreach (var minion in listCollider)
                {
                    var minionScript = minion.GetComponent<Minion>();
                    minionScript.SetPositionObjectToFollow(player.currentId, player.playerTransform);
                    player.AddMinions(minionScript.typeMinion);
                }

                UpdateFieldsMaximumCanvas();
            }
        }

        public void UpdateFieldsMaximumCanvas()
        {
            canvasManager.earthField.followingMinionsField.text = player.earthMinionsFollowing.ToString();
            canvasManager.fireField.followingMinionsField.text = player.fireMinionsFollowing.ToString();
            canvasManager.airField.followingMinionsField.text = player.airMinionsFollowing.ToString();
            canvasManager.waterField.followingMinionsField.text = player.waterMinionsFollowing.ToString();

            ControlMaximumSelectField();
        }

        public void UpdateFieldsFlagMaximumCanvas(Flag.Flag flagScript)
        {
            canvasManager.airFieldFlag.followingMinionsField.text = flagScript.airMinionsFollowing.ToString();
            canvasManager.waterFieldFlag.followingMinionsField.text = flagScript.waterMinionsFollowing.ToString();
            canvasManager.earthFieldFlag.followingMinionsField.text = flagScript.earthMinionsFollowing.ToString();
            canvasManager.fireFieldFlag.followingMinionsField.text = flagScript.fireMinionsFollowing.ToString();
        }

        private void ControlMaximumSelectField()
        {
            if (player.airMinionsFollowing < Int32.Parse(canvasManager.airField.selectedMinionsField.text))
            {
                canvasManager.airField.selectedMinionsField.text = player.airMinionsFollowing.ToString();
            }

            if (player.waterMinionsFollowing < Int32.Parse(canvasManager.waterField.selectedMinionsField.text))
            {
                canvasManager.waterField.selectedMinionsField.text = player.waterMinionsFollowing.ToString();
            }

            if (player.earthMinionsFollowing < Int32.Parse(canvasManager.earthField.selectedMinionsField.text))
            {
                canvasManager.earthField.selectedMinionsField.text = player.earthMinionsFollowing.ToString();
            }

            if (player.fireMinionsFollowing < Int32.Parse(canvasManager.fireField.selectedMinionsField.text))
            {
                canvasManager.fireField.selectedMinionsField.text = player.fireMinionsFollowing.ToString();
            }
        }

        public void RemoveMinionFromFlag(Flag.Flag flag, string typeMinion)
        {
            switch (typeMinion)
            {
                case "fire":
                    flag.fireMinionsFollowing -= 1;
                    break;
                case "water":
                    flag.waterMinionsFollowing -= 1;
                    break;
                case "air":
                    flag.airMinionsFollowing -= 1;
                    break;
                case "earth":
                    flag.earthMinionsFollowing -= 1;
                    break;
            }

            CheckFlagMustBeDestroyed(flag);
        }

        private void CheckFlagMustBeDestroyed(Flag.Flag flagScript)
        {
            if (flagScript.fireMinionsFollowing == 0 &&
                flagScript.earthMinionsFollowing == 0 &&
                flagScript.waterMinionsFollowing == 0 &&
                flagScript.airMinionsFollowing == 0)
            {
                Destroy(flagScript.gameObject);
            }
        }
        
        public void EndGame(bool isVictory)
        {
            _ddol.gameData.isVictory = isVictory;
            _ddol.gameData.timer = timerInSeconds;
            _ddol.SetLastSceneNamePlayed(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("EndGameMenu");
        }
    }
}
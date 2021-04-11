using System;
using System.Collections.Generic;
using System.Linq;
using Game.Minions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class Game : MonoBehaviour
    {
        public Player player;
        public GameObject prefabFlag;
        public List<Collider> groundCollider = new List<Collider>();
        public Camera raycastCamera;
        public CanvasManager canvasManager;
        public float timerInSeconds;

        private MinionSelectorField _currentMinionFieldSelected;
        private string _typeSelected = "";
        private void Start()
        {
            UpdateFieldsMaximumCanvas();
        }

        private void Update()
        {
            if (timerInSeconds > 0)
            {
                timerInSeconds -= Time.deltaTime;
                canvasManager.DisplayTimer(timerInSeconds);
            }
            else
            {
                timerInSeconds = 0;
                SceneManager.LoadScene("LoseMenu");
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                canvasManager.FieldSelected("fire");
                _currentMinionFieldSelected = canvasManager.fireField;
                _typeSelected = "fire";
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                canvasManager.FieldSelected("air");
                _currentMinionFieldSelected = canvasManager.airField;
                _typeSelected = "air";
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                canvasManager.FieldSelected("water");
                _currentMinionFieldSelected = canvasManager.waterField;
                _typeSelected = "water";
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                canvasManager.FieldSelected("earth");
                _currentMinionFieldSelected = canvasManager.earthField;
                _typeSelected = "earth";
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (_currentMinionFieldSelected)
                {
                    var currentMaximumMinionsFollowing= GetMaximumFollowingMinionsByType();
                    _currentMinionFieldSelected.selectedMinionsField.text = currentMaximumMinionsFollowing.ToString();
                }
            }
            
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (_currentMinionFieldSelected)
                {
                    var currentMaximumMinionsFollowing= GetMaximumFollowingMinionsByType() / 2;
                    _currentMinionFieldSelected.selectedMinionsField.text = currentMaximumMinionsFollowing.ToString();
                }
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_currentMinionFieldSelected)
                {
                    var currentValueSelected = Int32.Parse(_currentMinionFieldSelected.selectedMinionsField.text);
                    var currentMaximumMinionsFollowing= GetMaximumFollowingMinionsByType();
                    
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

            if (Input.GetMouseButton(0))
            {
                var ray = raycastCamera.ScreenPointToRay(Input.mousePosition);
                foreach (var ground in groundCollider)
                {
                    if (ground.Raycast(ray, out var hit, float.MaxValue))
                    {
                        player.targetAgent.SetDestination(hit.point);
                        break;
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                Collider[] listCollider = Physics.OverlapSphere(player.playerTransform.position, 40, LayerMask.GetMask("Minion"));
                
                var minions = listCollider
                    .Where(minion => minion.GetComponent<Minion>().typeMinion == "air")
                    .Where(minion => minion.GetComponent<Minion>().instanceIdObjectToFollow == player.currentId)
                    .Take(40)
                    .ToArray();

                foreach (var minion in minions)
                {
                    var minionScript = minion.GetComponent<Minion>();
                    minion.GetComponent<Transform>().localScale = new Vector3(2, 2, 2);
                    minionScript.instanceIdObjectToFollow = 0;
                    minionScript.objectToFollow = null;
                    player.MinusMinions(minionScript.typeMinion);
                }
                UpdateFieldsMaximumCanvas();
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
                Collider[] listCollider = Physics.OverlapSphere(position, 18, LayerMask.GetMask("Minion"));
                foreach (var minion in listCollider)
                {
                    var minionScript = minion.GetComponent<Minion>();
                    minionScript.ChangePosition(player.playerTransform);
                    minionScript.instanceIdObjectToFollow = player.currentId;
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
        
        private void ControlMaximumSelectField()
        {
            var maximum = 0;
            var currentlySelected = 0;
            
            maximum = Int32.Parse(canvasManager.airField.selectedMinionsField.text);
            currentlySelected = player.airMinionsFollowing;
            if (currentlySelected < maximum)
            {
                canvasManager.airField.selectedMinionsField.text = currentlySelected.ToString();
            }
            
            maximum = Int32.Parse(canvasManager.waterField.selectedMinionsField.text);
            currentlySelected = player.waterMinionsFollowing;
            if (currentlySelected < maximum)
            {
                canvasManager.waterField.selectedMinionsField.text = currentlySelected.ToString();
            }
            
            maximum = Int32.Parse(canvasManager.earthField.selectedMinionsField.text);
            currentlySelected = player.earthMinionsFollowing;
            if (currentlySelected < maximum)
            {
                canvasManager.earthField.selectedMinionsField.text = currentlySelected.ToString();
            }
            
            maximum = Int32.Parse(canvasManager.fireField.selectedMinionsField.text);
            currentlySelected = player.fireMinionsFollowing;
            if (currentlySelected < maximum)
            {
                canvasManager.fireField.selectedMinionsField.text = currentlySelected.ToString();
            }
        }
    }
}

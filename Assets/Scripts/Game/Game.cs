﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Game
{
    public class Game : MonoBehaviour
    {
        public Player player;
        public GameObject minionCanvasSelections;
        public GameObject prefabFlag;
        public List<Collider> groundCollider = new List<Collider>();
        public Camera raycastCamera;
        public InputField airInput;
        public InputField earthInput;
        public InputField waterInput;
        public InputField fireInput;
        public Text timerText;
        public float timerInSeconds = 180;
        
        private bool _putFlag = false;
        private readonly List<Flag.Flag> _flagsList = new List<Flag.Flag>();
        private int _timerMinutesLeft;
        private int _timerSecondsLeft;

        private void Update()
        {
            if (timerInSeconds > 0)
            {
                timerInSeconds -= Time.deltaTime;
                DisplayTimer();
            }
            else
            {
                timerInSeconds = 0;
                SceneManager.LoadScene("LoseMenu");
            }
            
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                player.UpdateMoveOption(true);
                player.UpdateFieldText();
                minionCanvasSelections.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Escape) && minionCanvasSelections && minionCanvasSelections.activeSelf)
            {
                minionCanvasSelections.SetActive(false);
                player.UpdateMoveOption(false);
            }

            if (Input.GetMouseButton(0) && _putFlag)
            {
                var ray = raycastCamera.ScreenPointToRay(Input.mousePosition);
                foreach (var ground in groundCollider)
                {
                    if (ground.Raycast(ray, out var hit, float.MaxValue))
                    {
                        GameObject newFlag = Instantiate(prefabFlag, hit.point, Quaternion.identity);
                        newFlag.GetComponent<global::Game.Flag.Flag>().SetMinionsOnFlag(player.GetMinionsListBufferForFlag());
                        player.ClearMinionForFlagBuffer(newFlag);
                        _flagsList.Add(newFlag.GetComponent<global::Game.Flag.Flag>());
                        player.UpdateMoveOption(false);
                        _putFlag = false;
                        break;
                    }
                }
            }
        }

        private void DisplayTimer()
        {
            _timerMinutesLeft = Mathf.CeilToInt(timerInSeconds / 60) - 1 < 0 ? 0 : Mathf.CeilToInt(timerInSeconds / 60) - 1;
            _timerSecondsLeft = Mathf.CeilToInt(timerInSeconds % 60);
            timerText.text = $"{_timerMinutesLeft:00}:{_timerSecondsLeft:00}";
        }
        public List<global::Game.Flag.Flag> GetFlagList()
        {
            return _flagsList;
        }
        public void ValidationInput()
        {
            minionCanvasSelections.SetActive(false);

            var minionsSelected = new Dictionary<string, int>
            {
                {"air", int.Parse(airInput.text)},
                {"water", int.Parse(waterInput.text)},
                {"fire", int.Parse(fireInput.text)},
                {"earth", int.Parse(earthInput.text)}
            };
            player.LoadMinionBuffer(minionsSelected);
            minionsSelected.Clear();
            _putFlag = true;
        }
    }
}
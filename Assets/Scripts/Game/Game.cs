using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Game : MonoBehaviour
    {
        public Player player;
        public GameObject minionCanvasSelections;
        public GameObject prefabFlag;
        public Collider groundCollider;
        public Camera raycastCamera;
        public InputField airInput;
        public InputField earthInput;
        public InputField waterInput;
        public InputField fireInput;

        private bool _putFlag = false;
        private List<global::Game.Flag.Flag> _flagsList = new List<global::Game.Flag.Flag>();

        private void Update()
        {
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

                if (groundCollider.Raycast(ray, out var hit, float.MaxValue))
                {
                    GameObject newFlag = Instantiate(prefabFlag, hit.point, Quaternion.identity);
                    newFlag.GetComponent<global::Game.Flag.Flag>().SetMinionsOnFlag(player.GetMinionsListBufferForFlag());
                    player.ClearMinionForFlagBuffer(newFlag);
                    _flagsList.Add(newFlag.GetComponent<global::Game.Flag.Flag>());
                    player.UpdateMoveOption(false);
                    _putFlag = false;
                }
            }
        }

        public List<global::Game.Flag.Flag> GetFlagList()
        {
            return _flagsList;
        }
        /**
    * !TODO make a control for inputs before to catch them
     * this part control if input data can be convert in int or not (don't used yet, must be implemented in reste of the code)
    */
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

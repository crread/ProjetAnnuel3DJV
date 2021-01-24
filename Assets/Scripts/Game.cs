using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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
    private List<GameObject> _flagsList = new List<GameObject>();

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
        }

        if (Input.GetMouseButton(0) && _putFlag)
        {
            var ray = raycastCamera.ScreenPointToRay(Input.mousePosition);

            if (groundCollider.Raycast(ray, out var hit, float.MaxValue))
            {
                GameObject newFlag = Instantiate(prefabFlag, hit.point, Quaternion.identity);
                newFlag.GetComponent<Flag>().SetMinionsOnFlag(player.GetMinionsListBufferForFlag());
                player.ClearMinionForFlagBuffer(newFlag);
                player.UpdateMoveOption(false);
                _putFlag = false;
            }
        }
    }
    /**
    * !TODO make a control for inputs before to catch them
    */
    public void ValidationInput()
    {
        minionCanvasSelections.SetActive(false);

        Dictionary<string, int> minionsSelected = new Dictionary<string, int>();
        minionsSelected.Add("air", int.Parse(airInput.text));
        minionsSelected.Add("water", int.Parse(fireInput.text));
        minionsSelected.Add("fire", int.Parse(waterInput.text));
        minionsSelected.Add("earth", int.Parse(earthInput.text));
        player.LoadMinionBuffer(minionsSelected);
        minionsSelected = null;
        _putFlag = true;
    }
}

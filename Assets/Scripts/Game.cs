using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Player player;
    public GameObject minionCanvasSelections;
    public InputField airInput;
    public InputField earthInput;
    public InputField waterInput;
    public InputField fireInput;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            player.UpdateMoveOption(true);
            minionCanvasSelections.SetActive(true);
        }
    }
    /**
    * !TODO make a control for inputs before to catch them
    * !TODO and call loadMinionBuffer function
    */
    public void ValidationInput()
    {
        minionCanvasSelections.SetActive(false);
        player.UpdateMoveOption(false);
        
        var minionsAirNumbers = int.Parse(airInput.text);
        var minionsFireNumbers = int.Parse(fireInput.text);
        var minionsWaterNumbers = int.Parse(waterInput.text);
        var minionsEarthNumbers = int.Parse(earthInput.text);

        player.LoadMinionBuffer(minionsWaterNumbers, minionsAirNumbers, minionsEarthNumbers, minionsFireNumbers);
        //player.UpdateMoveOption(false);
    }
}

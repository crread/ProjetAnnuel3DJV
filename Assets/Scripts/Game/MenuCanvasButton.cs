using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCanvasButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Text text;
    public GameObject menuCanvas;
    public enum ListOfInteraction {Quit, Replay, Continu};
    public ListOfInteraction buttonType;

    private Color _initColor;
    
    private void Start()
    {
        _initColor = text.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ResetColor();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ResetColor();
        switch (buttonType)
        {
            case ListOfInteraction.Replay:
                RemoveCanvasMenuGame();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            case ListOfInteraction.Continu:
                RemoveCanvasMenuGame();
                break;
            case ListOfInteraction.Quit :
                RemoveCanvasMenuGame();
                SceneManager.LoadScene("mainMenu");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void RemoveCanvasMenuGame()
    {
        menuCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    
    private void ResetColor()
    {
        text.color = _initColor;
    }
}

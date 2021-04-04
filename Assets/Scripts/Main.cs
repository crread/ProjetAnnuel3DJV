using UnityEngine;

public class Main : MonoBehaviour
{
    private DDOL _ddol;
    public GameObject mainMenuCanvas;
    public GameObject loginCanvas;
    private void Start()
    {
        GameObject preload = GameObject.Find("Preload");
        _ddol = preload.GetComponent<DDOL>();
        
        if (_ddol.networkManager.isNetworkAvailable)
        {
            loginCanvas.SetActive(true);
            _ddol.isLoaded = true;
        }
        else
        { 
            mainMenuCanvas.SetActive(true);
        }
    }
}

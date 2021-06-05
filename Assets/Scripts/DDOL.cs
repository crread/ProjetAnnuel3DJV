using Entity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour
{
    public struct GameData
    {
        public bool isVictory;
        public float timer;
    }

    public NetworkManager networkManager;
    public bool isLoaded = false;
    public ResponseRequestEntity responseRequest;
    public PlayerEntity player;
    public GameData gameData = new GameData();

    private string _lastSceneNamePlayed;
    
    private void Awake()
    {
        player = new PlayerEntity();
        responseRequest = new ResponseRequestEntity();

        DontDestroyOnLoad(this);

        if (networkManager == null)
        {
            networkManager = gameObject.GetComponent<NetworkManager>();
        }
    }

    private void Start()
    {
        if (!isLoaded)
        {
            SceneManager.LoadScene("mainMenu");
        }
    }

    public string GetLastSceneNamePlayed()
    {
        return _lastSceneNamePlayed;
    }
    
    public void SetLastSceneNamePlayed(string lastSceneNamePlayed)
    {
        _lastSceneNamePlayed = lastSceneNamePlayed;
    }
}

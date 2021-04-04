using Classes;
using Entity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour
{
    public NetworkManager networkManager;
    public bool isLoaded = false;
    public PlayerEntity player;
    public ResponseRequestEntity responseRequest;
    private void Awake()
    {
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
}

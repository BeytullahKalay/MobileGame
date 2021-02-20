using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector2 lastCheckPointPos;

    [HideInInspector] public bool _gameStarted;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
            Destroy(gameObject);

        lastCheckPointPos.x = PlayerPrefs.GetFloat("PosX");
        lastCheckPointPos.y = PlayerPrefs.GetFloat("PosY");
    }

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex == 2)
        {
            _gameStarted = true;
        }
    }
}

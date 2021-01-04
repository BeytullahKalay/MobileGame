using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector2 lastCheckPointPos;

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
}

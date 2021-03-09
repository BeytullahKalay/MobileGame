using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private GameMaster gm;
    public Transform startPos;
    public GameObject ContinueButton;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void Update()
    {
        if (gm._gameStarted)
            ContinueButton.SetActive(true);
        else
            ContinueButton.SetActive(false);
    }

    public void PlayGame() //NewGame
    {
        PlayerPrefs.SetInt("GameStarted", 1);
        PlayerPrefs.SetInt("AttackAbilityOpen",0);
        PlayerPrefs.SetInt("BoxAbilityOpen", 0); //Closing box ability for first enterence
        PlayerPrefs.SetInt("DashAbilityOpen", 0); //Closing dash ability for first enterence
        PlayerPrefs.SetInt("info", 0); // movement tutorial
        PlayerPrefs.SetInt("boxInfo",0); // box ability tutorial
        PlayerPrefs.SetInt("dashInfo",0); // dash ability tutorial
        PlayerPrefs.SetInt("attackInfo",0); // attack ability tutorial
        PlayerPrefs.SetInt("CutScene2Collider",0); // can pass level collider activated

        gm.lastCheckPointPos = startPos.position; //Setting the player position for first entering
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loading next scene
    }

    public void LoadGame() //Continue
    {
        SceneManager.LoadScene("Scenes/Game"); //loading game scene
        Vector2 startPos;
        startPos = new Vector2(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"));
        gm.lastCheckPointPos = startPos;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
}

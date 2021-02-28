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
        PlayerPrefs.SetInt("info", 0); //Show info first Time
        PlayerPrefs.SetInt("BoxAbilityOpen", 0); //Closing box ability for first enterence
        PlayerPrefs.SetInt("DashAbilityOpen", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loading next scene
        gm.lastCheckPointPos = startPos.position;
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

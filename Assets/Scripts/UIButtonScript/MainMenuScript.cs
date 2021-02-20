using System.Collections;
using System.Collections.Generic;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private GameMaster gm;
    public Transform startPos;
    private Vector2 startPosVec;
    public GameObject ContinueButton;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        startPosVec = startPos.position;

        gm.lastCheckPointPos.x = PlayerPrefs.GetFloat("PosX");
        gm.lastCheckPointPos.y = PlayerPrefs.GetFloat("PosY");
    }

    private void Update()
    {
        Debug.Log(PlayerPrefs.GetFloat("PosX"));
        Debug.Log(PlayerPrefs.GetFloat("PosY"));

        if (gm.lastCheckPointPos == startPosVec || gm.lastCheckPointPos == new Vector2(0,0))
        {
            ContinueButton.SetActive(false);
        }
        else
            ContinueButton.SetActive(true);
    }

    public void PlayGame() //NewGame
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loading next scene
        Vector2 startPos;
        startPos = new Vector2(-18.63f, -1.92f); //first check point pos
        gm.lastCheckPointPos = startPos;

        Debug.Log(PlayerPrefs.GetFloat("PosX"));
        Debug.Log(PlayerPrefs.GetFloat("PosY"));
    }

    public void LoadGame() //Continue
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loading next scene
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

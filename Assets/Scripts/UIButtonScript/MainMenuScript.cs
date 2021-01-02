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
    }

    private void Update()
    {
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

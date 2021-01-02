using UnityEngine;
using UnityEngine.UI;

public class SoundButtons : MonoBehaviour
{
    public Button soundButton;
    public Button muteSoundButton;
    public AudioSource sceneMusic;


    private void Start()
    {
        if (PlayerPrefs.GetInt("soundMuted") == 1)
            muteSound();
        else
            unMuteSound();
    }

    public void muteSound()
    {
        Debug.Log("Sound Muted");
        soundButton.gameObject.SetActive(false);
        muteSoundButton.gameObject.SetActive(true);
        sceneMusic.mute = true;
        PlayerPrefs.SetInt("soundMuted", 1);
    }

    public void unMuteSound()
    {
        Debug.Log("Sound Unmuted");
        soundButton.gameObject.SetActive(true);
        muteSoundButton.gameObject.SetActive(false);
        sceneMusic.mute = false;
        PlayerPrefs.SetInt("soundMuted", 0);
    }
}

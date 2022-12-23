// ----------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private string _levelName;

    [SerializeField]
    protected SoundData _clip;

    private void Start()
    {
       Cursor.lockState = CursorLockMode.Confined;
    }

    public void GoMainMenu()
    {
        PlayAudio();
        SceneController.instance.ChangeScene("MainMenu");
    }

    public void Play()
    {
        PlayAudio();
        SceneController.instance.ChangeScene(_levelName);
    }

    public void Restart()
    {
        PlayAudio();
        SceneController.instance.ChangeScene(PlayerPrefs.GetString("Level"));
    }

    public void Instructions()
    {
        PlayAudio();
        SceneController.instance.ChangeScene("Instructions");
    }

    public void Options()
    {
        PlayAudio();
        SceneController.instance.ChangeScene("OptionScene");
    }

    public void Quit()
    {
        PlayAudio();
        Application.Quit();
    }

    public void Credits()
    {
        PlayAudio();
        SceneController.instance.ChangeScene("Credits");
    }

    protected void PlayAudio()
    {
        AudioManager.instance.AudioPlay(_clip);
    }
}

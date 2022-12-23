// ----------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PausedMenu : MenuController
{
    [SerializeField]
    private GameObject _pauseMenuUI;

    [SerializeField]
    private GameObject _blackPanel;

    [SerializeField]
    private GameObject _optionsPanel;

    [SerializeField]
    private GameObject _sensPanel;

    [SerializeField]
    private GameObject _volumenPanel;

    public static bool isGamePaused = false;

    [SerializeField]
    private GameObject _image;

    [SerializeField]
    private CameraController _cameraControllerRef;

    [SerializeField]
    private SoundData _pauseClip;
    
    public event Action pauseOn;
    public event Action pauseOff;

    public void Resume()
    {
        pauseOff();

        PlayAudio();
        
        Time.timeScale = 1f;
        isGamePaused = false;

        _pauseMenuUI.SetActive(false);
        _blackPanel.SetActive(false);
        _image.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        _cameraControllerRef.enabled = true;
    }

    public void Pause()
    {
        pauseOn();

        Time.timeScale = 0f;
        isGamePaused = true;

        AudioManager.instance.AudioPlay(_pauseClip);

        _pauseMenuUI.SetActive(true);
        _blackPanel.SetActive(true);
        _image.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        _cameraControllerRef.enabled = false;
    }

    public void SensOn()
    {
        PlayAudio();

        _sensPanel.SetActive(true);
    }

    public void SensOff()
    {
        PlayAudio();

        _sensPanel.SetActive(false);
    }

    public void VolumenOn()
    {
        PlayAudio();

        _volumenPanel.SetActive(true);
    }

    public void volumenOff()
    {
        PlayAudio();

        _volumenPanel.SetActive(false);
    }
}

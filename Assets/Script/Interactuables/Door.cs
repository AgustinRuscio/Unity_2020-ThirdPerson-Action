//----------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Door : MonoBehaviour, IInteractuable
{
    public int _keysRequiere;

    [SerializeField]
    private string _nextLevel;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private Light _light;

    [SerializeField]
    private SoundData _gladosClip;

    [SerializeField]
    private SoundData _doorOpenClip;

    [SerializeField]
    private SoundData _doorDeny;

    [SerializeField]
    private GameObject _letterE;

    private void Start()
    {
        ChangeColor();

        KeysManager.instance.keyCountChange += ChangeColor; 
    }

    private void OnDestroy()
    {
        KeysManager.instance.keyCountChange -= ChangeColor;
    }

    public void OnInteract()
    {
        Check();
    }

    private void OnTriggerEnter(Collider other)
    {
        _letterE.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        _letterE.SetActive(false);
    }

    private void ChangeColor()
    {
        if (_keysRequiere == KeysManager.instance.keysCount)
        {
            _light.color = Color.green;
        }
        else if (KeysManager.instance.keysCount > _keysRequiere)
        {
            _light.color = Color.yellow;

            switch (GameManager.instance._gameStatus)
            {
                case LevelDetection.Menu:
                    AudioManager.instance.AudioPlay(_gladosClip, transform.position);
                    break;
                case LevelDetection.Level:
                    break;
                case LevelDetection.Tutorial:
                    break;
            }  
        }
        else
            _light.color = Color.red;
    } 
    private void Check()
    { 
        if (KeysManager.instance.keysCount >= _keysRequiere)
        {
            PlayerPrefs.SetFloat("Timer", GameManager.instance.timer);
            _animator.SetBool("Open", true);
            AudioManager.instance.AudioPlay(_doorOpenClip, transform.position);
            StartCoroutine(ChangeLevel());
        }
        else
            AudioManager.instance.AudioPlay(_doorDeny, transform.position);
    }

    IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(3);
        SceneController.instance.ChangeScene(_nextLevel);
    }
}
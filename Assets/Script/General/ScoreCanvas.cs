//----------------------------------------------------//

//                   Ruscio Agustin                  //

//--------------------------------------------------//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCanvas : MonoBehaviour
{
    [SerializeField]
    private Text _timerText;

    [SerializeField]
    private Text _scoreTxt;

    private float _timer;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        _timer = PlayerPrefs.GetFloat("Timer");
    }

    void Start()
    {
        _timerText.text = _timer.ToString("0.00") + "s";

        if (_timer >= 75)
        {
            _scoreTxt.text = "C";
        }
        else if (_timer < 75 && _timer >= 60)
        {
            _scoreTxt.text = "B";
        }
        else if (_timer < 60 && _timer >= 30)
        {
            _scoreTxt.text = "A";
        }
        else
        {
            _scoreTxt.text = "S";
        }
    }
}
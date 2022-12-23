//----------------------------------------------------//

//                   Ruscio Agustin                  //

//--------------------------------------------------//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsCanvasController : MonoBehaviour
{
    [SerializeField]
    private GameObject _sensPanel;

    [SerializeField]
    private GameObject _audioPanel;

    public void SensitivityOn()
    {
        _sensPanel.SetActive(true);
    }

    public void SensitivityOff()
    {
        _sensPanel.SetActive(false);
    }

    public void AudioOn()
    {
        _audioPanel.SetActive(true);
    }

    public void AudioOff()
    {
        _audioPanel.SetActive(false);
    }
}

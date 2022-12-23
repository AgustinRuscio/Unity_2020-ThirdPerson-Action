//----------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntructionPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _panels;

    int _panelIndex = 0;

    [SerializeField]
    private SoundData _clip;

    public void ChangePanel()
    {
        AudioManager.instance.AudioPlay(_clip, transform.position);
        _panels[_panelIndex].SetActive(false);

        _panelIndex++;

        if (_panelIndex >= _panels.Length)
            _panelIndex = 0;

        _panels[_panelIndex].SetActive(true);
    }
}

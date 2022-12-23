//----------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastTermina : MonoBehaviour, IInteractuable
{
    [SerializeField]
    private int _keysRequire = 5;

    [SerializeField]
    private SoundData _clipDeny;

    [SerializeField]
    private SoundData _clipAccepts;

    [SerializeField]
    private GameObject _paredFinal;

    [SerializeField]
    private GameObject _eLetter;

    public void OnInteract()
    {
        WinCheck();
    }

    private void OnTriggerEnter(Collider other)
    {
        _eLetter.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        _eLetter.SetActive(false);
    }

    private void WinCheck()
    {
        if(KeysManager.instance.keysCount >= _keysRequire)
        {
            AudioManager.instance.AudioPlay(_clipAccepts, transform.position);

            _paredFinal.SetActive(false);
        }
        else
        {
            AudioManager.instance.AudioPlay(_clipDeny, transform.position);
        }
    }
}

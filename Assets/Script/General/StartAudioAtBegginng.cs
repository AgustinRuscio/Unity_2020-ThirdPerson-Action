//----------------------------------------------------//

//                   Ruscio Agustin                  //

//--------------------------------------------------//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudioAtBegginng : MonoBehaviour
{
    [SerializeField]
    private SoundData _soundData;

    [SerializeField]
    private bool _isStatic;

    void Start()
    {
        if (_isStatic)
            AudioManager.instance.AudioPlay(_soundData, gameObject.transform.position);
        else
            AudioManager.instance.AudioPlay(_soundData, gameObject.transform);
    }
}

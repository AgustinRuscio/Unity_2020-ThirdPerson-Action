//----------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class Fan : Parent_Tramps
{
    [SerializeField]
    private Vector3 _airDir;

    [SerializeField]
    private float _strength;

    [SerializeField]
    private SoundData _sound;

    protected override void Start()
    {   
        base.Start();
        AudioManager.instance.AudioPlay(_sound, transform);
    }

    private void OnTriggerStay(Collider other)
    {
        var iFanable = other.gameObject.GetComponent<IFanable>();

        if(iFanable != null)
            iFanable.OnFan(_airDir, _strength);  
    }    
}

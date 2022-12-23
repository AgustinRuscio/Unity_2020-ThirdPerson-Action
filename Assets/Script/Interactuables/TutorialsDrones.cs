//----------------------------------------------------//

//                   Ruscio Agustin                  //

//--------------------------------------------------//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialsDrones : MonoBehaviour, IInteractuable
{
    [SerializeField]
    private SoundData _sound;

    [SerializeField]
    private GameObject _letterE;

    public void OnInteract()
    {
        AudioManager.instance.AudioPlay(_sound, transform.position);        
    }

    private void OnTriggerEnter(Collider other)
    {
        _letterE.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        _letterE.SetActive(false);
    }
}

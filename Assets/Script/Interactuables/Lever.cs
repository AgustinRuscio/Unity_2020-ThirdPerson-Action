//----------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//


using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractuable
{
    [SerializeField]
    private Animator _animLever;
   
    [SerializeField]
    private MovablePlatform _deactivateTramp;

    [SerializeField]
    private Animator _platformAnimator;

    private bool actualBool;

    [SerializeField]
    private SoundData _activateClip;

    [SerializeField]
    private SoundData _desactivateClip;

    [SerializeField]
    private GameObject _letterE;

    public UnityEvent[] turnOnLever;

    public void OnInteract()
    {
         if (!actualBool)
         {
            _animLever.SetBool("Activate", true);
            _platformAnimator.enabled = true;

            for (int i = 0; i < turnOnLever.Length; i++)
            {
                turnOnLever[i].Invoke();
            }

            AudioManager.instance.AudioPlay(_activateClip, transform.position);

            actualBool = true;
         }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!actualBool)
        {
            _letterE.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _letterE.SetActive(false);
    }
}

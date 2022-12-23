//----------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Controller : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private Player _player;

    [SerializeField]
    private SoundData _footStepsUno;

    [SerializeField]
    private SoundData _footStepsDos;

    private void LateUpdate()
    {
        Run(_player._inputs.x, _player._inputs.z);

        if (_player.jumping )
        {
            JumpAnim();
            _player.jumping = false;
        }

         FallingIdle(_player.onAir);        
    }

    private void Run(float x, float z)
    {
        _animator.SetFloat("Horizontal", x);
        _animator.SetFloat("Vertical", z);
    }

    private void JumpAnim()
    {
        string parameterName = "Jump";
        _animator.SetBool("Jump", true);
        StartCoroutine(ChangeBoolParameter(parameterName));
    }

    IEnumerator ChangeBoolParameter(string parameterModificated)
    {
        yield return new WaitForSeconds(1);
        _animator.SetBool(parameterModificated, false);
    }

    private void FallingIdle(bool onAir)
    {
        _animator.SetBool("Falling", onAir);
    }

    private void FootSoundOne()
    {
        AudioManager.instance.AudioPlay(_footStepsUno, transform.position);
    }

    private void FootSoundTwo()
    {
        AudioManager.instance.AudioPlay(_footStepsDos, transform.position);
    }
}

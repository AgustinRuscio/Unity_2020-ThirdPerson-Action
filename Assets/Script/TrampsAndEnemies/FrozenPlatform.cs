//----------------------------------------------//

//                  Ruscio Agustin              //

//----------------------------------------------//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenPlatform : ParentPower
{
    private GenericTimer _activateTimer;

    [SerializeField]
    private float _coolDown;

    [SerializeField]
    private float _iceActiveTime;

    [SerializeField]
    private ParticleSystem _particles;

    private bool _active;

    [SerializeField]
    private float _speedReducer;

    [SerializeField]
    private float _timerBeenFrozened;

    private IFrozenable _currentfrozenable;

    private float isFrozen = 0;

    private void Awake()
    {
        _activateTimer = new GenericTimer(_coolDown);
    }

    void Update()
    {
        _activateTimer.RunTimer();

        if (_activateTimer.CheckCoolDown())
        {
            _audioSource.Play();

            _activateTimer.ResetTimer();
            _particles.Play();

            _active = true;

            StartCoroutine(StopFuntion());
        }
    }

    IEnumerator StopFuntion()
    {
        yield return new WaitForSeconds(_iceActiveTime);

        _audioSource.Stop();

        _particles.Stop();
        _active = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        var frozenable = other.GetComponent<IFrozenable>();

        if(frozenable != null && _active && frozenable != _currentfrozenable)
        {
            frozenable.GetFrozen(_speedReducer, _timerBeenFrozened);

            _currentfrozenable = frozenable;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var frozen = other.GetComponent<IFrozenable>();

        if (frozen == _currentfrozenable)
            _currentfrozenable = null;     
    }
}
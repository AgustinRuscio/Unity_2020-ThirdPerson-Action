//----------------------------------------------//

//                  Ruscio Agustin              //

//----------------------------------------------//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlatform : ParentPower
{
    private GenericTimer _activateTimer;

    [SerializeField]
    private float _coolDown;

    [SerializeField]
    private float _fireActiveTime;

    [SerializeField]
    private ParticleSystem _particles;

    private bool _active;

    private float _started = 0;

    [SerializeField]
    private int _damagePerSec;

    [SerializeField]
    private int fireTimes;

    [SerializeField]
    private int _timeBtwDamage;

    void Start()
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
        yield return new WaitForSeconds(_fireActiveTime);

        _audioSource.Stop();

        _particles.Stop();
        _active = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();

        if (damageable != null && _active && _started == 0)
        {
            _started++;
            StartCoroutine(StartDamage(damageable));
        }      
    }

    IEnumerator StartDamage(IDamageable damageable)
    {
        for (int i = 0; i < fireTimes; i++)
        {
            damageable.OnTakeDamage(_damagePerSec, true);
            yield return new WaitForSeconds(3);
        }

        _started = 0;
    }  
}
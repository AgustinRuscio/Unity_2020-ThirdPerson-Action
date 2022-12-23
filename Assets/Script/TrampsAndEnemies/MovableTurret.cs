//----------------------------------------------//

// Ruscio Agustin   &&     Riego Maria Mercedes //

//----------------------------------------------//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableTurret : Parent_Tramps
{
    [SerializeField]
    private int _damage;

    [SerializeField]
    private Transform _objective;

    [SerializeField]
    private float _minDistanceDtection;

    [SerializeField]
    private Transform _pivot;

    [SerializeField]
    private Transform _cañonLookAt;

    [SerializeField]
    private float _speed;

    private float _timer = 0f;

    private GenericTimer timer;

    [SerializeField]
    private float _coolDown = 2f;

    [SerializeField]
    private ParticleSystem _particles;

    [SerializeField]
    private AudioSource _audioSource;

    protected override void Start()
    {
        base.Start();
        timer = new GenericTimer(_coolDown);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, _objective.position ) < _minDistanceDtection)
        {
            LookAt();
            _particles.Play();

            if (timer.CheckCoolDown())
            {
                timer.ResetTimer();
                Shoot();
                _audioSource.Play();
            }
            else
                timer.RunTimer();
            
        }
        else
        {
            _audioSource.Stop();
            _particles.Stop();
            _cañonLookAt.localRotation = Quaternion.Euler(-60, _cañonLookAt.localRotation.y, _cañonLookAt.localRotation.z);

            //_moveThroughWayPoints.MoveMyself(this); 
        }             
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(_cañonLookAt.position, _cañonLookAt.forward, out hit, _minDistanceDtection))
        {
            var turretDamageable = hit.collider.GetComponent<ITurrentDamagable>();

            if (turretDamageable != null)
                turretDamageable.onHit(_damage);         
        }               
    }

    void LookAt()
    {
        Vector3 dir = _objective.position - _pivot.position; 
        
        dir.y = 0;

        _pivot.forward = Vector3.Slerp(_pivot.forward, dir, Time.deltaTime * _speed);
   
        _cañonLookAt.LookAt(_objective.transform.position);        
    }
}

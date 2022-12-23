using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : Parent_Tramps
{
    [SerializeField]
    private float _stopTime;

    [SerializeField]
    private int _damage;

    private GenericTimer tim;

    [SerializeField]
    private float _coolDown;

    protected override void Start()
    {
        _moveThroughWayPoints = new MoveThroughWayPoints(this, transform, _movablePlatformSpeed, _wayPoints, true).ModifyStopTime(_stopTime);
        tim = new GenericTimer(_coolDown);
    }

    private void Update()
    {
        tim.RunTimer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null && tim.CheckCoolDown()) 
        {
            tim.ResetTimer();
            damageable.OnTakeDamage(_damage, false);
        }
    }
}

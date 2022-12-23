//----------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class MovablePlatform : Parent_Tramps       
{
    [SerializeField]
    private bool _moveActive;

    [SerializeField]
    private bool _startFrombeginning;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private AudioSource _source;
    protected override void Start()
    {
        if (_startFrombeginning)
            _moveThroughWayPoints = new MoveThroughWayPoints(this, transform, _movablePlatformSpeed, _wayPoints, true).ModifyStopTime(2);
        else   
            _moveThroughWayPoints = new MoveThroughWayPoints(this, transform, _movablePlatformSpeed, _wayPoints).ModifyStopTime(2); 
    }

    public void TurnOn()
    {
        _moveThroughWayPoints.MoveMyself(this);
        _animator.enabled = true;

        _source.Play();
    }

    public void TurnOff()
    {
        _moveThroughWayPoints.StopMyself(this);
        _moveActive = false;

        _animator.enabled = false;
        _source.Stop();
    }


    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.SetParent(transform);
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.transform.SetParent(null);
    } 
}

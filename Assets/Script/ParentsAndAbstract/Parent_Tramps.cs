//----------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Parent_Tramps : MonoBehaviour
{
    protected MoveThroughWayPoints _moveThroughWayPoints;

    [SerializeField]
    protected GameObject[] _wayPoints;

    [SerializeField]
    protected float _movablePlatformSpeed;  
    
    protected virtual void Start()
    {
        _moveThroughWayPoints = new MoveThroughWayPoints(this, transform, _movablePlatformSpeed, _wayPoints, true).ModifyStopTime(0);
    }
}

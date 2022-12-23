//----------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThroughWayPoints
{
    private GameObject[] _wayPoints;

    private float _movablePlatformSpeed;

    private int _wayPointsIndex = 0;

    private Transform _platformTransform;

    public MoveThroughWayPoints(MonoBehaviour parent, Transform platformTransform, float speed, GameObject[] waypoints, bool active = false)
    {
        _platformTransform = platformTransform;
        _movablePlatformSpeed = speed;
        _wayPoints = waypoints;

        if (active)
            parent.StartCoroutine(CorutineActive(true));        
    }

    float stopTime;

    public MoveThroughWayPoints ModifyStopTime(float time)
    {
        stopTime = time;

        return this;
    }

    public MoveThroughWayPoints ModifySpeed(float speed)
    {
        _movablePlatformSpeed = speed;

        return this;
    }

    public void MoveMyself(MonoBehaviour mono)
    {
        mono.StartCoroutine(CorutineActive(true));
    }

    public void StopMyself(MonoBehaviour mono)
    {
        mono.StopCoroutine(CorutineActive(false));
    }

    IEnumerator CorutineActive(bool active)
    {
        yield return new WaitForSeconds(Random.Range(0,3));

        while (active)
        {
            if (Vector3.Distance(_platformTransform.position, _wayPoints[_wayPointsIndex].transform.position) < 0.1f)
            {
                yield return new WaitForSeconds(stopTime);

                _wayPointsIndex++;

                if (_wayPointsIndex >= _wayPoints.Length)
                    _wayPointsIndex = 0;

            }
            _platformTransform.position += (_wayPoints[_wayPointsIndex].transform.position - _platformTransform.position).normalized * _movablePlatformSpeed * Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
    }
}
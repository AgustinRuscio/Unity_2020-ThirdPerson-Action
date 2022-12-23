//----------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingDrone : MonoBehaviour
{
    private MoveThroughWayPoints _moveThroughWayPoints;

    [SerializeField]
    private GameObject[] _wayPoints;

    [SerializeField]
    private float _movablePlatformSpeed;

    [SerializeField]
    private SoundData[] _clips;

    private void Awake()
    {
        _moveThroughWayPoints = new MoveThroughWayPoints(this, transform, _movablePlatformSpeed, _wayPoints, true);      
    }

    private void Start()
    {
        int selector = Random.Range(0, _clips.Length);

        AudioManager.instance.AudioPlay(_clips[selector], transform);
    }
}

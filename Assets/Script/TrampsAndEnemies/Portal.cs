//----------------------------------------------//

// Ruscio Agustin   &&     Riego Maria Mercedes //

//----------------------------------------------//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private GameObject _otherPortal;

    [SerializeField]
    private Vector3 _offSetDistance;

    [SerializeField]
    private Vector3 _rotateOffSet;

    [Range(0, 360)]
    public int cameraRotation;

    [SerializeField]
    private SoundData _soundActive;

    [SerializeField]
    private SoundData _soundIdle;

    private void Start()
    {
        AudioManager.instance.AudioPlay(_soundIdle, transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        var portable = other.GetComponent<IPortable>();

        if (portable != null)
        {
            var portableTransform = other.GetComponent<Transform>();

            var newPosition = _otherPortal.transform.position + _offSetDistance;

            AudioManager.instance.AudioPlay(_soundActive, portableTransform.transform);

            portable.Teleport(newPosition, _rotateOffSet, cameraRotation);
        }
    }
}

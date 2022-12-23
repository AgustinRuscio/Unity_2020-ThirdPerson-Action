//----------------------------------------------------//

//                   Ruscio Agustin                  //

//--------------------------------------------------//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointRotation : MonoBehaviour
{
    [Range(0, 360)]
    public int cameraRotation;

    //public Quaternion rotation;

    public Vector3 offset;

    public Vector3 _rotation;

    [SerializeField]
    private GameObject _particles;

    private Collider _col;

    private void Awake()
    {
        _col = GetComponent<BoxCollider>();
        _particles.SetActive(false);
    }

    public void Activate()
    {
        _particles.SetActive(true);
        _col.enabled = false;
    }
}

//--------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveLogic : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _meshRenderer;

    [SerializeField]
    private float _dissolveSpeed;

    public bool disolveActivated = false;

    private float _globalTimer = 0.0f;

    public void Update()
    {
        Material[] mats = _meshRenderer.materials;
        if (disolveActivated)
        {
            mats[0].SetFloat("_Cutoff", Mathf.Sin(_globalTimer * _dissolveSpeed));
            _globalTimer += Time.deltaTime;
  
            _meshRenderer.materials = mats;
        }
        else
        {
            mats[0].SetFloat("_Cutoff", 0f);
            _globalTimer = 0.0f;
            _meshRenderer.materials = mats;
        }
    }

}

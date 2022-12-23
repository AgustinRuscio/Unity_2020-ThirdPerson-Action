//----------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Material))]
[RequireComponent(typeof(DissolveLogic))]
public class DissolveTrap : MonoBehaviour
{
    [SerializeField]
    private DissolveLogic _dissolveLogicRef;

    [SerializeField]
    private Material _originalMaterial, _damageMaterial;

    [SerializeField]
    private MeshRenderer _renderer;

    [SerializeField]
    private Collider _collider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _renderer.material = _damageMaterial;
            _dissolveLogicRef.disolveActivated = true;
            _collider.enabled = false;

            StartCoroutine(ReActivate());
        }
    }

    IEnumerator ReActivate()
    {
        yield return new WaitForSeconds(2f);

        _renderer.material = _originalMaterial;
        _dissolveLogicRef.disolveActivated = false;

        _collider.enabled = true;
    }
}
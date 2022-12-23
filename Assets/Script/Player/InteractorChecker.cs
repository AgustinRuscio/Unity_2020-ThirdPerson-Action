//----------------------------------------------------//

//                   Ruscio Agustin                  //

//--------------------------------------------------//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractorChecker : MonoBehaviour, ITurrentDamagable
{
    [SerializeField]
    private Player _player;

    public IInteractuable _actualInteractuable;

    private void OnTriggerEnter(Collider other)
    {
        var interactuable = other.GetComponent<IInteractuable>();
        if (interactuable != null)
        {
            _actualInteractuable = interactuable;
            _player.DetectInteractuable(_actualInteractuable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var interactuable = other.GetComponent<IInteractuable>();
        if (interactuable == _actualInteractuable)
        {
            _actualInteractuable = null;
            _player.DetectInteractuable(_actualInteractuable);
        }
    }

    public void onHit(int damage)
    {
        _player.OnTakeDamage(damage, false);
    }
}

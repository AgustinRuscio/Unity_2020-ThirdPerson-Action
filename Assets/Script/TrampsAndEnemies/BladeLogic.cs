//--------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeLogic : Parent_Tramps
{
    [SerializeField]
    private int _damage;

    [SerializeField]
    private float _coolDown;

    private GenericTimer timer;

    [SerializeField]
    private SoundData _soundData;

    protected override void Start()
    {
        base.Start();
        AudioManager.instance.AudioPlay(_soundData, transform);

        timer = new GenericTimer(_coolDown);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var damageable = collision.gameObject.GetComponent<IDamageable>(); 

        if (damageable != null && timer.CheckCoolDown())
        {
            timer.ResetTimer();

            damageable.OnTakeDamage(_damage, false);
        }
    }

    void Update()
    {
        timer.RunTimer();
    }
}

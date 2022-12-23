//----------------------------------------------//

//                  Ruscio Agustin              //

//----------------------------------------------//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guillotine : MonoBehaviour
{
    [SerializeField]
    private float _attackCoolDown;

    private GenericTimer _timer;

    [SerializeField]
    private float _waitUntilGoUp;

    [SerializeField]
    private Rigidbody _rigid;

    [SerializeField]
    private GameObject _upPos;

    [SerializeField]
    float speed; 

    [SerializeField]
    private int _damage;

    [SerializeField]
    private SoundData _soundGuillotine;

    [SerializeField]
    private ParticleSystem _particleGuillotine;

    private void Awake()
    {
        _timer = new GenericTimer(_attackCoolDown);
    }

    void Update()
    {      
        _timer.RunTimer();

        if(_timer.CheckCoolDown())
        {
            AudioManager.instance.AudioPlay(_soundGuillotine, transform.position);
            _rigid.useGravity = true;
            
            StartCoroutine(Elevate());
        }
        
    }
    
    IEnumerator Elevate()
    {
       
        
        yield return new WaitForSeconds(_waitUntilGoUp);
        
        _rigid.useGravity = false;

       

        _timer.ResetTimer();

        transform.position = Vector3.MoveTowards(transform.position, _upPos.transform.position , speed * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        _particleGuillotine.Play();

        var damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
            damageable.OnTakeDamage(_damage, false);      
    }
}

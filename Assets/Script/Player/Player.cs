//----------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Rendering.PostProcessing;

[RequireComponent(typeof(Rigidbody))]
public class Player : Parent_Entity, IDamageable, IFanable, IPortable, IFrozenable
{
    public float forceJump;

    [SerializeField]
    private CameraController _camera;

    [Range(0, 1)]
    public float reduceSpeed;

    private float _originalSpeed;

    [SerializeField]
    private GameObject _canvas;

    [SerializeField]
    private GameObject _movingParticleSystem;

    public bool jumping;

    public bool onAir;

    private Rigidbody _myRigidBody;

    public IInteractuable _actualInteractuable;

    [SerializeField]
    private PausedMenu _pauseMenuRef;

    [SerializeField]
    private SoundData _jumpClip;

    [SerializeField]
    private SoundData _takeDamageClip;

    [SerializeField]
    private ParticleSystem _fireParticles;

    [SerializeField]
    private ParticleSystem _iceParticles;

    private void Awake()
    {
        EventManager.Suscribe(ManagerKeys.LifeEvent, AddLife);
        EventManager.Suscribe(ManagerKeys.keyEvent, AddKey);

        _originalSpeed = speed;
    }

    private void Start()
    {
        _myRigidBody = GetComponent<Rigidbody>();

        _movement = new Movement(transform, _myRigidBody, this, speed, forceJump, reduceSpeed, _jumpClip);
        _inputs = new Controller(_movement, this, _pauseMenuRef);

        _inputs._isMoving += MoveParticlesPlay;
        _inputs._notMoving += MoveParticlesStop;

        Hud.instance.UpdateHudData();
    }

    private void FixedUpdate()
    {
        _inputs.ArtificialFixedUpdate();
    }

    private void Update()
    {
        _inputs.ArtificialUpdate();
    }

    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<IItem>();

        if (item != null)
            item.ItemAction(this); 
    }

    public void DetectInteractuable(IInteractuable interacuable)
    {
        _actualInteractuable = interacuable;
    }

    #region Interfaces
    public void OnTakeDamage(int subs, bool isFire)
    {
        SpawnsManager.instance.SubstractLifes(subs);
        AudioManager.instance.AudioPlay(_takeDamageClip, transform.position);

        Hud.instance.UpdateHudData();
        Hud.instance.OnDamage();
        _canvas.SetActive(true);

        if (isFire)
        {
            _fireParticles.Play();
            StartCoroutine(StopParticles(_fireParticles));
        }
    }

    public void GetFrozen(float speedreducer, float timeFrozened)
    {
        speed = speed * speedreducer;

        _movement.SetSpeed(speed);

        _iceParticles.Play();

        StartCoroutine(StopParticles(_iceParticles));
        StartCoroutine(ResetSpeed(timeFrozened));
    }

    IEnumerator StopParticles(ParticleSystem particles)
    {
        yield return new WaitForSeconds(2);

        particles.Stop();
    }

    IEnumerator ResetSpeed(float timeFrozened)
    {
        yield return new WaitForSeconds(timeFrozened);

        speed = _originalSpeed;
        _movement.SetSpeed(speed);
    }

    public void OnFan(Vector3 dir, float strength)
    {
        _myRigidBody.AddForce(dir * strength, ForceMode.Acceleration);
    }

    public void Teleport(Vector3 newPosition, Vector3 newRotation, int cameraRotation)
    {
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(newRotation);

        _camera.SetAngle(cameraRotation);
    }

    #endregion

    public void HUd(bool key)
    {
        Hud.instance.UpdateHudData();
        Hud.instance.OnInteract(key);
    }

    public void AddLife(params object[] sum)
    {
        SpawnsManager.instance.AddLifes((int)sum[0]);
        HUd(false);
    }

    public void AddKey(params object[] sum)
    {
        KeysManager.instance.AddKeys((int)sum[0]);
        HUd(true);
    }

    public void MoveParticlesPlay()
    {
        _movingParticleSystem.SetActive(true);
    }

    public void MoveParticlesStop()
    {
        _movingParticleSystem.SetActive(false);
    }
    private void OnDestroy()
    {
        EventManager.UnSuscribe(ManagerKeys.LifeEvent, AddLife);
        EventManager.UnSuscribe(ManagerKeys.keyEvent, AddKey);
    }
}

//----------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement
{
    private float _speed;
    private float _forceJump;
    private float _reduceSpeed;

    private Rigidbody _rb;
    private Transform _transform;
    private Player _player;

    private SoundData _jumpClip;

    public int jumpIndex;

    public Movement(Transform transform, Rigidbody rb, Player pj, float speed, float forceJump, float reduceSpeed, SoundData clip) //pedir ReduceSpeed
    {
        _player = pj;
        _rb = rb;
        _transform = transform;
        _speed = speed;
        _forceJump = forceJump;
        _reduceSpeed = reduceSpeed;
        _jumpClip = clip;       
    }

    public void SetSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }

    public void Move(float x, float z)
    {
        var speed = _speed;

        if (!inFloor)
            speed *= _reduceSpeed;           

        Vector3 pos = _transform.forward * z; 

        pos += _transform.right * x; 
        pos *= speed * Time.deltaTime; 

        pos += _transform.up * _rb.velocity.y; 

        _rb.velocity = pos;
    }

    public Quaternion RotateWithMouse(float y)
    {       
        _transform.localRotation = Quaternion.Euler(0, _transform.localRotation.y + y * 30f,0);

        return _transform.localRotation;
    }

    public void Jump()
    {
        if (inFloor)
        {
            _player.jumping = true;
            AudioManager.instance.AudioPlay(_jumpClip, _transform.position);
            _rb.AddForce(Vector3.up * _forceJump, ForceMode.Impulse);
        }
        else if (jumpIndex! < 1)
        {
            jumpIndex++;

            _player.jumping = true;
            AudioManager.instance.AudioPlay(_jumpClip, _transform.position);
            _rb.AddForce(Vector3.up * _forceJump, ForceMode.Impulse);
        }
    }

    public bool inFloor
    {
        get
        {       
            return (Physics.Raycast(_player.transform.position, Vector3.down, 1.2f)); // Hace lo mismo que el If          
        }
    }
}

//----------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCheckPoint : MonoBehaviour
{
    private GameObject _spawnObject;

    private Vector3 _playerPosition;
    private Quaternion _playerRotation;

    [SerializeField]
    private CameraController _camera;

    private int _cameraRotation;

    [SerializeField]
    private Rigidbody _head;

    [SerializeField]
    private SoundData _clip;

    [SerializeField]
    private Image _flag;

    void Start()
    {
        _playerRotation = gameObject.transform.rotation;      
        _playerPosition = gameObject.transform.position;

        _cameraRotation = 90;
    }

    void Update()
    {
        if (gameObject.transform.position.y < -10 && SpawnsManager.instance.lifes !> 0)
        {
            gameObject.transform.rotation = _playerRotation;
            gameObject.transform.position = _playerPosition;

            _camera.SetAngle(_cameraRotation);

            _head.velocity = new Vector3(0, 0, 0);

            var player = FindObjectOfType<Player>();
            player.OnTakeDamage(1, false);

        }
        else if (SpawnsManager.instance.lifes <= 0)
        {
            GameManager.instance.Death();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var checkpoint = other.GetComponent<CheckPointRotation>();
        if (checkpoint != null)
        {
            AudioManager.instance.AudioPlay(_clip, transform.position);
            _flag.color = Color.white;

            _spawnObject = checkpoint.gameObject;

            _playerPosition = _spawnObject.transform.position + checkpoint.offset;
            _playerRotation  = Quaternion.Euler(checkpoint._rotation);

            _cameraRotation = checkpoint.cameraRotation;

            checkpoint.Activate();
        }
    }
}
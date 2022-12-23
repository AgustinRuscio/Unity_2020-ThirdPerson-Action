//----------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//

using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    private Movement _movement;
    private Player _player;
    
    private PausedMenu _pauseMenu;

    public float x;
    public float z;

    private Action ArtificialUpdateLogics;
    private Action ArtificialFixedUpdateLogics;

    public event Action _isMoving;
    public event Action _notMoving;

    public Controller(Movement movement, Player entity, PausedMenu pauseMenu)
    {
        _movement = movement;
        _player = entity;
        _pauseMenu = pauseMenu;

        NotPaused();

        _pauseMenu.pauseOn += OnPause;
        _pauseMenu.pauseOff += NotPaused;
    }

    private void OnPause()
    {
        ArtificialFixedUpdateLogics = delegate{ };
        ArtificialUpdateLogics = delegate { } ;
    }

    private void NotPaused()
    {
        ArtificialFixedUpdateLogics = MovementLogic;
        ArtificialFixedUpdateLogics += CameraLogic;

        ArtificialUpdateLogics = GeneralInputLogic;
        ArtificialUpdateLogics += JumpLogic;
    }

    public void ArtificialUpdate()
    {
        ArtificialUpdateLogics();
    }

    public void ArtificialFixedUpdate()
    {
        ArtificialFixedUpdateLogics();
    }

    public void MovementLogic()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        _movement.Move(x, z);

        if (x == 0 && z == 0)
        {
            _notMoving();
        }
        else
        {
            _isMoving();
        }
    }

    public void GeneralInputLogic()
    {
        if (Input.GetButtonDown("Interact") && _player._actualInteractuable != null)
        {
            _player._actualInteractuable.OnInteract();
        }

        if (Input.GetButtonDown("Cancel"))
        {
            _pauseMenu.Pause();
        }

        if (_movement.inFloor)
        {
            _player.onAir = false;
            _movement.jumpIndex = 0;
        }
        else
        {
            _player.onAir = true;
        }

        #region Cheats

        if (Input.GetKeyDown(KeyCode.I))
        {
            KeysManager.instance.keysCount++;

            if (KeysManager.instance.keysCount > 8)
                KeysManager.instance.keysCount = 8;   

            Hud.instance.OnInteract(true);
            Hud.instance.UpdateHudData();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            KeysManager.instance.keysCount--;

            if(KeysManager.instance.keysCount < 0)
                KeysManager.instance.keysCount = 0;

            Hud.instance.OnInteract(true);
            Hud.instance.UpdateHudData(); 
        }

        #endregion
    }

    public void CameraLogic()
    {
        float horizontalCam = Input.GetAxis("Mouse X");

        if (horizontalCam != 0)
        {
            _movement.RotateWithMouse(horizontalCam);
        }
    }

    public void JumpLogic()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _movement.Jump();
        }
    }    
}

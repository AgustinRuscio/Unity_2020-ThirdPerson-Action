//----------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Key_Object : MonoBehaviour, IItem
{
    [SerializeField]
    protected SoundData _clip;

    
    private int _keyToAdd = 1;

    public virtual void ItemAction(Player player)
    {
        AudioManager.instance.AudioPlay(_clip, transform.position);

        EventManager.Trigger(ManagerKeys.keyEvent, _keyToAdd);

        Destroy(gameObject);
    }
}

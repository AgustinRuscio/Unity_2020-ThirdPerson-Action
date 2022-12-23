//----------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLife : MonoBehaviour, IItem
{
    [SerializeField]
    private int _lifeToSum;

    [SerializeField]
    private SoundData _clip;

    public void ItemAction(Player player)
    {
        AudioManager.instance.AudioPlay(_clip, transform.position);

        EventManager.Trigger(ManagerKeys.LifeEvent, _lifeToSum);

        Destroy(gameObject);
    }
}

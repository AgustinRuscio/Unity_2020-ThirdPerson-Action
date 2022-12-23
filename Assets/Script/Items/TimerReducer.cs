//----------------------------------------------------//

//                   Ruscio Agustin                  //

//--------------------------------------------------//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerReducer : MonoBehaviour, IItem
{
    [SerializeField]
    private float timeReducer = 5;

    [SerializeField]
    private SoundData _sound;

    public void ItemAction(Player player)
    {
        AudioManager.instance.AudioPlay(_sound, transform.position);
        GameManager.instance.reduceTimer(timeReducer);

        Destroy(gameObject);
    }
}

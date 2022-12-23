//--------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public static Hud instance;

    public Text _textSpwans;

    public Text _textKeys;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateHudData()
    {
        _textSpwans.text = SpawnsManager.instance.lifes.ToString();
    
        _textKeys.text = KeysManager.instance.keysCount.ToString();      
    }

    /// <summary>
    /// If bool i == True Keys will change Color, else Spawns will
    /// </summary>
    /// <param name="i"></param>
    public void OnInteract(bool i)
    {
        if (i)
        {
            _textKeys.color = Color.green;
        }
        else
        {
            _textSpwans.color = Color.blue;
        }

        StartCoroutine(TurnWhite());
    }

    public void OnDamage()
    {
        _textSpwans.color = Color.red;
        StartCoroutine(TurnWhite());
    }

    IEnumerator TurnWhite()
    {
        yield return new WaitForSeconds(2);
        _textKeys.color = Color.white; _textSpwans.color = Color.white;
    }
}
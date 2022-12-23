// ----------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysManager : MonoBehaviour
{
    public static KeysManager instance;

    public event Action keyCountChange;

    public int keysCount;

    private void Awake()
    {
        if(PlayerPrefs.GetString("Level") == "MainMenu" || PlayerPrefs.GetString("Level") == "LoseScene")
            keysCount = 0;
        
        if(instance  == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else      
            Destroy(gameObject);      
    }

    public void updateGlobalKeys(int keyAmmount)
    {
        keysCount = keyAmmount;    
    }

    public void ResetKets()
    {
        keysCount = 0;
    }

    public void AddKeys(int sum)
    {
        keysCount += sum;
        keyCountChange();
    }
}
    

//--------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnsManager : MonoBehaviour
{
    public static SpawnsManager instance;

    public int lifes;

    private void Awake()
    {
        if(instance == null)
            instance = this; 

        lifes = 3;
    }

    public void AddLifes(int sum)
    {
        lifes += sum;

        if (lifes >= 10)  
            lifes = 10;
    }

    public void SubstractLifes(int dmg)
    {
        lifes -= dmg;
    }

    public void SubstractLifes()
    {
        lifes --;
    }
}

//--------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{  
    public static SceneController instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;  
    }

    public void ChangeScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    
}

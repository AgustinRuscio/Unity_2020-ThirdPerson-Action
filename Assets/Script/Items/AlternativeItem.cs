//--------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeItem : MonoBehaviour, IItem
{
    public void ItemAction(Player player)
    {
        SceneController.instance.ChangeScene("ScoreScene");
    }
}

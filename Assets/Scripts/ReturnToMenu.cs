using DreamCatcher;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMenu : MonoBehaviour
{
    void Update()
    {
       if (Input.anyKeyDown)
        {
            GameManager.Instance.SwitchState(EnumCollection.GameState.NewGame);
        }
    }
}

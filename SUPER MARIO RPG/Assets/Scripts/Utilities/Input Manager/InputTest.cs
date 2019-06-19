using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    private void Update()
    {
        if(InputManager.AButton())
        {
            Debug.Log(InputManager.Joystick());
        }
    }
}

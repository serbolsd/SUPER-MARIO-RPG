using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    //Axis
    public static float EjeHorizontal()
    {
        float Moverse = 0.0f;
        Moverse += Input.GetAxis("Eje_Horizontal(Joystick)");
        Moverse += Input.GetAxis("Eje_Horizontal(Boton)");
        return Mathf.Clamp(Moverse, -1.0f, 1.0f);
    }
    public static float EjeVertical()
    {
        float Moverse = 0.0f;
        Moverse += Input.GetAxis("Eje_Vertical(Joystick)");
        Moverse += Input.GetAxis("Eje_Vertical(Boton)");
        return Mathf.Clamp(Moverse, -1.0f, 1.0f);
    }
    public static Vector3 Joystick()
    {
       return new Vector3(EjeHorizontal(), EjeVertical(), 0);
    }
    //Botones
    public static bool AButton()
    {
        return Input.GetButtonDown("Boton_A");
    }
    public static bool BButton()
    {
        return Input.GetButtonDown("Boton_B");
    }
    public static bool XButton()
    {
        return Input.GetButtonDown("Boton_X");
    }
    public static bool YButton()
    {
        return Input.GetButtonDown("Boton_Y");
    }
    public static bool StartButton()
    {
        return Input.GetButtonDown("Start");
    }
    public static bool BackButton()
    {
        return Input.GetButtonDown("Back");
    }
    public static bool RBButton()
    {
        return Input.GetButtonDown("RB");
    }
    public static bool LBButton()
    {
        return Input.GetButtonDown("LB");
    }

}

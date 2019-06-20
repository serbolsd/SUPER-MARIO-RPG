using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    //public moverse;
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
    public static Vector2 Joystick()
    {
        return new Vector2(EjeHorizontal(), EjeVertical());
    }
    public static bool jostickMoveHorizontal()
    {
        if (EjeHorizontal() != 0)
        {
            return true;
        }
        return false;
    }
    public static bool jostickMoveVertical()
    {
        if (EjeVertical() != 0)
        {
            return true;
        }
        return false;
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
    public static bool UPButton()
    {
        float i = Input.GetAxis("UP");
        if(i>0)
        {
            return true;
        }
        return false;
    }
    public static bool DOWNButton()
    {
        float i = Input.GetAxis("UP");
        if (i < 0)
        {
            return true;
        }
        return false;
    }
    public static bool RightButton()
    {
        float i = Input.GetAxis("RIGHT");
        if (i > 0)
        {
            return true;
        }
        return false;
    }
    public static bool LefhtButton()
    {
        float i = Input.GetAxis("RIGHT");
        if (i < 0)
        {
            return true;
        }
        return false;
    }
    public static bool anyButton()
    {
        if (LBButton())
            return true;
        if (RBButton())
            return true;
        if (BackButton())
            return true;
        if (StartButton())
            return true;
        if (YButton())
            return true;
        if (XButton())
            return true;
        if (BButton())
            return true;
        if (AButton())
            return true;
        return false;
    }
}

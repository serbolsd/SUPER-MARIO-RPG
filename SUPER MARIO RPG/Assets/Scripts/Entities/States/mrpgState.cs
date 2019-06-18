using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class mrpgState : MonoBehaviour
{
    protected mrpgFMS MSM = null;

    public void 
    setFSM(mrpgFMS FSM)
    {
        MSM = FSM;
    }
    public abstract void onEnter();
    public abstract void onExit();
    public abstract void onPreUpdate();
    public abstract void onUpdate();
}

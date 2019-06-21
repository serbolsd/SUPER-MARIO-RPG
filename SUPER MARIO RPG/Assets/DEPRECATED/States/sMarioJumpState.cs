using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sMarioJumpState : mrpgState
{
    public override void
    onEnter()
    {
        /**
         * ************************
         * *  Animation changes got here
         * ************************
         * */
        //GetComponent<cCharacter>().m_Stats.m_zAxisSpeed += GetComponent<cCharacter>().m_Stats.m_jumpForce;
    }

    public override void
    onPreUpdate()
    {
        if(gameObject.transform.position.z <= 0)
        {
            Vector3 pos = gameObject.transform.position;
            pos.z = 0;
            gameObject.transform.position = pos;
            MSM.pushState(GetComponent<fsmMarioMachine>().s_Idle);
        }
        if (InputManager.YButton())
        {
            GetComponent<cCharacter>().m_Stats.m_running = true;
        }
        else
        {
            GetComponent<cCharacter>().m_Stats.m_running = false;
        }
    }

    public override void
     onUpdate()
    {
        GetComponent<cCharacter>().m_Stats.m_direction = InputManager.Joystick() * Time.fixedDeltaTime;
        gameObject.transform.position += GetComponent<cCharacter>().m_Stats.m_direction;
        //GetComponent<cCharacter>().m_Stats.m_zAxisSpeed -= GetComponent<cCharacter>().m_Stats.m_gravForce * Time.fixedDeltaTime;
    }

    public override void
    onExit()
    {

    }
}

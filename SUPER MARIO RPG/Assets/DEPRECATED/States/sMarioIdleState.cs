﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sMarioIdleState : mrpgState
{
    public override void
    onEnter()
    {
        /**
         * ************************
         * *  Animation changes got here
         * ************************
         * */
    }

    public override void
    onExit()
    {

    }

    public override void
    onPreUpdate()
    {
        if (InputManager.XButton())
        {
            MSM.pushState(GetComponent<fsmMarioMachine>().s_Pause);
        }

        else if (InputManager.BButton())
        {
            MSM.setState(GetComponent<fsmMarioMachine>().s_Jump);
        }

        else if (InputManager.AButton())
        {
            if (GetComponent<fsmMarioMachine>().arrGO_Contacts.Length < 0)
            {
                for (int i = 0; i < GetComponent<fsmMarioMachine>().arrGO_Contacts.Length; ++i)
                {
                    if (GetComponent<fsmMarioMachine>().arrGO_Contacts[i].GetComponent<cCharacter>().interact(MSM as fsmMarioMachine))
                    {
                        MSM.setState(GetComponent<fsmMarioMachine>().s_Dialog_CutScene);
                    }
                }
            }
        }

        /**
         * ************************
         * *  Check run button
         * ************************
         * */
        if (InputManager.YButton())
        {
            GetComponent<cCharacter>().m_Stats.m_running = true;
        }
        else
        {
            GetComponent<cCharacter>().m_Stats.m_running = false;
        }

        /**
         * ************************
         * *  Check stick input
         * ************************
         * */
        if (InputManager.Joystick() != Vector3.zero)
        {
            MSM.pushState(GetComponent<fsmMarioMachine>().s_WalkRun);
        }
    }

    public override void
     onUpdate()
    {

    }
}

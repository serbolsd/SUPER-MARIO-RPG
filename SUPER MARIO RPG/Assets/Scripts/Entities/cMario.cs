using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cMario : cCharacter
{
    private void Start()
    {
        m_MarioMachine = GetComponent<fsmMarioMachine>();
    }
    public fsmMarioMachine m_MarioMachine;
}

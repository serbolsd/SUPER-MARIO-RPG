using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cCharacter : cInteractable
{
    private void Start()
    {
        m_Stats = GetComponent<cStats>();
    }

    public int getLVL()
    {
        return m_Stats.m_LVL;
    }

    public int getATK()
    {
        return m_Stats.m_ATK;
    }

    public int getDEF()
    {
        return m_Stats.m_DEF;
    }

    public int getHP()
    {
        return m_Stats.m_HP;
    }

    public int getMagATK()
    {
        return m_Stats.m_MagATK;
    }

    public int getMagDEF()
    {
        return m_Stats.m_MagDef;
    }

    public override bool interact(fsmMarioMachine _mm)
    {
        return false;
    }

    [SerializeField]
    public cStats m_Stats;
}

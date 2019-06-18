using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cCharacter : MonoBehaviour
{

    public int getATK()
    {
        return (int)m_Stats.m_ATK;
    }

    public int getDEF()
    {
        return (int)m_Stats.m_DEF;
    }

    public int getHP()
    {
        return (int)m_Stats.m_HP;
    }

    public int getMagATK()
    {
        return (int)m_Stats.m_MagATK;
    }

    public int getMagDEF()
    {
        return (int)m_Stats.m_MagDef;
    }

    cStats m_Stats;
}

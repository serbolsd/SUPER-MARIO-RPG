using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * ************************
 * *
 * *  Character class for use in combat 
 * *
 * ************************
 * */
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
        return m_Stats.m_MagDEF;
    }

    public virtual bool takeTurn()
    {
        return false;
    }

    public cStats getStatBlock()
    {
        return m_Stats;
    }

    public void setPos(Vector3 newPos)
    {
        gameObject.transform.position = newPos;
    }

    [SerializeField]
    public cStats m_Stats;
    public string m_name;
    public int m_enemyId;
}

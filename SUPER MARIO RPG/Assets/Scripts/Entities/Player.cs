using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * ************************
 * *
 * *  This script is the one that must be attached to the playable character
 * *
 * ************************
 * */
public class Player : MonoBehaviour
{
    private void Start()
    {
        m_Mario = GetComponent<cMario>();
    }

    /**
     * ************************
     * *  FixedUpdate runs the onPreUpdate & onUpdate
     * ************************
     * */
    private void FixedUpdate()
    {
        m_Mario.m_MarioMachine.onPreUpdate();
        m_Mario.m_MarioMachine.onUpdate();
    }

    public int getLVL()
    {
        return m_Mario.getLVL();
    }

    public int getATK()
    {
        return m_Mario.getATK();
    }

    public int getDEF()
    {
        return m_Mario.getDEF();
    }

    public int getHP()
    {
        return m_Mario.getHP();
    }

    public int getMagATK()
    {
        return m_Mario.getMagATK();
    }

    public int getMagDEF()
    {
        return m_Mario.getMagDEF();
    }

    [SerializeField]
    public cMario m_Mario;

}

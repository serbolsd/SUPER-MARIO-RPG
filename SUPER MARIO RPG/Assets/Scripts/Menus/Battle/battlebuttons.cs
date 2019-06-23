using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battlebuttons : MonoBehaviour
{
    // Start is called before the first frame update
    

    void Start()
    {
        if (!BM)
        {
            BM = GetComponentInParent<gBattleMode>();
            GameObject parent = gameObject.transform.parent.gameObject;
        }
        m_nEnemy = BM.getEnemiesSize();

        m_menusinfos = Resources.LoadAll<Sprite>("Sprites/Menus/battle menu");

        ////////////////////////// All buttons?
        GameObject child = new GameObject();
        child.transform.parent = transform;
        child.transform.localPosition = transform.localPosition;
        menuinfo = child.gameObject.AddComponent<SpriteRenderer>();
        menuinfo.sprite = m_menusinfos[0];
        menuinfo.enabled = false;
        neutral = menuinfo.sprite;

        ////////////////////////// A button
        GameObject child2 = new GameObject();
        child2.transform.parent = transform;
        child2.transform.localPosition = transform.localPosition;
        fondoInfo1 = child2.gameObject.AddComponent<SpriteRenderer>();
        fondoInfo1.sprite = m_menusinfos[1];
        fondoInfo1.enabled = false;
        attack = fondoInfo1.sprite;

        ////////////////////////// Y Button
        GameObject child3 = new GameObject();
        child3.transform.parent = transform;
        child3.transform.localPosition = transform.localPosition;
        fondoInfo2 = child3.gameObject.AddComponent<SpriteRenderer>();
        fondoInfo2.sprite = m_menusinfos[2];
        fondoInfo2.enabled = false;
        special = fondoInfo2.sprite;

        ////////////////////////// Y Button also?
        GameObject child4 = new GameObject();
        child4.transform.parent = transform;
        child4.transform.localPosition = transform.localPosition;
        fondoInfo2_1 = child4.gameObject.AddComponent<SpriteRenderer>();
        fondoInfo2_1.sprite = m_menusinfos[3];
        fondoInfo2_1.enabled = false;
        special = fondoInfo2_1.sprite;

        ////////////////////////// X button
        GameObject child5 = new GameObject();
        child5.transform.parent = transform;
        child5.transform.localPosition = transform.localPosition;
        fondoInfo3 = child5.gameObject.AddComponent<SpriteRenderer>();
        fondoInfo3.sprite = m_menusinfos[4];
        fondoInfo3.enabled = false;
        item = fondoInfo3.sprite;

        //////////////////////////
        //////////////////////////
        //////////////////////////
        m_attacking = false;

        m_goodTimmingTime = 0.23f;
        m_perfectTimmingTime = 0.08f;
        //menu = this.GetComponent<SpriteRenderer>();
        //menu.sprite = neutral;
        //TODO: make this load its own sprites on startup
    }

    // Update is called once per frame
    public bool onUpdate()
    {
        m_nEnemy = BM.getEnemiesSize();
        if(m_currEnemy > m_nEnemy)
        {
            m_currEnemy = m_nEnemy;
        }

        if(InputManager.EjeHorizontal() > gUtilities.kSTICKDEADZONE || InputManager.EjeVertical() > gUtilities.kSTICKDEADZONE)
        {
            //TODO: enemy selection arrow
        }
        else if (InputManager.EjeHorizontal() < -gUtilities.kSTICKDEADZONE || InputManager.EjeVertical() < -gUtilities.kSTICKDEADZONE)
        {
            //TODO: enemy selection arrow
        }

        if (InputManager.AButton())
        {
            menuinfo.enabled = true;
            fondoInfo1.enabled = true;
            fondoInfo2.enabled = false;
            fondoInfo2_1.enabled = false;
            fondoInfo3.enabled = false;
            menuinfo.sprite = m_menusinfos[0];
            menu.sprite = attack;
        }

        else if (InputManager.BButton())
        {
            menuinfo.enabled = true;
            fondoInfo1.enabled = true;
            fondoInfo2.enabled = false;
            fondoInfo2_1.enabled = false;
            fondoInfo3.enabled = false;
            menuinfo.sprite = m_menusinfos[0];
            menu.sprite = etc;
        }

        else if (InputManager.XButton())
        {
            menuinfo.enabled = true;
            fondoInfo1.enabled = false;
            fondoInfo2.enabled = false;
            fondoInfo2_1.enabled = false;
            fondoInfo3.enabled = true;
            menuinfo.sprite = m_menusinfos[2];
            menu.sprite = item;
        }

        else if (InputManager.YButton())
        {
            menuinfo.enabled = true;
            fondoInfo1.enabled = false;
            fondoInfo2.enabled = true;
            fondoInfo2_1.enabled = true;
            fondoInfo3.enabled = false;
            menuinfo.sprite = m_menusinfos[1];
            menu.sprite = special;
        }

        if (fondoInfo1.enabled) //Attack button
        {
            if (InputManager.EjeHorizontal() > gUtilities.kSTICKDEADZONE || InputManager.EjeVertical() > gUtilities.kSTICKDEADZONE)
            {
                ++m_currEnemy;
                if(m_currEnemy > m_nEnemy)
                {
                    m_currEnemy = 0;
                }
                //TODO: enemy selection arrow
            }
            else if (InputManager.EjeHorizontal() < -gUtilities.kSTICKDEADZONE || InputManager.EjeVertical() < -gUtilities.kSTICKDEADZONE)
            {
                --m_currEnemy;
                if (m_currEnemy < 0)
                {
                    m_currEnemy = m_nEnemy;
                }
                //TODO: enemy selection arrow
            }
            if (InputManager.AButton())
            {
                m_attacking = true;
            }
            if (m_attacking)
            {
                if (InputManager.AButton() && !m_attackedTimed)
                {
                    if (m_Timer <= m_goodTimmingTime * 2 && m_Timer >= m_goodTimmingTime)
                    {
                        if (m_Timer <= m_goodTimmingTime + (m_perfectTimmingTime * 2) &&
                            m_Timer >= m_goodTimmingTime + m_perfectTimmingTime)
                        {
                            m_atkTimmingMod = 2;
                        }
                        else
                        {
                            m_atkTimmingMod = 1.5f;
                        }
                    }
                    else
                    {
                        m_atkTimmingMod = 1;
                    }
                    m_attackedTimed = true;
                }
                if (m_Timer > (m_goodTimmingTime + m_perfectTimmingTime) * 2)
                {
                    m_Timer = 0;
                    BM.Attack(m_char, BM.getEnemy(m_currEnemy), m_atkTimmingMod);
                    return true;
                }
                else
                {
                    m_Timer += Time.fixedDeltaTime;
                }
            }
        }

        if (fondoInfo2.enabled) //Special button
        {
            if (InputManager.EjeHorizontal() > gUtilities.kSTICKDEADZONE || InputManager.EjeVertical() > gUtilities.kSTICKDEADZONE)
            {
                //TODO: enemy selection arrow
            }
            else if (InputManager.EjeHorizontal() < -gUtilities.kSTICKDEADZONE || InputManager.EjeVertical() < -gUtilities.kSTICKDEADZONE)
            {
                //TODO: enemy selection arrow
            }
            if (InputManager.YButton())
            {
                m_attacking = true;
            }
            if (m_attacking)
            {
                if (InputManager.YButton() && !m_attackedTimed)
                {
                    if (m_Timer <= m_goodTimmingTime * 2 && m_Timer >= m_goodTimmingTime)
                    {
                        if (m_Timer <= m_goodTimmingTime + (m_perfectTimmingTime * 2) &&
                            m_Timer >= m_goodTimmingTime + m_perfectTimmingTime)
                        {
                            m_atkTimmingMod = 2;
                        }
                        else
                        {
                            m_atkTimmingMod = 1.5f;
                        }
                    }
                    else
                    {
                        m_atkTimmingMod = 1;
                    }
                    m_attackedTimed = true;
                }
                if (m_Timer > (m_goodTimmingTime + m_perfectTimmingTime) * 2)
                {
                    m_Timer = 0;
                    BM.Attack(m_char, BM.getEnemy(m_currEnemy), m_atkTimmingMod);
                    return true;
                }
                else
                {
                    m_Timer += Time.fixedDeltaTime;
                }
            }
        }
        return false;
    }

    public void setCharacter(cCharacter _char)
    {
        m_char = _char;
    }
        
    public Sprite neutral;
    public Sprite attack;
    public Sprite special;
    public Sprite item;
    public Sprite etc;
    public SpriteRenderer menuinfo;
    public Sprite[] m_menusinfos;
    public SpriteRenderer fondoInfo1;
    public SpriteRenderer fondoInfo2;
    public SpriteRenderer fondoInfo2_1;
    public SpriteRenderer fondoInfo3;
    public SpriteRenderer menu;

    gBattleMode BM;
    cCharacter m_char;
    bool m_attacking;
    bool m_attackedTimed;
    int m_nEnemy;
    int m_currEnemy;
    float m_Timer;
    float m_atkTimmingMod;
    float m_goodTimmingTime;
    float m_perfectTimmingTime;
}

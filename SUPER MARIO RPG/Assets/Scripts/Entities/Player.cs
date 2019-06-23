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
    public bool isCutScene = false;
    private void Start()
    {
        m_Stats = GetComponent<cStats>();
        m_battleMario = gameObject.AddComponent<battleMario>();
    }

    /**
     * ************************
     * *  FixedUpdate runs the onPreUpdate & onUpdate
     * ************************
     * */
    private void FixedUpdate()
    {
        if (!isCutScene)
        {
        //    return;
        
            {
                /**
                 * * Pause
                 * */
                if (InputManager.XButton())
                {
                    //TODO: pause
                }
            }
            
            {
                /**
                 * * Interact
                 * */
                if (InputManager.AButton())
                {
            
                }
            }
            
            {
                /**
                 * * Jump input
                 * */
                if (InputManager.BButton())
                {
                    if (!m_Stats.m_jumping)
                    {
                        JumpStart();
                    }
                }
                if (m_Stats.m_jumping)
                {
                    JumpUpdate();
                }
            
            }
            
            {
                /**
                 * * Stick input
                 * */
                if (InputManager.Joystick() == Vector3.zero)
                {
                    m_Stats.m_moving = false;
                }
                else
                {
                    m_Stats.m_moving = true;
                }
            }
            
            {
                /**
                * *  Check run button
                * */
                if (Input.GetButtonDown("Boton_Y"))
                {
                    m_Stats.m_running = true;
                }
                else if (Input.GetButtonUp("Boton_Y"))
                {
                    m_Stats.m_running = false;
                }
            }
            
            {
                /**
                 * *  Movement 
                 * */
                if (m_Stats.m_moving)
                {
                    m_Stats.m_direction = InputManager.Joystick() * Time.fixedDeltaTime * m_Stats.m_moveSpeed;
                    bool horizontal = false;
                    bool vertical = false;
                    if (Mathf.Abs(InputManager.EjeHorizontal()) >= gUtilities.kHORIZONTAL_DIR)
                    {
                        horizontal = true;
                    }
                    if (Mathf.Abs(InputManager.EjeVertical()) >= gUtilities.kHORIZONTAL_DIR)
                    {
                        vertical = true;
                    }
                    if (horizontal && vertical)
                    {
                        m_Stats.m_direction.x *= gUtilities.kHORIZONTAL_DIR;
                        m_Stats.m_direction.y *= gUtilities.kVERTICAL_DIR;
                    }
                    if (m_Stats.m_running)
                    {
                        m_Stats.m_direction *= m_Stats.m_runSpeed;
                    }
                    gameObject.transform.position += m_Stats.m_direction;
                }
            }
        }
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

    public cStats getStats()
    {
        return m_Stats;
    }

    public void JumpStart()
    {
        m_Stats.m_yVelocity = 0;
        m_Stats.m_initialHeight = 0;
        m_Stats.m_initialHeight = m_MarioSpritePos.localPosition.y;
        m_Stats.m_yVelocity += m_Stats.m_jumpForce;
        m_Stats.m_jumping = true;
        m_MarioDropShadow.gameObject.SetActive(true);
        m_LocalMarioSpritePos = m_MarioSpritePos;
    }

    public void JumpUpdate()
    {
        Vector3 newPos = m_MarioSpritePos.localPosition;
        if (newPos.y < m_Stats.m_initialHeight)
        {
            m_Stats.m_yVelocity = 0;
            JumpEnd();
        }
        else
        {
            newPos.y += m_Stats.m_yVelocity * Time.fixedDeltaTime;
            m_MarioSpritePos.localPosition = newPos;
            m_Stats.m_yVelocity -= m_Stats.m_gravForce * Time.fixedDeltaTime;
        }
    }

    public void JumpEnd()
    {
        m_MarioDropShadow.gameObject.SetActive(false);
        m_Stats.m_jumping = false;
        m_MarioSpritePos.localPosition = Vector3.zero;
    }

    battleMario m_battleMario;
    cStats m_Stats;
    public Transform m_MarioSpritePos;
    private Transform m_LocalMarioSpritePos;
    public SpriteRenderer m_MarioDropShadow;
}

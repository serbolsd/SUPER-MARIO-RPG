using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cStats : MonoBehaviour
{
    

    #region Battle Stats
    [SerializeField]
    public int m_LVL;
    [SerializeField]
    public int m_HP;
    [SerializeField]
    public int m_ATK;
    [SerializeField]
    public int m_DEF;
    [SerializeField]
    public int m_MagATK;
    [SerializeField]
    public int m_MagDEF;
    [SerializeField]
    public int m_bSpeed;
    #endregion

    #region Movenment Stats
    [SerializeField]
    [Range(0f, 10f)]
    public float m_moveSpeed;

    [SerializeField]
    [Range(0f, 10f)]
    public float m_runSpeed;

    [SerializeField]
    [Range(1f, 1000f)]
    public float m_jumpForce;

    [SerializeField]
    [Range(1f, 150f)]
    public float m_gravForce;

    [SerializeField]
    public float m_initialHeight;

    [SerializeField]
    public float m_yVelocity;

    public Vector3 m_direction;
    #endregion

    #region Control Flags
    public bool m_jumping = false;
    public bool m_running = false;
    public bool m_moving = false;
    #endregion
}

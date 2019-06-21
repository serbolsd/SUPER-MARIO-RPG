using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class iaTerrapin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        m_world_Terrapin_IA_Mode = 0;
        m_targetPoint = 0;
        m_target = p0;
        m_targetMario = Camera.main.GetComponent<CameraFollow>().getMario();
    }

    // Update is called once per frame
    void Update()
    {
        m_vertical = false;
        m_horizontal = false;

        #region Direction calc
        m_dir = m_target.position - transform.position;
        m_distTarget = m_dir.magnitude;
        m_dir.Normalize();
        if (Mathf.Abs(m_dir.x) > gUtilities.kSTICKDEADZONE)
        {
            m_horizontal = true;
        }
        if (Mathf.Abs(m_dir.y) > gUtilities.kSTICKDEADZONE)
        {
            m_vertical = true;
        }

        if (m_vertical && !m_horizontal)
        {
            m_dir.x = 0;
            m_dir.y = 1;
        }
        else if (!m_vertical && m_horizontal)
        {
            m_dir.x = 1;
            m_dir.y = 0;
        }
        else if (m_vertical && m_horizontal)
        {
            m_dir.x *= gUtilities.kHORIZONTAL_DIR;
            m_dir.y *= gUtilities.kVERTICAL_DIR;
        }
        else
        {
            m_dir = Vector2.zero;
        }
        #endregion

        #region patrol exit
        if (m_world_Terrapin_IA_Mode == 0)
        {
            if ((m_targetMario.position - transform.position).magnitude < m_viewDist)
            {
                // Change state to chasing Mario
                m_world_Terrapin_IA_Mode = 1;
                m_target = m_targetMario;
                m_Timer = m_chaseTime;
            }
            else if (m_distTarget < m_dist)
            {
                if (m_targetPoint == 0)
                {
                    m_target = p1;
                    m_targetPoint = 1;
                }
                else
                {
                    m_target = p0;
                    m_targetPoint = 0;
                }
            }
        }
        #endregion

        #region chase exit
        if (m_world_Terrapin_IA_Mode == 1)
        {
            if(m_Timer <= 0)
            {
                m_world_Terrapin_IA_Mode = 2;
                m_Timer = m_fleeTime;
            }
            m_Timer -= Time.fixedDeltaTime;
        }
        #endregion

        #region flee exit
        if (m_world_Terrapin_IA_Mode == 2)
        {
            if (m_Timer <= 0)
            {
                m_world_Terrapin_IA_Mode = 1;
                m_Timer = m_chaseTime;
            }
            m_Timer -= Time.fixedDeltaTime;
        }
        #endregion

        if (m_world_Terrapin_IA_Mode != 2)
        {
            // Seek
            transform.position += m_dir * m_moveSpeed * Time.fixedDeltaTime;
        }
        else
        {
            // Flee
            transform.position -= m_dir * m_moveSpeed * Time.fixedDeltaTime;
        }
    }

    public Transform p0;
    public Transform p1;

    [SerializeField]
    [Range(0f, 1f)]
    public float m_dist;

    [SerializeField]
    [Range(0f, 1f)]
    public float m_viewDist;

    [SerializeField]
    [Range(0f, 5f)]
    public float m_moveSpeed;

    [SerializeField]
    [Range(0f, 10f)]
    public float m_chaseTime;

    [SerializeField]
    [Range(0f, 10f)]
    public float m_fleeTime;

    [SerializeField]
    Transform m_targetMario;
    Transform m_target;
    Vector3 m_dir;
    int m_world_Terrapin_IA_Mode;
    int m_targetPoint;
    bool m_horizontal;
    bool m_vertical;
    float m_distTarget;
    float m_Timer;
}

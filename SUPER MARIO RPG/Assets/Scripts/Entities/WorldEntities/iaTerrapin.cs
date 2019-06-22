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
        m_Timer = m_lookAroundTime;
        m_lookingAround = false;
        m_ignoreLookAround = false;
    }

    // Update is called once per frame
    void Update()
    {
        m_vertical = false;
        m_horizontal = false;

        #region Direction calc
        m_dir = m_target.position - transform.position;
        m_dir.z = 0;
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
            m_dir.y *= Mathf.Abs(m_dir.y / Mathf.Abs(m_dir.y));
        }
        else if (!m_vertical && m_horizontal)
        {
            m_dir.x *= Mathf.Abs(m_dir.x / Mathf.Abs(m_dir.x));
            m_dir.y = 0;
        }
        else if (m_vertical && m_horizontal)
        {
            m_dir.x *= gUtilities.kHORIZONTAL_DIR;
            m_dir.y *= gUtilities.kVERTICAL_DIR;
        }
        else if(m_dir.y == 1 && m_target != m_targetMario)
        {
            int i = 0;
            ++i;
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
                m_lookingAround = false;
            }

            else if((centerPoint.position - transform.position).magnitude < m_dist * 3 && !m_ignoreLookAround)
            {
                if(Random.Range(0, 3) == 1)
                {
                    m_Timer = m_lookAroundTime;
                    m_lookingAround = true;
                    m_ignoreLookAround = true;
                }
                else
                {
                    m_lookingAround = false;
                    m_ignoreLookAround = true;
                }
            }

            else if (m_distTarget < m_dist)
            {
                if (m_targetPoint == 0)
                {
                    m_target = p1;
                    m_targetPoint = 1;
                    m_ignoreLookAround = false;
                }
                else
                {
                    m_target = p0;
                    m_targetPoint = 0;
                    m_ignoreLookAround = false;
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
            #region LookAroundnTurn

            if (m_world_Terrapin_IA_Mode == 0 && m_lookingAround)
            {
                //looking animation
                if (m_Timer <= 0)
                {
                    if(Random.Range(0, 4) < 2)
                    {
                        if(m_target == p0)
                        {
                            m_target = p1;
                        }
                        else
                        {
                            m_target = p0;
                        }
                    }
                    m_ignoreLookAround = true;
                    m_lookingAround = false;
                }
                m_Timer -= Time.fixedDeltaTime;
            }

            #endregion
            else if(m_world_Terrapin_IA_Mode == 1)
            {
                transform.position += m_dir * m_moveSpeed * Time.fixedDeltaTime * 1.25f;
            }
            else
            {
                if (!m_lookingAround)
                    transform.position += m_dir * m_moveSpeed * Time.fixedDeltaTime;
                else
                    transform.position = centerPoint.position;
            }
        }
        else
        {
            // Flee
            transform.position -= m_dir * m_moveSpeed * Time.fixedDeltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponentInParent<gBattleMode>().startBattle(gameObject,
                                                        gUtilities.makeCharCopies(new battleTerrapin(), Random.Range(1, 4)),
                                                        gUtilities.makeCharCopies(new battleMario()), 
                                                        m_BattleBG_Id);
    }

    public Transform p0;
    public Transform p1;
    public Transform centerPoint;



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
    [Range(0f, 5f)]
    public float m_lookAroundTime;

    [SerializeField]
    public int m_BattleBG_Id;

    Transform m_targetMario;
    Transform m_target;
    Vector3 m_dir;

    int m_world_Terrapin_IA_Mode;
    int m_targetPoint;
    bool m_horizontal;
    bool m_vertical;
    bool m_lookingAround;
    bool m_ignoreLookAround;
    float m_distTarget;
    float m_Timer;
}

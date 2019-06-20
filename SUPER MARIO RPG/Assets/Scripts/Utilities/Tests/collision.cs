using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    private void Start()
    {
        m_lastPos = gameObject.transform.position;
        cc = GetComponent<CircleCollider2D>();
        m_colliding = false;
    }

    private void Update()
    {
        m_currPos = gameObject.transform.position;

        if (m_colliding)
        {
            gameObject.transform.position = m_lastPos;
        }
        else
        {
            m_lastPos = m_currPos;
        }
        m_colliding = false;
    }
    // Start is called before the first frame update
    public void OnCollisionStay2D(Collision2D collision)
    {
        m_colliding = true;
        Debug.Log("colliding");
        if (collision.gameObject.name == "Pared")
        {
            m_colliding = true;
            Debug.Log("Si jala");
        }
    }

    bool m_colliding;
    CircleCollider2D cc;
    Vector3 m_currPos;
    Vector3 m_lastPos;
}

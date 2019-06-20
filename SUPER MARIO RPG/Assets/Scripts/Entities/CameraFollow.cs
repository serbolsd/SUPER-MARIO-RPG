using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void Update()
    {
        m_pos = transform.position;
        m_pos.z = 0;
        m_dir = m_Mario.position - m_pos;
        if(m_dir.magnitude > m_range)
        {
            transform.position += (m_dir * m_dir.magnitude);
        }

    }
    public ref Transform getMario()
    {
        return ref m_Mario;
    }

    [SerializeField]
    private Transform m_Mario;
    Vector3 m_pos;
    
    Vector3 m_dir;

    [SerializeField]
    [Range(0f, 1f)]
    float m_range;
}

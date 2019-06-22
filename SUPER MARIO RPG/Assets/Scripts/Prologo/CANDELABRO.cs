using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CANDELABRO : MonoBehaviour
{
    Vector3 posOrigin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_pos = transform.position;
        m_pos.z = 0;
        m_dir = m_Mario.position - m_pos;
        if (m_dir.magnitude > m_range)
        {
            transform.position += (m_dir);
            transform.position =new Vector3 (transform.position.x, transform.position.y+.8f, transform.position.z);
        }
        
    }
    [SerializeField]
    private Transform m_Mario;
    Vector3 m_pos;

    Vector3 m_dir;

    [SerializeField]
    [Range(0f, 1f)]
    float m_range;
}

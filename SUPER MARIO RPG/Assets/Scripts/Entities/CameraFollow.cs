﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject []objectsInScene;
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
        checklayout();

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

    void checklayout()
    {
        for (int i = 0; i < objectsInScene.Length; i++)
        {
            if(objectsInScene[i].transform.position.y< getMario().position.y)
            {
                objectsInScene[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = 3;
            }
            else
            {
                //objectsInScene[i].GetComponent<SpriteRenderer>().renderingLayerMask = 1;
                objectsInScene[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = 1;
                //objectsInScene[i].GetComponentInChildren<SpriteRenderer>().renderingLayerMask = 1;
            }
        }
    }
}
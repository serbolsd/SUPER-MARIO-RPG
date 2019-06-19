using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class Lectura_JSON : MonoBehaviour
{
    private string m_JSON;
    private JsonData m_BowsersKeep1;
    private int m_Texto = 0;
   
    void Start()
    {
        m_JSON = File.ReadAllText(Application.dataPath + "/dialogos.json");
        m_BowsersKeep1 = JsonMapper.ToObject(m_JSON);
        Debug.Log(m_BowsersKeep1["Dialogos"][m_Texto]);
    }

    void inputs()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_Texto++;
            Debug.Log(m_BowsersKeep1["Dialogos"][m_Texto]);
        }
    }
 
    void Update()
    {
        inputs();
    }
}

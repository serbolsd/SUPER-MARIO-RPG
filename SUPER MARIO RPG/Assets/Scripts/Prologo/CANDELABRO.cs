using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CANDELABRO : MonoBehaviour
{
    public Vector3 posOrigin;
    public Vector3 finalPos;
    public Vector3 MarioOriginPos;
    public Vector3 MarioFinalPos;
    public Transform marioPosActual;
    public bool isCutScene=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isCutScene)
        {
            return;
        }
        Vector3 vecActual = marioPosActual.position- MarioOriginPos;
        Vector3 vecFinal = MarioFinalPos- MarioOriginPos;
        float porcentaje= vecActual.magnitude / vecFinal.magnitude;
        if(porcentaje<0)
        {
            porcentaje = 0;
        }
        Vector3 thispos = finalPos - posOrigin;
        this.transform.position = posOrigin + (thispos * porcentaje);

//        this.transform.position=
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLetterSound : MonoBehaviour
{
   public HANDSELECT Filaw;
   public HANDSELECT Columna;
    public int FilawAnterior;
    public int ColumnaAnterior;
    public AudioClip MonoEffect;
    public AudioSource Reproducir;
    public void Start()
    {
        Reproducir.clip = MonoEffect;
        FilawAnterior = Filaw.fila;
        ColumnaAnterior = Columna.columna;
    }
    private void Update()
    {
        if (Filaw.fila!=FilawAnterior||Columna.columna!=ColumnaAnterior)
        {
            Reproducir.Play();
            FilawAnterior = Filaw.fila;
            ColumnaAnterior= Columna.columna;
        }

    }


}
//612 15 17 964
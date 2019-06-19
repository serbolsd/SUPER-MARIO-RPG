using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class cInteractable : MonoBehaviour
{
    public abstract bool interact(fsmMarioMachine _mm);
}

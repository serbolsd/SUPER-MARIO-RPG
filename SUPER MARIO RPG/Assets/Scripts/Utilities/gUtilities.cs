using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gUtilities : MonoBehaviour
{
    int Attack(cCharacter _char, cCharacter _target, float timingMod)
    {
        return (int)Mathf.Max(1, (_char.getATK() - _target.getDEF()) * timingMod);
    }


}

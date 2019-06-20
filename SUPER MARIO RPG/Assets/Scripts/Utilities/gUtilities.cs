using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gUtilities
{
    public const float kHORIZONTAL_DIR = 0.88205f;
    public const float kVERTICAL_DIR = 0.43800142f;

    const float stickDeadZone = 0.2f;

    int Attack(cCharacter _char, cCharacter _target, float timingMod)
    {
        return (int)Mathf.Max(1, (_char.getATK() - _target.getDEF()) * timingMod);
    }
}

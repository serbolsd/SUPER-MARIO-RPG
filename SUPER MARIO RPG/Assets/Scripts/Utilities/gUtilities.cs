using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class gUtilities
{
    public const float kHORIZONTAL_DIR = 0.88205f;
    public const float kVERTICAL_DIR = 0.43800142f;
    public const float kSTICKDEADZONE = 0.2f;
    public const float k512x448TO_CAM_SIZE = 0.446428f;
    public const float kCOMBAT_MENUACTION_OFFSET = 0.05f;

    public static cCharacter[] makeCharCopies(cCharacter cChar, int nCopies = 1, Transform parent = null)
    {
        if(nCopies < 1)
            nCopies = 1;
        cCharacter[] res = new cCharacter[nCopies];
        for(int i =0; i < nCopies; ++i)
        {
            res[i] = cChar;
            if (parent)
            {
                res[i].gameObject.transform.parent = parent;
            }
        }
        return res;
    }

    public static cCharacter[] makeCharArr(cCharacter cChar)
    {
        cCharacter[] res = new cCharacter[1];
        res[0] = cChar;
        return res;
    }
}

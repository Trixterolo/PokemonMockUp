using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Move
{

    public MoveBase MoveBase { get;  set; }

    public int PP { get;  set; }

    public Move(MoveBase pBase)
    {
        MoveBase = pBase;
        PP = pBase.GetPP();
       
    }
}

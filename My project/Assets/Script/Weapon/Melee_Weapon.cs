using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Weapon : Base_Weapon
{




    public void Init(int D,int P)//-1 ¹«ÇÑ
    {
        Damage= D;
        Per= P;

    }


    public override int Damage_Function()
    {

        
            Per--;
        
            return Damage;
        
        
    }
}

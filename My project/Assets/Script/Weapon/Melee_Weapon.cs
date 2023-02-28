using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Weapon : Base_Weapon
{




    public void Init(int Level,int P,int K)//-1 ¹«ÇÑ
    {
        Current_Damage= Level*Base_Damage;
        Per= P;
        KnockBack_Power= K;
    }


    public override int Damage_Function()
    {

        
            Per--;
        
            return Current_Damage;
        
        
    }
}

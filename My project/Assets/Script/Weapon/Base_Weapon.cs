using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base_Weapon : MonoBehaviour
{
    public int Damage;
    public int Per;


    public abstract int Damage_Function();

}

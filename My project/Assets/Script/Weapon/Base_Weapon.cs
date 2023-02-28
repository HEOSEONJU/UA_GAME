using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public abstract class Base_Weapon : MonoBehaviour
    {
    [SerializeField]
    protected int Base_Damage;
    
    protected int Current_Damage;
    [SerializeField]
    protected int Per;
    [SerializeField]
    public int KnockBack_Power;

    public abstract int Damage_Function();

    }


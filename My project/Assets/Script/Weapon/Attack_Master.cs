using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack_Master : MonoBehaviour
{
    
    protected int Level;
    [SerializeField]
    protected int MAX_Level;

    [SerializeField]
    protected int Knock_Back_Power;

    
    protected float Duration;
    [SerializeField]
    protected float Max_Duration;

    public abstract void Init(int Level);
}

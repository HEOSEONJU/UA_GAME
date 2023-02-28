using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Abstract_Bullet : MonoBehaviour
{
    [SerializeField]
    protected int Base_Damage;
    [SerializeField]
    protected int Current_Damage;
    [SerializeField]
    protected int Per;
    [SerializeField]
    protected float Duration;
    [SerializeField]
    protected float Max_Duration;
    [SerializeField]
    protected float Speed;
    [SerializeField]
    protected int KnockBack_Power;
    [SerializeField]
    protected Rigidbody2D _Rigid;
    protected Vector2 Front;
    public abstract void Fire(Transform Target);
    public abstract void Init(int Level,int Per, int KnockBack_Power);
}

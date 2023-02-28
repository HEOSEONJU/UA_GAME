using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Abstract_Enemy : MonoBehaviour
{
    public int  INDEX_ID;
    
    [SerializeField]
    protected float Current_HP;
    [SerializeField]
    protected float Damage;
    protected float Attack_Delay = 1.0f;
    protected float Current_Delay = 1.0f;
    [SerializeField]
    protected float Speed;
    [SerializeField]
    protected Rigidbody2D _Rigid;
    public bool Live=true;
    [SerializeField]
    protected Collider2D _Collider;
    [SerializeField]
    protected Animator _Animator;
    [SerializeField]
    protected Vector2 Dir;

    abstract public void Trace_Player();
    abstract public void Damaged(int D,int K);



}
public class Monster_Data
{

}


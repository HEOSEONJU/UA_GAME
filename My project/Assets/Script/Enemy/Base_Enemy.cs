using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Enemy : Abstract_Enemy
{
    

    WaitForFixedUpdate wait;

    private void Awake()
    {
        wait = new WaitForFixedUpdate();
    }

    private void OnEnable()
    {
        Live = true;
        int Level = 0;
        Enemy_Level_Data Temp = Player_Manager.instance.Data.Find_Monster(INDEX_ID);
        
        if (Player_Manager.instance._Status.Level>Temp.Max_Level)
        {
            Level=Temp.Max_Level;
        }
        else
        {
            Level = Player_Manager.instance._Status.Level;
        }
        Current_HP = Temp.HP[Level-1];
        Damage= Temp.Damage[Level-1];
        _Collider.enabled = true;
    }

    private void FixedUpdate()
    {
        

        if (!Live || _Animator.GetCurrentAnimatorStateInfo(0).IsTag("Hit")) 
        {
            
            return;
        }
        
        Trace_Player();
        if(Current_Delay<=Attack_Delay) 
        {
            Current_Delay += Time.deltaTime;
        }
    }
    public override void Trace_Player()
    {
        Dir =  Player_Manager.instance._Move._Rigid.position- _Rigid.position;
        if (Dir.x < 0)
        {

            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
            transform.rotation = Quaternion.identity;

        Vector2 NV = Dir.normalized * Speed * Time.fixedDeltaTime;
        _Rigid.MovePosition(_Rigid.position +NV);
       


    }

    public void Reset_Velocity()
    {
        _Rigid.velocity = Vector2.zero;
    }
    public override void Damaged(int D,int K)
    {
        if(_Animator.GetCurrentAnimatorStateInfo(0).IsTag("Hit"))
        {
            return;
        }
        Current_HP -= D;
        if (Current_HP <= 0) 
        {
            DIed();
            return;
        }
        //_Animator.SetTrigger("Hit");
        _Animator.CrossFade("Hit", 0.05f);
        
        StartCoroutine(KnokBack(K));
            
        
    }
    IEnumerator KnokBack(int K)
    {
        
        yield return wait;
        
        Vector3 dir = transform.position - Player_Manager.instance.transform.position;
        
        _Rigid.AddForce(dir.normalized * K, ForceMode2D.Impulse);

    }
    public void DIed()
    {
        Player_Manager.instance._Status.Get_Exp();
        _Rigid.velocity = Vector2.zero;
        Live = false;
        _Collider.enabled = false;
        _Animator.CrossFade("Die", 0.05f);


        Invoke("Delay",1.0f);

    }
    public void Delay()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && Attack_Delay <= Current_Delay && Live)
        {
            Player_Manager.instance._Status.HP_Cal(-Damage);
            Current_Delay = 0;

        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (!collision.CompareTag("Weapon") || !Live)
        {
            return;
            



        }
        Base_Weapon Temp = collision.GetComponent<Base_Weapon>();

        Damaged(Temp.Damage_Function(), Temp.KnockBack_Power);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Enemy : Abstract_Enemy
{
    [SerializeField]
    Vector2 Dir;


    private void OnEnable()
    {
        Live = true;
        Current_HP = MAX_HP;
        _Animator.SetBool("Dead", false);
        _Collider.enabled = true;
    }
    private void FixedUpdate()
    {
        if(!Live)
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

        _Rigid.MovePosition(_Rigid.position +( Dir.normalized * Speed * Time.fixedDeltaTime));
        _Rigid.velocity= Vector2.zero;


    }
    public override void Damaged(int D)
    {
        
        Current_HP -= D;
        if (Current_HP <= 0) 
        {
            DIed();
        }
        else
        {
            _Animator.SetTrigger("Hit");
        }
    }
    public void DIed()
    {
        
        Live = false;
        _Collider.enabled = false;
        _Animator.SetBool("Dead", true);
        Debug.Log(_Animator.GetBool("Dead"));

        Invoke("Delay",0.1f);

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
        
        if (collision.CompareTag("Weapon"))
        {
            
            Damaged(collision.GetComponent<Base_Weapon>().Damage_Function());



        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class Base_Bullet : Abstract_Bullet
{
    
    public override void Init(int Level, int Per,int K)
    {
        Current_Damage = Level * Base_Damage;
        this.Per = Per;
        this.KnockBack_Power = K;


    }
    public override void Fire(Transform Target)
    {
        if(Target == null) 
            return;
        transform.localPosition = Vector3.zero;
        Vector3 dir =(Target.position - transform.position).normalized;
        transform.rotation=Quaternion.FromToRotation(Vector3.up, dir);
        Duration = Max_Duration;
        Front = transform.up;
        StartCoroutine(Move_Bullet());
    }
    
    IEnumerator Move_Bullet()
    {

        
        while (Duration > 0.0f)
        {
            Duration -= Time.deltaTime;
            _Rigid.AddForce(Front);
            _Rigid.velocity=_Rigid.velocity.normalized * Speed;
            yield return null;
        }

        gameObject.SetActive(false);

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy") || Per < 0)
            return;

        Per--;
        
        _Rigid.velocity= Vector2.zero;
        collision.GetComponent<Base_Enemy>().Damaged(Current_Damage,KnockBack_Power);
        if (Per <= 0)
        {
            StopCoroutine(Move_Bullet());
            gameObject.SetActive(false);
        }

    }
}

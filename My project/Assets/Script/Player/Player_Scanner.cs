using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player_Scanner : MonoBehaviour
{
    [SerializeField]
    float Radius;
    [SerializeField]
    LayerMask Target;
     RaycastHit2D[] target;
    [SerializeField]
    Transform Near;

    public Transform Return_Near()
    {
        return Near;
    }

    public void Search()
    {
        target = Physics2D.CircleCastAll(transform.position, Radius,Vector2.zero,0,Target);
        Near = Near_Target();





    }
    public Transform Near_Target()
    {

        
        Vector2 This_Position = new Vector2(transform.position.x,transform.position.y);
        //RaycastHit2D distance 사용하면 0나와서 distance안씀
        Array.Sort(target, (RaycastHit2D x, RaycastHit2D y) => ((x.point - This_Position).magnitude.CompareTo( (y.point- This_Position).magnitude)));//거리순 정렬
        
        if (target.Length > 0 )
        {
            
            return target[0].transform;
        }

        return null;
        
    }
}

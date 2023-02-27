using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Animator : MonoBehaviour
{
    [SerializeField]
    Animator System_Animator;
    



    public void Change_Animation(Vector2 dir)
    {
        if(dir.magnitude==0)
        {
            System_Animator.SetBool("Move", false);
            
        }
        else
        {
            System_Animator.SetBool("Move", true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Map_Move : MonoBehaviour
{
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!collision.CompareTag("Area"))
        {
            return;
        }
        Vector3 Player_Position = Player_Manager.instance.transform.position;
        float Dis_X = Mathf.Abs(Player_Position.x-transform.position.x);
        float Dis_Y = Mathf.Abs(Player_Position.y - transform.position.y);



        Vector2 Dir = Player_Manager.instance._Input.Output_Axis();
        float Dir_X = Dir.x<0 ? -1 : 1;
        float Dir_Y = Dir.y < 0 ? -1 : 1;

        if (Dis_X>Dis_Y)
        {
            transform.Translate(Vector3.right * 40*Dir_X);   
        }

        else if(Dis_X<Dis_Y)
        {
            transform.Translate(Vector3.up * 40 *Dir_Y);
        }
        
    }
    
}

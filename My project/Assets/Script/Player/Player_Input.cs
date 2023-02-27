using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    [SerializeField]
    Vector2 Dir_Vec;
    
    public void Input_Axis()
    {
        Dir_Vec.x = Input.GetAxis("Horizontal");
        Dir_Vec.y = Input.GetAxis("Vertical");
        
    }
    public Vector2 Output_Axis()
    {
        return Dir_Vec.normalized;
    }
}

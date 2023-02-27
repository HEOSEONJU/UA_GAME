using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    [SerializeField]
    public Rigidbody2D _Rigid;
    [SerializeField]
    float Speed = 1;
    [SerializeField]
    Transform Main_Camera;
    [SerializeField]
    float Camera_Distance;

    public void Camera_Move(Vector3 Position)
    {
        Position.z = Camera_Distance;
        Main_Camera.position = Position;
    }
    public void Normal_Move(Vector2 dir)
    {
        
        _Rigid.velocity= dir*Speed*Time.fixedDeltaTime;
            

    }
    public Dir_Char Return_Dir_Char(Vector2 dir, Dir_Char Dir_enum)
    {
        if (dir.x == 0)
            return Dir_enum;
        else if (dir.x>0)
            return Dir_Char.Right;
        else
            return  Dir_Char.Left;

        
    }
    public void Change_Dir_Char(Dir_Char Dir_enum) 
    {
        Vector3 dir = Vector3.zero;
        if(Dir_enum==Dir_Char.Left)
        {
            dir.y = -180;
        }
        transform.GetChild(0).rotation = Quaternion.Euler(dir);
    }
    public void Change_Speed(float speed) 
    {
        Speed= speed;
    }

}
public enum Dir_Char
{
    Left, Right
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.SceneView;

public class Player_Manager : MonoBehaviour
{
    public static Player_Manager instance;
    [SerializeField]
    public Player_Move _Move;
    [SerializeField]
    public Player_Input _Input;
    [SerializeField]
    public Dir_Char Current_Dir_Char;
    [SerializeField]
    public Player_Status _Status;

    [SerializeField]
    Player_Animator _Animator;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        _Input.Input_Axis();
        _Status.View_HP();
        Current_Dir_Char =_Move.Return_Dir_Char(_Input.Output_Axis(), Current_Dir_Char);
        _Move.Change_Dir_Char(Current_Dir_Char);
    }
    private void FixedUpdate()
    {
        _Move.Normal_Move(_Input.Output_Axis());
        _Move.Camera_Move(transform.position);
    }
    private void LateUpdate()
    {
        _Animator.Change_Animation(_Input.Output_Axis());
    }
}

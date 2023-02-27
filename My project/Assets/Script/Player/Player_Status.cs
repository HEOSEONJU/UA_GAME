using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Status : MonoBehaviour
{
    [SerializeField]
    float MAX_HP;
    [SerializeField]
    float Current_HP;
    [SerializeField]
    Slider HPSlider;

    bool Live = true;
    public  void View_HP()
    {
        HPSlider.value=Current_HP/MAX_HP;
    }

    public float Return_Hp()
    {
        return Current_HP;
    }

    public void HP_Cal(float value)
    {
        Current_HP += value;



        if(Current_HP>=MAX_HP) 
        {
            Current_HP = MAX_HP;
        }
        else if(Current_HP < 0) 
        {
            Live = false;
            //게임오버안들기
        }
        

    }

}

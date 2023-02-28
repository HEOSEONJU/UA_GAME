using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;


public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    Text Level;
    [SerializeField]
    Text Kill;
    [SerializeField]
    Slider Exp_Slider;
    [SerializeField]
    Text Time;
    public void View_UI()
    {
        Level.text ="Lv."+Player_Manager.instance._Status.Level;
        Kill.text =  Player_Manager.instance._Status.Kill.ToString();
        
       Exp_Slider.value=(float)Player_Manager.instance._Status.exp / Player_Manager.instance._Status.Next_Exp[Player_Manager.instance._Status.Level-1];
        float remian=Player_Manager.instance.Max_GameTime - Player_Manager.instance.GameTime;
        int min = Mathf.FloorToInt(remian / 60);
        int sec = Mathf.FloorToInt(remian % 60);

        Time.text = string.Format("{0:D2}:{1:D2}", min, sec);

    }
    
}

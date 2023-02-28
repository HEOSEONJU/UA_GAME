using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(menuName = "Enemy")]
public class Enemy_Data : ScriptableObject
{



    
    public List<Enemy_Level_Data> Data;



    public Enemy_Level_Data Find_Monster(int INDEX)//ÀÌÁøÅ½»ö
    {
        if (INDEX == 0)
        {
            return null;
        }
        int Low = 0;
        int High = Data.Count - 1;
        int Mid;
        while (Low <= High)
        {
            Mid = (Low + High) / 2;
            if (Data[Mid].ID == INDEX)
            {
                return Data[Mid];
            }
            else if (Data[Mid].ID > INDEX)
            {
                High = Mid - 1;
            }
            else
            {
                Low = Mid + 1;
            }

        }
        return null;
    }
}

[Serializable]
public class Enemy_Level_Data
{
    public int ID;
    public int Max_Level;

    public List<int> HP;
    public List<int> Damage;
}

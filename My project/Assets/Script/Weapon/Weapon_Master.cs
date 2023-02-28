using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class Weapon_Master : Attack_Master
{
    [SerializeField]
    UnityEngine.GameObject Weapon;
    
    [SerializeField]
    float Speed;

    [SerializeField]
    List<UnityEngine.GameObject> WeaponList;
    [SerializeField]
    bool Active=false;
    [SerializeField]
    float Delay;
    [SerializeField]
    float Max_Delay=5;

    private void Start()
    {
        Init(++Level);
    }
    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < WeaponList.Count; i++)
            {
                WeaponList[i].SetActive(false);
            }
            Init(++Level);
        }

    }
    
    IEnumerator Active_Weapon()
    {
        
        transform.rotation= Quaternion.identity;
        while (Duration > 0.0f)
        {
            Duration -= Time.deltaTime;
            transform.Rotate(Vector3.back, Speed * Time.deltaTime);
            yield return null;
        }

        for (int i = 0; i < WeaponList.Count; i++)
        {
            WeaponList[i].SetActive(false);
        }
        Active=false;
        
        StartCoroutine(Delay_Next_Attack());
    }

    IEnumerator Delay_Next_Attack()
    {
        Delay = Max_Delay;
        while (Delay > 0.0f)
        {
            Delay -= Time.deltaTime;
            
            yield return null;
        }
        Active = true;
        
        Init(++Level);


    }
    public override void Init(int Level)
    {
        if(!Active)
        {
            return;
        }

        if (Level == WeaponList.Count)
        {
            for (int i = 0; i < WeaponList.Count; i++)
            {
                WeaponList[i].SetActive(true);
            }
            StartCoroutine(Active_Weapon());
            return;
        }
        Duration = Max_Duration;
        transform.rotation=Quaternion.identity;
        for (int i = WeaponList.Count; i < Level; i++)
        {
            var e = Instantiate(Weapon, this.transform);
            
            WeaponList.Add(e);
            Melee_Weapon temp= e.GetComponent<Melee_Weapon>();
            temp.Init(Level, -1, temp.KnockBack_Power);
        }


        for (int i = 0; i < WeaponList.Count; i++)
        {
            WeaponList[i].transform.localPosition= Vector3.zero;
            WeaponList[i].transform.rotation = Quaternion.identity;
            Vector3 Rot = Vector3.forward * 360 * i / Level;
            WeaponList[i].transform.Rotate(Rot);
            WeaponList[i].transform.Translate(WeaponList[i].transform.up * 1.5f, Space.World);
            WeaponList[i].SetActive(true);
        }
        StartCoroutine(Active_Weapon());
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class Weapon_Master : MonoBehaviour
{
    [SerializeField]
    GameObject Weapon;
    [SerializeField]
    int Level;
    [SerializeField]
    int MAX_Level;
    [SerializeField]
    float Speed;
    
    [SerializeField]
    List<GameObject> WeaponList;

    private void Start()
    {
        Init(Level);
    }
    private void Update()
    {
        transform.Rotate(Vector3.back, Speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < WeaponList.Count; i++)
            {
                WeaponList[i].SetActive(false);
            }
                Init(++Level);
        }

    }

    public void Init(int Level)
    {
        
        if(Level== WeaponList.Count)
        {
            for (int i = 0; i < WeaponList.Count; i++)
            {
                WeaponList[i].SetActive(true);
            }
            return;
        }
        

        for (int i= WeaponList.Count; i<Level;i++)
        {
            var e =Instantiate(Weapon,this.transform);
            WeaponList.Add(e);
            e.GetComponent<Melee_Weapon>().Init(10, -1);
        }


        for (int i = 0; i < WeaponList.Count; i++)
        {
            WeaponList[i].transform.position = Vector3.zero;
            WeaponList[i].transform.rotation = Quaternion.identity;
            Vector3 Rot = Vector3.forward * 360 * i / Level;
            WeaponList[i].transform.Rotate(Rot);
            WeaponList[i].transform.Translate(WeaponList[i].transform.up * 1.5f, Space.World);
            WeaponList[i].SetActive(true);
        }

    }

}

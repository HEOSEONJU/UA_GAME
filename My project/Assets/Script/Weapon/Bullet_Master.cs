using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Master : Attack_Master
{

    [SerializeField]
    UnityEngine.GameObject Bullet;
    
    

    [SerializeField]
    List<Base_Bullet> BulletList;

    [SerializeField]
    int Per;

    


    private void Update()
    {
        Duration-=Time.deltaTime;
        if(Player_Manager.instance._Scanner.Return_Near()==null)
        {
            return;
        }
        if(Duration< 0)
        {
            Init(Level);
        }



    }

    
    
    public override void Init(int Level)
    {

        foreach(Base_Bullet b in BulletList)
        {
            
            if(!b.gameObject.activeSelf)
            {
                b.gameObject.SetActive(true);
                b.Init(Level, Per,Knock_Back_Power);
                b.Fire(Player_Manager.instance._Scanner.Return_Near());
                Duration = Max_Duration;
                return;
            }
        }

        
        
        var e = Instantiate(Bullet, this.transform).GetComponent<Base_Bullet>();
        BulletList.Add(e);

        BulletList[BulletList.Count-1].Init(Level, Per,Knock_Back_Power);
        BulletList[BulletList.Count - 1].Fire(Player_Manager.instance._Scanner.Return_Near());
        Duration = Max_Duration;

        
    }
}

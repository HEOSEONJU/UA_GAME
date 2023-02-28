using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Spawn_Object;
    
    [SerializeField]
    List<GameObject> Pooling;

    [SerializeField]
    List<Transform> Spawn_Position;
    [SerializeField]
    Transform Spawn_Transform;
    int INDEX = 0;

    [SerializeField]
    float Spawn_Time;
    private void Awake()
    {
        Pooling = new List<GameObject>();
        
    }

    float time = 0;
    private void Update()
    {
        
        time+= Time.deltaTime;
        if(time>= Spawn_Time)
        {
            time= 0;
            Spawn_Function();
        }
    }


    public void Spawn_Function()
    {



        foreach(GameObject obj in Pooling) 
        {
            if(!obj.activeSelf)
            {
                obj.SetActive(true);
                obj.transform.position = Spawn_Position[INDEX++].position;
                if (Spawn_Position.Count == INDEX)
                {
                    INDEX = 0;
                }
                return;
            }
        }

        var e = Instantiate(Spawn_Object, Spawn_Position[INDEX++].position, Quaternion.identity, Spawn_Transform);

        Pooling.Add(e);

        if(Spawn_Position.Count==INDEX)
        {
            INDEX = 0;
        }

    }
}

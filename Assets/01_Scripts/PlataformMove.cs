using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformMove : MonoBehaviour
{
    public GameObject MoveObject;
    public Transform StartPoint;
    public Transform EndPoint;
    public float speed;
    public Vector3 MoveGo;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject.transform.position=Vector3.MoveTowards(MoveObject.transform.position, MoveGo, speed*Time.deltaTime);
        if(MoveObject.transform.position==EndPoint.position)
        {
            MoveGo=StartPoint.position;
        }
        if(MoveObject.transform.position == StartPoint.position)
        {
            MoveGo=-EndPoint.position;
        }
    }
}

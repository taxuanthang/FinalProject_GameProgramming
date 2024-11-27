using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public GameObject sheepGameObject { set; get; }
    public Rigidbody2D rb { set; get; }
    public int number { set; get; }
    public int runspeed { set; get; }
    public Sheep(GameObject sheepObject, int number, int runspeed)
    {
        this.sheepGameObject = sheepObject;
        this.number = number;
        this.runspeed = runspeed;
        rb = sheepObject.GetComponent<Rigidbody2D>();
    }
}

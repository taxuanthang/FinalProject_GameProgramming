using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public GameObject sheepObject { set; get; }
    public Rigidbody2D rb { set; get; }
    public int nubmer { set; get; }
    public int runspeed { set; get; }
    public Sheep(GameObject sheepObject, int number, int runspeed)
    {
        this.sheepObject = sheepObject;
        this.nubmer = number;
        this.runspeed = runspeed;
        rb = sheepObject.GetComponent<Rigidbody2D>();
    }
}

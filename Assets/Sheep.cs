using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sheep : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D Collider2D;
    public int number;
    public int runspeed;
    public int mass;

    [HideInInspector]
    public bool isFlagged = false;

    //SetUp
    public void SetUp() 
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.rb.mass = this.mass;
        this.Collider2D = GetComponent<Collider2D>();
    }
    
    //Moving
    public void Jump()
    {
        this.rb.AddForce(Vector2.up * this.runspeed, ForceMode2D.Impulse);
    }
    public void Move(string dir)
    {
        Vector2 vectorDir = Vector2.zero;
        if (dir == "right")
        {
            vectorDir = Vector2.right;
        }
        if (dir == "left")
        {
            vectorDir = Vector2.left;
        }
        if (Mathf.Abs(this.rb.velocity.x) < this.runspeed)
        {
            this.rb.AddForce(vectorDir * this.runspeed / 2, ForceMode2D.Force);
        }
    }

    //Check collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print(collision.transform.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Flag")
        {
            isFlagged = true;
            print(this.name+"Enter");
            SheepHandler.Instance.NumberSheepFlagged += 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Flag")
        {
            isFlagged = false;
            SheepHandler.Instance.NumberSheepFlagged -= 1;
        }
    }

    //

}
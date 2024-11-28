using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

//                       _oo0oo_
//                      o8888888o
//                      88" . "88
//                      (| -_- |)
//                      0\  =  /0
//                    ___/`---'\___
//                  .' \\|     |// '.
//                 / \\|||  :  |||// \
//                / _||||| -:- |||||- \
//               |   | \\\  -  /// |   |
//               | \_|  ''\---/''  |_/ |
//               \  .-\__  '-'  ___/-. /
//             ___'. .'  /--.--\  `. .'___
//          ."" '<  `.___\_<|>_/___.' >' "".
//         | | :  `- \`.;`\ _ /`;.`/ - ` : | |
//         \  \ `_.   \_ __\ /__ _/   .-` /  /
//     =====`-.____`.___ \_____/___.-`___.-'=====
//                       `=---='
//
//     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//            Phật phù hộ, không bao giờ BUG
//     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

[System.Serializable]
public class Sheep 
{
    public GameObject sheepsPrefab;
    public GameObject sheepGameObject { set; get; }
    private Rigidbody2D rb;
    private Collider2D Collider2D;
    public int number;
    public int runspeed;
    public int mass;
    public Vector2 bornPos;

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log(collision.name);
    //}
    public void BornSheep()
    {
        sheepGameObject = GameObject.Instantiate(sheepsPrefab, bornPos, Quaternion.identity);
        this.rb = sheepGameObject.GetComponent<Rigidbody2D>();
        this.rb.mass = this.mass;
        this.Collider2D = this.sheepGameObject.GetComponent<Collider2D>();
    }
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


}

public class SheepHandler : MonoBehaviour
{
    public List<Sheep> sheeps;
    private Sheep targetSheep;
    public GameObject sheepArrow;
    UnityEngine.Vector2 vectorDir = new UnityEngine.Vector2(0,0);

    private bool isJumped;
    private void Awake()
    {
        //sinh cuu
        foreach (var sheep in sheeps)
        {
            sheep.BornSheep();
        }

        //gan cuu
        targetSheep = sheeps[0];

    }

 
    public void CharterInputControl()
    {
        //Moving Left Right
        if (Input.GetKey(KeyCode.A))
            {
                targetSheep.Move("left");
            }
        if (Input.GetKey(KeyCode.D))
            {
                targetSheep.Move("right");
            }

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W))
        {
            targetSheep.Jump();
        }

        //Switching sheep
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            targetSheep = sheeps[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            targetSheep = sheeps[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            targetSheep = sheeps[2];
        }

    }

    
    private void Update()
    {
        CharterInputControl();
        //dieu khien cuu duoc chon
        
        //print(targetSheep.sheepGameObject.transform.position);
    }
}

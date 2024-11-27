using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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
public class SheepHandler : MonoBehaviour
{
    [SerializeField] List<GameObject> sheepsObject;
    private List<Sheep> sheeps;
    private Sheep targetSheep;
    public GameObject sheepArrow;
    UnityEngine.Vector2 vectorDir = new UnityEngine.Vector2(0,0);

    private void Awake()
    {
        sheeps = new List<Sheep>() 
        {
            new Sheep(sheepsObject[0],0,10),
            new Sheep(sheepsObject[1],1,10),
            new Sheep(sheepsObject[2],2,10),
        };

        targetSheep = sheeps[0];
        print(sheeps.Count);
    }
    public void CharterControl()
    {
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    vectorDir = new UnityEngine.Vector2(1, 0);
        //}
        if (Input.GetKeyDown(KeyCode.A))
        {
            vectorDir = new UnityEngine.Vector2(1, 0);
            targetSheep.rb.AddForce(targetSheep.runspeed * vectorDir, ForceMode2D.Force);
        }
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    vectorDir = new UnityEngine.Vector2(1, 0);
        //}
        if (Input.GetKeyDown(KeyCode.D))
        {
            vectorDir = new UnityEngine.Vector2(-1, 0);
            targetSheep.rb.AddForce(targetSheep.runspeed * vectorDir, ForceMode2D.Force);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            vectorDir = new UnityEngine.Vector2(0, 1);
            targetSheep.rb.AddForce(targetSheep.runspeed * vectorDir, ForceMode2D.Force);
        }
        
    }
    private void Update()
    {
        CharterControl();
    }
}

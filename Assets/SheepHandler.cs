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
public class SheepHandler : MonoBehaviour
{
    public GameObject cube;
    [SerializeField] List<GameObject> sheepsPrefab;
    private List<Sheep> sheeps;
    private Sheep targetSheep;
    public GameObject sheepArrow;
    UnityEngine.Vector2 vectorDir = new UnityEngine.Vector2(0,0);

    private void Awake()
    {
        sheeps = new List<Sheep>() 
        {
            new(Instantiate(sheepsPrefab[0],new Vector2(1,0),Quaternion.identity),0,10),
            new(Instantiate(sheepsPrefab[1],new Vector2(1,0),Quaternion.identity),1,11),
            new(Instantiate(sheepsPrefab[2],new Vector2(1,0),Quaternion.identity),2,12),
        };
        
        targetSheep = sheeps[0];

    }
    public void CharterControl()
    {
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    vectorDir = new UnityEngine.Vector2(1, 0);
        //}
        if (Input.GetKeyDown(KeyCode.A))
        {
            vectorDir = new UnityEngine.Vector2(-1, 0);
            targetSheep.rb.AddForce(targetSheep.runspeed * vectorDir, ForceMode2D.Impulse);
            print(vectorDir);
        }
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    vectorDir = new UnityEngine.Vector2(1, 0);
        //}
        if (Input.GetKeyDown(KeyCode.D))
        {
            vectorDir = new UnityEngine.Vector2(1, 0);
            targetSheep.rb.AddForce(targetSheep.runspeed * vectorDir, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            vectorDir = new UnityEngine.Vector2(0, 1);
            targetSheep.rb.AddForce(targetSheep.runspeed * vectorDir, ForceMode2D.Impulse);
        }
        
    }
    private void Update()
    {
        CharterControl();
        print(targetSheep.sheepGameObject.transform.position);
    }
}

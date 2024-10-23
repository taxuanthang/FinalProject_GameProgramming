using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class SheepHandler : MonoBehaviour
{
    public GameObject[] sheeps;
    private Rigidbody2D sheepRb;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputAction;
    private GameObject sheepArrow;

    private void Awake()
    {
        sheepRb = sheeps[1].GetComponent<Rigidbody2D>();
        sheepArrow = sheepRb.transform.GetChild(0).gameObject;
        playerInput = GetComponent<PlayerInput>();

        playerInputAction = new PlayerInputActions();
        playerInputAction.Player.Enable();
        playerInputAction.Player.Jump.performed += Jump;
        //playerInputAction.Player.Movement.performed += Movement_performed;
    }
    public void Movement_performed(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
        Vector2 inputVector = context.ReadValue<Vector2>();
        float speed = 100f;
        sheepRb.AddForce(new Vector2(inputVector.x, inputVector.y) * speed, ForceMode2D.Force);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump"+context.phase);
        sheepRb.AddForce(Vector2.up * 5f , ForceMode2D.Impulse);
    }
    private void Update()
    {
        //Switch sheep
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            sheepRb = sheeps[0].GetComponent<Rigidbody2D>();
            sheepArrow.transform.SetParent(sheepRb.transform, false);
            //sheepArrow.transform.SetLocalPositionAndRotation(new Vector3(0f,2f,0f),new Quaternion(0f,0f,0f,0f));
        }
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            sheepRb = sheeps[1].GetComponent<Rigidbody2D>();
            sheepArrow.transform.SetParent(sheepRb.transform, false);

        }
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            sheepRb = sheeps[2].GetComponent<Rigidbody2D>();
            sheepArrow.transform.SetParent(sheepRb.transform, false);
        }
    }
    //Update is called once per frame
    void FixedUpdate()
    {
        //moving sheep
        Vector2 inputVector = playerInputAction.Player.Movement.ReadValue<Vector2>();
        float speed = 10f;
        sheepRb.AddForce(new Vector2(inputVector.x, inputVector.y) * speed, ForceMode2D.Force);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class controls : MonoBehaviour
{
    float speed = 6;
    float rotSpeed = 80;
    float gravity = 10;
    float rot = 0f;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Moverse();
        GetInput();
    }

    void Moverse()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if(anim.GetBool("isJumping") == true)
                {
                    return;
                }
                else if (anim.GetBool("isJumping") == false)
                {
                    anim.SetBool("isRunning", true);
                    anim.SetInteger("condition", 1);
                    moveDir = new Vector3(0, 0, 1);
                    moveDir *= speed;
                    moveDir = transform.TransformDirection(moveDir);
                }
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetBool("isRunning", false);
                anim.SetInteger("condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }

    void GetInput()
    {
        if(controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if(anim.GetBool("isRunning") == true)
                {
                    anim.SetBool("isRunning",false);
                    anim.SetInteger("condition", 0);
                }
                if(anim.GetBool("isRunning") == false)
                {
                    Jump();
                }
            }
        }
    }

    void Jump()
    {
        StartCoroutine (JumpRoutine());
    }

    IEnumerator JumpRoutine()
    {
        anim.SetBool("isJumping", true);
        anim.SetInteger("condition", 2);
        yield return new WaitForSeconds(1);
        anim.SetInteger("condition", 0);
        anim.SetBool("isJumping", false);
    }
}

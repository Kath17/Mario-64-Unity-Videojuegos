using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    //public Rigidbody myRB;
    public float moveSpeed = 15f;
    public float jumpForce = 35f;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale = 8f;

    // ------ Animator -------//
    public Animator anim;
    // ------ Pivot ------ //
    public Transform pivot;
    public float rotateSpeed;

    public GameObject playerModel;

    
    void Start() {
        //myRB = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
 
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) +(transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        if(controller.isGrounded)
        {
            anim.SetBool("isGrounded", true);
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        //Move the player in different directions based on camera look direction
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed*Time.deltaTime);
        }

        if(moveDirection.y>0)
        {
            // ------- Animator -------//
            anim.SetBool("isGrounded", false);
        }
        //anim.SetBool("isGrounded", controller.isGrounded);
        anim.SetFloat("speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
    }
}

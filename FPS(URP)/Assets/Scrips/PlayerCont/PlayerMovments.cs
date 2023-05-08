using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovments : MonoBehaviour
{
    //tradistional way to move player
    private float x, y;
    private Vector3 move;
    
    public CharacterController characterController;
    public float speed = 5f;
    Vector3 gravityVictor;
    public float gravity = -9.81f;

    public bool isGrounded;
    public Transform groundTrans;
    public float groundDist = 0.5f;
    public LayerMask groundLayer;
    public float jumpHight = 2f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundTrans.position,groundDist,groundLayer);

        if(isGrounded && gravityVictor.y < 0)
        {
            gravityVictor.y = -2f;
        }

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        move = (transform.right * x + transform.forward*y) * Time.deltaTime;
        characterController.Move(move * speed);

        gravityVictor.y += gravity * Time.deltaTime;
        characterController.Move(gravityVictor * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            gravityVictor.y = Mathf.Sqrt(jumpHight * -2 * gravity);
        }
    }
}

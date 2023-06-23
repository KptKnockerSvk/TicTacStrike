using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource chuteSound;
    [SerializeField] AudioSource trampSound;


    public GameObject[] paradrop;
    int chuteSwitch = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        if (Input.GetButtonDown("Chute") && !IsGrounded())
        {
            Parachute();
        }
        if (IsGrounded() && chuteSwitch % 2 != 0)
        {
            for (int i = 0; i < paradrop.Length; i++)
            {                
                Parachute();
            }
        }
        

    }
    void Parachute()
    {
        chuteSound.Play();
        bool val;

        if (chuteSwitch % 2 == 0)
        {
            val = true;
            GetComponent<Rigidbody>().drag = 10;

        }
        else
        {
            val = false;
            GetComponent<Rigidbody>().drag = 0;
        }
        chuteSwitch++;
        for (int i = 0; i < paradrop.Length; i++)
        {
            paradrop[i].GetComponent<MeshRenderer>().enabled = val;
        }
       
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpSound.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
        if (collision.gameObject.CompareTag("Trampoline"))
        {
            jumpForce = 10f;
            Jump();
            jumpForce = 5f;
            trampSound.Play();
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}

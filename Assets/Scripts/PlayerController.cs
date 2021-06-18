using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;//move speed
    public float jumpHeight;//jump
    public bool isGrounded;
    private Rigidbody rb;

    public bool inWindZone = false;
    public GameObject windZone;//var to get the collision


    public Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        
    }

    private void FixedUpdate()
    {
        if(inWindZone)//check if players is on wind zone
        {
            rb.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strengh);//get script WindArea and change the variables there
        }
    }

    //Function to move and jump
    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");//Get horizontal axis
        float moveVertical = Input.GetAxis("Vertical");//Get Vertical axis
        Vector3 movement = new Vector3(moveVertical, 0.0f, moveHorizontal);//Vector3 to move
        rb.AddForce(movement * speed * Time.deltaTime);//physic to move
        if (isGrounded)//check if player is on ground
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpHeight);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        //collisions between phases
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Enter");
        }

        if(other.gameObject.name == "Finish")
        {
            Debug.Log("Chegou");
        }

        if(other.gameObject.name == "Lava")
        {
            transform.position = startPosition;
        }

        if (other.gameObject.CompareTag("Mola"))
        {
            Debug.Log("Pra cima");
            rb.AddForce(Vector3.up * 25, ForceMode.Impulse);
        }

        if (other.gameObject.CompareTag("Needle"))
        {
            transform.position = startPosition;
        }

        if(other.gameObject.tag == "windArea")
        {
            windZone = other.gameObject;
            inWindZone = true;
        }

        if (other.gameObject.CompareTag("Navalha"))
        {

            transform.position = startPosition;
        }

        if (other.gameObject.CompareTag("Saw"))
        {

            transform.position = startPosition;
        }




    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("Exited");
        }

        if(other.gameObject.tag == "windArea")
        {
            inWindZone = false;
        }
    }
}

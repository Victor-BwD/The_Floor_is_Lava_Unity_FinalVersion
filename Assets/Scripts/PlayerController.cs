using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public bool isGrounded;
    private Rigidbody rb;

    public bool inWindZone = false;
    public GameObject windZone;


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
        if(inWindZone)
        {
            rb.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strengh);
        }
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveVertical, 0.0f, moveHorizontal);
        rb.AddForce(movement * speed * Time.deltaTime);
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpHeight);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {


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

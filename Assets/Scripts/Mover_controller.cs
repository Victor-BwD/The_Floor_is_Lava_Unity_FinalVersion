using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mover_controller : MonoBehaviour
{
    [SerializeField] private float speed;//move speed
    [SerializeField] private float jumpHeight;//jump
    private bool isGrounded;
    private Rigidbody rb;

    public float rotationSpeed;


    private bool inWindZone = false;
    public GameObject windZone;//var to get the collision


    public Vector3 startPosition;
    public Quaternion updatedRotation;
    private Vector3 zero;
    public Vector3 roundVelocity;

    private Quaternion _facing;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;

        zero = new Vector3(0,0,0);
    }

    private void Update()

    {



    }

    private void FixedUpdate()

    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpHeight);
        }

        roundVelocity = new Vector3(Mathf.Round(rb.velocity.x), Mathf.Round(rb.velocity.y), Mathf.Round(rb.velocity.z));    
        
        if(roundVelocity==zero){
            updatedRotation = transform.rotation;
        }

        Move();
        
        //MoveAxis();
        //MoveAxis2();

        if(inWindZone)//check if players is on wind zone
        {
            rb.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strengh);//get script WindArea and change the variables there
        }

    }

    void Move()
    {
      
        if(Input.GetKey(KeyCode.W) )
        {
            if(rb.velocity!=zero && isGrounded){
                rb.velocity = zero;
                transform.rotation = new Quaternion(0f, updatedRotation.y, 0f, updatedRotation.w); 
            }

            transform.position += transform.forward * Time.deltaTime * speed;
            
        }

        if(Input.GetKey(KeyCode.S))
        {
            if(rb.velocity!=zero && isGrounded){
                rb.velocity = zero;
                transform.rotation = new Quaternion(0f, updatedRotation.y, 0f, updatedRotation.w); 
            }

            
            transform.position += transform.forward * Time.deltaTime * -speed;
            
        }

        if(Input.GetKey(KeyCode.A))
        {
            if(rb.velocity!=zero && isGrounded){
                rb.velocity = zero;
                transform.rotation = new Quaternion(0f, updatedRotation.y, 0f, updatedRotation.w); 
            }

            
            transform.Rotate(0f,  -rotationSpeed * Time.deltaTime, 0f);
        }

        if(Input.GetKey(KeyCode.D))
        {
            if(rb.velocity!=zero && isGrounded){
                rb.velocity = zero;
                transform.rotation = new Quaternion(0f, updatedRotation.y, 0f, updatedRotation.w); 
            }

            
            transform.Rotate( 0f,  rotationSpeed * Time.deltaTime, 0f);
        }
    }

    
    void MoveAxis()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");//Get horizontal axis
        float moveVertical = Input.GetAxis("Vertical");//Get Vertical axis
        Vector3 movement = new Vector3(moveVertical, 0.0f, moveHorizontal);//Vector3 to move

        rb.AddForce(movement * speed * Time.deltaTime);//physic to move 
 

    }

    void MoveAxis2()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, translation);

        transform.Rotate(0, rotation, 0);
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Enter");
        }

        if(other.gameObject.CompareTag("ZeroVel"))
        {
            rb.velocity = zero;
            Debug.Log("ZeroVel");
        }

        if(other.gameObject.CompareTag("Rampa"))
        {
            isGrounded = true;
            Debug.Log("Enter");
        }

        if(other.gameObject.name == "Finish")
        {
            Debug.Log("Trocar fase 2");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if(other.gameObject.name == "Lava")
        {

            Invoke("Restart",1f);
            
        }

        if (other.gameObject.CompareTag("Mola"))
        {
            Debug.Log("Pra cima");
            rb.AddForce(Vector3.up * 25, ForceMode.Impulse);
        }

        if (other.gameObject.CompareTag("Mola phase 3"))
        {
            Debug.Log("Pra cima");
            rb.AddForce(Vector3.up * 15, ForceMode.Impulse);
        }

        if (other.gameObject.CompareTag("Needle"))
        {

            Invoke("Restart",1f);
        }

        if(other.gameObject.tag == "windArea")
        {
            windZone = other.gameObject;
            inWindZone = true;
        }

        if (other.gameObject.CompareTag("Navalha"))
        {

            Invoke("Restart",1f);
        }

        if (other.gameObject.CompareTag("Saw"))
        {

            Invoke("Restart",1f);
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

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //private Quaternion _facing;
 
 //void Start () {
     //Grab the offset at the start.
     //You could also make your own Quaternion but don't use Euler angles it just seems to break things.
     //_facing = transform.rotation;
 //}
 //void Update () {
     //var rotation = Quaternion.LookRotation(directionVector.normalized);
    // rotation *= _facing;
    // transform.rotation = rotation;
 //}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject mover;
    private Vector3 zero;
    public Rigidbody rbMover;

    private float rotSpeed;

    void Start (){
        rotSpeed = 500f;
        zero = new Vector3(0,0,0);
    }

    void Update()
    {
        transform.position = mover.transform.position;

        if (Input.anyKey){
            if(Input.GetKey(KeyCode.W))
                {
                    transform.Rotate(rotSpeed * Time.deltaTime, 0f, 0f,Space.Self);
                }

            if(Input.GetKey(KeyCode.S))
                {
                    transform.Rotate(-rotSpeed * Time.deltaTime, 0f, 0f,Space.Self);
                }

            if(Input.GetKey(KeyCode.A))
                {
                    transform.rotation = new Quaternion (transform.rotation.x, mover.transform.rotation.y, transform.rotation.z, mover.transform.rotation.w );
                }
            
            if(Input.GetKey(KeyCode.D))
                {
                    transform.rotation = new Quaternion (transform.rotation.x, mover.transform.rotation.y, transform.rotation.z, mover.transform.rotation.w);
                }
            
        }else{
            transform.rotation = mover.transform.rotation;
        }
    }

}

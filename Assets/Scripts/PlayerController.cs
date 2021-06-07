using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveVertical, 0.0f, moveHorizontal);
        rb.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector3.up * jumpHeight);
        }
    }
}

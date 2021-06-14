using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float dashSpeed;
    Rigidbody rb;
    bool isDashing;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isDashing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            Dashing();
        }
    }

    private void Dashing()
    {
        rb.AddForce(Vector3.left * dashSpeed, ForceMode.Impulse);
        isDashing = false;


    }
}

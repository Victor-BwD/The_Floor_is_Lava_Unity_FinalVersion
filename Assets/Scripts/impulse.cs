using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impulse : MonoBehaviour
{
    private Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            rb.AddForce(transform.up * 500);
            rb.useGravity = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    public Transform target;

    // Start is called before the first frame update
    private void Update()
    {
        transform.LookAt(target);
    }

}

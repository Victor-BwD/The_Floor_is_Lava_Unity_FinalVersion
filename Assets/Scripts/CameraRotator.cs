using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{

    public GameObject player;

    private float speedH = 2.0f;
    private float speedV = 2.0f;

    private float rotVertical = 0.0f;
    private float rotHorizontal = 0.0f;

    // Start is called before the first frame update

    private void Update()
    {
        rotHorizontal += speedH * Input.GetAxis("Mouse X");
        rotVertical -= speedV * Input.GetAxis("Mouse Y");

        rotHorizontal = Mathf.Clamp(rotHorizontal, -179f, 179f);//the rotation range
        rotVertical = Mathf.Clamp(rotVertical, 0f, 89f);//the rotation range

        transform.eulerAngles = new Vector3(0f, rotHorizontal, rotVertical);

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position;
    }

}

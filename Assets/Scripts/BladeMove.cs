using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeMove : MonoBehaviour
{

    private bool down = true;
    private bool up = false;
    public float seconds, drop, speed;
    public Vector3 startPosition;
    public Vector3 updatedPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {

      updatedPosition = transform.position;

      if(down==true){
        if(updatedPosition.y > startPosition.y-drop){
          transform.Translate(Vector3.up * Time.deltaTime*-speed);
        }else if(down==true){
          StartCoroutine(bladeMovementUp());
        }
      }

      if(up==true){
        if(updatedPosition.y < startPosition.y){
          transform.Translate(Vector3.up * Time.deltaTime*speed);
        }else if (up==true){
          StartCoroutine(bladeMovementDown());
        }
      }
      
        
    }

     IEnumerator bladeMovementDown(){
       
      yield return new WaitForSeconds(seconds);
      
      up=false;
      down=true;
    }

    IEnumerator bladeMovementUp(){

      yield return new WaitForSeconds(seconds);

        down=false;
        up=true;
    }
}

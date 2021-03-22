using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    //Variables
     public float speed = 20.0F; 
     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     void Update() {
         Vector3 pos = transform.position;
 
         if (Input.GetKey ("a")) {
             pos.z += speed * Time.deltaTime;
         }
         if (Input.GetKey ("d")) {
             pos.z -= speed * Time.deltaTime;
         }
         if (Input.GetKey ("w")) {
             pos.x += speed * Time.deltaTime;
         }
         if (Input.GetKey ("s")) {
             pos.x -= speed * Time.deltaTime;
         }
             
 
         transform.position = pos;
     }
}

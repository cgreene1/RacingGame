using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using Photon.Realtime;

[RequireComponent(typeof(CharacterController))]

public class Control : MonoBehaviourPun
{
    private Boolean hasSetUp = false;
    private CharacterController controller = null;

    // ** don't need line below, bc it's a MonoBehaviourPun *** 
    //  private PhotonView photonGuy = null;

    [SerializeField] private float speed = 20.0F;
    [SerializeField] private Material carMat = null;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        SetUpBothPlayers();
    }

    // Update is called once per frame
    void Update() {
        // only move your player
        if (photonView.IsMine)
        {
            TakeInput();
        }

        // **** below is initial code that wasn't photon-friendly ****

         //Vector3 pos = transform.position;
 
         //if (Input.GetKey ("a")) {
         //    pos.z += speed * Time.deltaTime;
         //}
         //if (Input.GetKey ("d")) {
         //    pos.z -= speed * Time.deltaTime;
         //}
         //if (Input.GetKey ("w")) {
         //    pos.x += speed * Time.deltaTime;
         //}
         //if (Input.GetKey ("s")) {
         //    pos.x -= speed * Time.deltaTime;
         //}
             
 
         //transform.position = pos;
     }

    private void SetUpBothPlayers()
    {
        //PhotonNetwork.AutomaticallySyncScene = true;
        GameObject[] cars = GameObject.FindGameObjectsWithTag("Car");
        GameObject car1 = cars[1];
        GameObject car2 = cars[0];
        if (PhotonNetwork.IsMasterClient) {
            car1 = cars[0];
            car2 = cars[1];
        }
            car1.GetComponent<MeshRenderer>().material = carMat;
            car1.transform.parent.transform.position = new Vector3 (-80,0,6);
            car1.transform.parent.GetComponent<CharacterController>().enabled = true;
            car2.transform.parent.transform.position = new Vector3 (-80,0,-6);
            car2.transform.parent.GetComponent<CharacterController>().enabled = true;
        /*foreach (var player in PhotonNetwork.PlayerList)
        {
            if (i == 0)
            {
                // set material red
                // make position on the left
                Debug.Log($"Setting material/position for user: {i}");
            }
            else
            {
                // don't change material
                // don't change position
                Debug.Log($"Not changing material/position for user: {i}");
            }

            i++;
        }*/
    }

    private void TakeInput()
    {
        Vector3 movement = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = 0f,
            z = Input.GetAxisRaw("Vertical")
        }.normalized;

        controller.SimpleMove(movement * speed);
    }
}

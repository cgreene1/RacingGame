using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using Photon.Realtime;

[RequireComponent(typeof(CharacterController))]

public class Control : MonoBehaviourPun
{
    //private Boolean hasSetUp = false;
    private CharacterController controller = null;
    public string playername;

    // ** don't need line below, bc it's a MonoBehaviourPun *** 
    //  private PhotonView photonGuy = null;

    [SerializeField] private float speed = 20.0F;
    [SerializeField] private Material carMat = null;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        SetUpBothPlayers();

        if (photonView.IsMine)
        {
            playername = PlayerPrefs.GetString("PlayerName");
        }

    }

    // Update is called once per frame
    void Update() {
        // only move your player
        if (photonView.IsMine)
        {
            TakeInput();
        }
     }

    private void SetUpBothPlayers()
    {
        //PhotonNetwork.AutomaticallySyncScene = true;
        GameObject[] cars = GameObject.FindGameObjectsWithTag("Car");
        if (cars.Length == 2)
        {
            GameObject car1 = cars[1];
            GameObject car2 = cars[0];
            if (PhotonNetwork.IsMasterClient)
            {
                car1 = cars[0];
                car2 = cars[1];
            }
            car1.GetComponent<MeshRenderer>().material = carMat;
            car1.transform.parent.transform.position = new Vector3(-80, 0, 6);
            car1.transform.parent.GetComponent<CharacterController>().enabled = true;
            car2.transform.parent.transform.position = new Vector3(-80, 0, -6);
            car2.transform.parent.GetComponent<CharacterController>().enabled = true;
        }

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

    //public void IWon()
    //{
    //    photonView.RPC("GameOver", PhotonTargets.All, (string)name);
    //}

    //[PunRPC]
    //public void GameOver(string name)
    //{
    //    // put stuff "player {name} won"
    //    Debug.Log($"Player {name} won");

    //    photonView.RPC("GameOver", RpcTarget.Others, (string)name);
    //}
}

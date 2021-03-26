using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FinishLine : MonoBehaviour
{
    private bool hasWon = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col) {
        //if (PhotonNetwork.IsMasterClient) {
        if(col.gameObject.tag == "Car")
        {
            hasWon = true;
            Debug.Log("Yay");
        }

    }

}

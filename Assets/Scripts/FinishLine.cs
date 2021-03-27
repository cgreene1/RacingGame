using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FinishLine : MonoBehaviour
{
    //private bool hasWon = false;

    private void OnTriggerEnter(Collider col) {
        //if (PhotonNetwork.IsMasterClient) {
        //if (!photonView.isMine)
        //{
        //    return;
        //}

        if(col.gameObject.tag == "Car")
        {
            //hasWon = true;
            //Debug.Log("Yay");

            Control player = col.gameObject.transform.parent.GetComponent<Control>();

            GameMan.instance.GameOver(player.playername);
        }

    }

}

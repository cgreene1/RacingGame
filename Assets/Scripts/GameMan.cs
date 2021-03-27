using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;


public class GameMan : MonoBehaviourPun
{
    public static GameMan instance = null;
    private bool gotGameOverMessage = false;
    [SerializeField] private GameObject gameOverPanel = null;
    [SerializeField] private TextMeshProUGUI winnerText = null;

    // int localScore = 0;
    // int visitorScore = 0;

    private void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
            Debug.Log("Instance is null, create instance");
        }

        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
            Debug.Log("Already have instance, destroying this one");
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        gameOverPanel.SetActive(false);
    }

    [PunRPC]
    public void GameOver(string name)
    {
        if (!gotGameOverMessage)
        {
            // put stuff "player {name} won"
            Debug.Log($"Player {name} won");

            gameOverPanel.SetActive(true);
            winnerText.text = name + " is winner";

            photonView.RPC("GameOver", RpcTarget.Others, (string)name); //new object[] { name });
            gotGameOverMessage = true;
        }
    }

    public void BacktoMenu()
    {
        //PhotonNetwork.Disconnect();
        PhotonNetwork.LoadLevel("Menu");
        
    }
}

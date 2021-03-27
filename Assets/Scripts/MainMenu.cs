using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject nameInputPanel = null;
    [SerializeField] private GameObject findOpponentPanel = null;
    [SerializeField] private GameObject waitingStatusPanel = null;
    [SerializeField] private TextMeshProUGUI waitingStatusText = null;

    public static MainMenu instance;

    private bool isConnecting = false;

    private int stage = 0;

    // checked for Photon, because of diff game versions & stuff,
    // lets people play others w/ same version
    private const string GameVersion = "0.1";
    private const int MaxPlayersPerRoom = 2;

    private void Awake()
    {
        // makes all players in lobby go to same scene
        PhotonNetwork.AutomaticallySyncScene = true;
        findOpponentPanel.SetActive(false);
        waitingStatusPanel.SetActive(false);
    }

    private void Start()
    {
        findOpponentPanel.SetActive(false);
        waitingStatusPanel.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (stage == 0)
        {
            findOpponentPanel.SetActive(false);
            waitingStatusPanel.SetActive(false);
        }
    }

    //public override void OnEnable()
    //{
    //    base.OnEnable();
    //    findOpponentPanel.SetActive(false);
    //    waitingStatusPanel.SetActive(false);
    //}

    public void ContinueBtn()
    {
        nameInputPanel.SetActive(false);
        findOpponentPanel.SetActive(true);
        stage = 1;
    }

    public void FindOpponent()
    {
        isConnecting = true;

        findOpponentPanel.SetActive(false);
        waitingStatusPanel.SetActive(true);

        waitingStatusText.text = "Searching...";

        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.GameVersion = GameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");

        if (isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        waitingStatusPanel.SetActive(false);
        findOpponentPanel.SetActive(true);

        Debug.Log($"Disconnected due to: {cause}");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No clients are waiting for an opponent, creating a new room");

        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = MaxPlayersPerRoom });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Client successfully joined a room");

        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;

        if(playerCount!= MaxPlayersPerRoom)
        {
            waitingStatusText.text = "Waiting for Opponent";
            Debug.Log("Client is waiting for an opponent");
        }
        else
        {
            waitingStatusText.text = "Opponent Found";
            Debug.Log("Match is ready to begin");
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == MaxPlayersPerRoom)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;

            waitingStatusText.text = "Opponent Found";
            Debug.Log("Match is ready to begin");

            PhotonNetwork.LoadLevel("GameScene");
            stage = 0;
        }
    }
}

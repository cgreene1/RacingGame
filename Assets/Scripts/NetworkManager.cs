using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    //// create instance/singleton of netMan so we can access from anywhere
    //public static NetworkManager instance;

    //void Awake()
    //{
    //    if (instance != null && instance != this)
    //        gameObject.SetActive(false);
    //    else
    //    {
    //        // set the instance
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //}

    //void Start()
    //{
    //    // connect to server
    //    PhotonNetwork.ConnectUsingSettings();
    //}

    //public override void OnConnectedToMaster()
    //{
    //    Debug.Log("Connected to master server");
    //    CreateRoom("testroom");
    //}

    //public void CreateRoom(string roomName)
    //{
    //    PhotonNetwork.CreateRoom(roomName);
    //}

    //public override void OnCreatedRoom()
    //{
    //    Debug.Log("Created room: " + PhotonNetwork.CurrentRoom.Name);
    //}

    //public void JoinRoom(string roomName)
    //{
    //    PhotonNetwork.JoinRoom(roomName);
    //}

    //public override void OnJoinedRoom()
    //{
    //    Debug.Log("Joined room: " + PhotonNetwork.CurrentRoom.Name);
    //}

    //public void ChangeScene(string sceneName)
    //{
    //    PhotonNetwork.LoadLevel(sceneName);
    //}

    //public void ButtonCreateRoom()
    //{
    //    string roomName = GetRoomName();
    //    CreateRoom(roomName);
    //}

    //public void ButtonJoinRoom()
    //{
    //    string roomName = GetRoomName();
    //    Debug.Log(roomName);
    //    JoinRoom(roomName);
    //}

    //public string GetRoomName()
    //{

    //    return GameObject.Find("RoomText").GetComponent<Text>().text;
    //}
}

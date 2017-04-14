using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour {
    private const string VERSION = "000";
    public string room = "TEST";
    public GameObject spawnPoint;

    // Use this for initialization
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(VERSION);
    }

    void OnJoinedLobby()
    {
        RoomOptions roomoptions = new RoomOptions() { IsVisible = false, MaxPlayers = 4};
        PhotonNetwork.JoinOrCreateRoom(room, roomoptions, TypedLobby.Default);
    }

    void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("Player", spawnPoint.transform.position, spawnPoint.transform.rotation, 0);
    }

}

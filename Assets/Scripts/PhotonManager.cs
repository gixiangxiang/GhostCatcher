using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class PhotonManager : MonoBehaviourPunCallbacks
{
  public static PhotonManager photonMg;
  public string playerName;
  // public string roomName;
  void Awake()
  {
    photonMg = this;
    DontDestroyOnLoad(this);
  }

  //連接伺服器
  public void Connect()
  {
    PhotonNetwork.ConnectUsingSettings();
  }

  public override void OnConnectedToMaster()
  {
    PhotonNetwork.NickName = playerName;
    LoadScene(1);
  }
  //創建房間
  public void ButtonCreateRoom(string roomName)
  {
    PhotonNetwork.CreateRoom(roomName);
  }
  public override void OnJoinedRoom()
  {
    PhotonNetwork.AutomaticallySyncScene = true;
    LoadScene(2);
  }

  public void LoadScene(int index)
  {
    SceneManager.LoadScene(index);

  }


}

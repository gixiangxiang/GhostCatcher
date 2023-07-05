using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class PhotonManager : MonoBehaviourPunCallbacks
{
  public static PhotonManager photonMg;
  public string playerName;
  void Awake()
  {
    photonMg = this;
    DontDestroyOnLoad(photonMg);
  }

  public override void OnConnectedToMaster()
  {
    PhotonNetwork.NickName = playerName;
    PhotonNetwork.JoinLobby();
  }

  public override void OnJoinedLobby()
  {
    SceneManager.LoadScene(1);
  }
  public void Connect()
  {
    PhotonNetwork.ConnectUsingSettings();
  }

}

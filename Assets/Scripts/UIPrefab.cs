using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class UIPrefab : MonoBehaviourPunCallbacks
{
  public Text uiName;

  public void JoinTheRoom()
  {
    PhotonNetwork.JoinRoom(uiName.text);
  }
  
}

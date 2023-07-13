using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
  [SerializeField] InputField roomNameIpf;
  [SerializeField] Button createRoomBtn;
  [SerializeField] Transform roomBtnParent;
  [SerializeField] UIPrefab roomBtn;
  void Start()
  {
    PhotonNetwork.JoinLobby();
  }

  public void CreateRoom()
  {
    roomNameIpf.text.Trim();
    if (roomNameIpf.text.Length > 0)
    {
      PhotonManager.photonMg.ButtonCreateRoom(roomNameIpf.text);
    }
    else
    {
      Debug.Log("請輸入房間名");
    }
  }


  public override void OnRoomListUpdate(List<RoomInfo> roomList)
  {
    float childs = roomBtnParent.childCount;
    for (int i = 0; i < childs; i++)
    {
      Transform child = roomBtnParent.GetChild(i);
      Destroy(child.gameObject);
    }


    foreach (RoomInfo room in roomList)
    {
      if (room.PlayerCount > 0)
      {
        roomBtn.uiName.text = room.Name;
        Instantiate(roomBtn, roomBtnParent);
      }
    }
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
  [SerializeField] UIPrefab prefab;
  [SerializeField] Transform prefabParent;

  void Start()
  {
    RefreshPlayerList();
  }
  public override void OnPlayerEnteredRoom(Player newPlayer)
  {
    RefreshPlayerList();
  }
  public override void OnPlayerLeftRoom(Player otherPlayer)
  {
    RefreshPlayerList();
  }

  public void RefreshPlayerList()
  {
    //刪除原有名單
    float childs = prefabParent.childCount;
    for (int i = 0; i < childs; i++)
    {
      Transform child = prefabParent.GetChild(i);
      Destroy(child.gameObject);
    }
    //生成新的名單
    foreach (var player in PhotonNetwork.PlayerList)
    {
      prefab.uiName.text = player.NickName;
      Instantiate(prefab, prefabParent);
    }
  }

  public void StartGame()
  {
    PhotonManager.photonMg.LoadScene(3);
  }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CatchDetect : MonoBehaviourPunCallbacks
{
  PhotonView pv;

  void Start()
  {
    pv = GetComponent<PhotonView>();

  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "Player")
    {
      pv.RPC("RPCCatch",RpcTarget.All);
    }
  }

  [PunRPC]
  public void RPCCatch()
  {
    GameSceneManager.gM.isCatch = true;
  }
}

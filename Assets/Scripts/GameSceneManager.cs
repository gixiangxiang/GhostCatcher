using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameSceneManager : MonoBehaviourPunCallbacks
{
  public static GameSceneManager gM;
  [SerializeField] Transform playerPoint;
  [SerializeField] Transform ghostPoint;
  public bool isCatch;
  void Awake()
  {
    gM = this;
  }
  void Start()
  {
    if (PhotonNetwork.IsMasterClient)
    {
      PhotonNetwork.Instantiate("Ghost", ghostPoint.position, Quaternion.identity);
    }
    else
    {
      PhotonNetwork.Instantiate("Player", playerPoint.position, Quaternion.identity);
    }
  }
  void Update()
  {
    if (isCatch)
    {
      Debug.Log("End");
    }
  }
}

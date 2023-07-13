using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameSceneManager : MonoBehaviourPunCallbacks
{
  public static GameSceneManager gM;
  [SerializeField] Transform playerPoint;
  [SerializeField] Transform ghostPoint;
  public bool canMove;
  bool gameStart;
  public bool isCatch;
  [SerializeField] Text gameTimeTxt;
  [SerializeField] int gameTime;
  int leftTime;

  void Awake()
  {
    gM = this;
  }
  void Start()
  {
    leftTime = gameTime;
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

    if (!canMove && !isCatch && !gameStart)
    {
      Debug.Log("倒數");
    }
    else if (canMove && !isCatch && !gameStart)
    {
      StartCoroutine(CountDownTime(leftTime));
    }

    if (isCatch)
    {
      Debug.Log("Ghost Win");
    }
    else if (!canMove && !isCatch && gameStart)
    {
      Debug.Log("Player Win");
    }
  }

  IEnumerator CountDownTime(int leftTime)
  {
    gameStart = true;
    while (leftTime > 0)
    {
      gameTimeTxt.text = leftTime.ToString();
      leftTime--;
      yield return new WaitForSeconds(1f);
    }
    canMove = false;
  }
}

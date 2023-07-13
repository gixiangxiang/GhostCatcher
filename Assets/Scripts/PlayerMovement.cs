using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPunCallbacks
{
  PhotonView pv;
  public float speed;
  Rigidbody2D rb;
  public bool isRun;
  void Start()
  {
    pv = GetComponent<PhotonView>();
    rb = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    if (rb.velocity != Vector2.zero)
    {
      isRun = true;
    }
    else
    {
      isRun = false;
    }
  }
  void FixedUpdate()
  {
    if (pv.IsMine && GameSceneManager.gM.canMove)
    {

      Movement();
    }
  }

  void Movement()
  {
    float hDir = Input.GetAxisRaw("Horizontal");
    float vDir = Input.GetAxisRaw("Vertical");
    rb.velocity = new Vector2(hDir * speed * Time.fixedDeltaTime, vDir * speed * Time.fixedDeltaTime);
    if (hDir != 0)
    {
      transform.localScale = new Vector3(-hDir, 1, 1);
    }
    rb.velocity.Normalize();
  }
}

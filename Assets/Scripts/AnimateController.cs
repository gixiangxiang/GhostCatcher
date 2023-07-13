using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateController : MonoBehaviour
{
  public Animator anim;
  PlayerMovement movement;
  void Start()
  {
    movement = GetComponent<PlayerMovement>();
  }

  void Update()
  {
    anim.SetBool("IsRun", movement.isRun);
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float speed;
  Rigidbody2D rb;
  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {

  }
  void FixedUpdate()
  {
    Movement();
  }

  void Movement()
  {
    float hDir = Input.GetAxisRaw("Horizontal");
    float vDir = Input.GetAxisRaw("Vertical");
    rb.velocity = new Vector2(hDir * speed * Time.fixedDeltaTime, vDir * speed * Time.fixedDeltaTime);
    rb.velocity.Normalize();
  }
}

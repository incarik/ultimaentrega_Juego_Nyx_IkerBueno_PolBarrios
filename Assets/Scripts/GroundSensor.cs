using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour


{
 public bool isGrounded;
 public Animator anim;
 PlayerMove playerScript;

 void Awake()
 {
   anim = GetComponentInParent<Animator>();
   playerScript = GetComponentInParent<PlayerMove>();
 }
 void OnTriggerEnter2D(Collider2D collider)
 {
    isGrounded = true;
    anim.SetBool("IsJumping", false);
 }

 void OnTriggerExit2D(Collider2D collider)
 {
    isGrounded = false;
 }

 void OnTriggerStay2D(Collider2D collider)
 {
   isGrounded = true;
 }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour
{
   private Rigidbody rb;
   public float torque;
   public float speed;
   public float checkDist;
   public float checkDistLeft;
   public float checkDistRight;

   private void Start()
   {
      rb = GetComponentInParent<Rigidbody>();
      
   }

   void Update()
   {
      rb.AddForce(transform.forward * speed, ForceMode.Acceleration);
      

      Ray rayForward = new Ray(this.transform.position, this.transform.forward);
      //Ray rayLeft = new Ray(this.transform.position, -transform.right);
      //Ray rayRight = new Ray(this.transform.position, transform.forward);
      RaycastHit hit;
      if (Physics.Raycast(rayForward, out hit,checkDist))
      {
         rb.AddRelativeTorque(Vector3.up * torque);
      }
      //if (Physics.Raycast(rayRight, out hit,checkDistRight))
      //{
      //   rb.AddRelativeTorque(Vector3.up * torque);
      //}
      //if (Physics.Raycast(rayLeft, out hit,checkDistLeft))
      //{
      //   rb.AddRelativeTorque(Vector3.up * torque);
      //}
   }

   private void OnDrawGizmos()
   {
      Debug.DrawRay(transform.position, transform.forward * checkDist, Color.black);
      //Debug.DrawRay(transform.position, (transform.right) * checkDistRight, Color.red);
      //Debug.DrawRay(transform.position, -transform.right  * checkDistLeft, Color.red);
   }
}

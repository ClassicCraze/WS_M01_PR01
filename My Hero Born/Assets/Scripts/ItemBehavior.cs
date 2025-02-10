using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour 
 {
     public GameBehavior gameManager;
     public float BoostMulitplier = 2.0f;
     public float BoostSeconds = 5.0f;
 
     void Start()
     {                
           gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
     }
 
     private void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.name == "Player")
         {
             Destroy(this.transform.parent.gameObject);
             Debug.Log("SPEED boost");

             PlayerBehavior Player = collision.gameObject.GetComponent<PlayerBehavior>();
             Player.BoostSpeed(BoostMulitplier, BoostSeconds);

 
             gameManager.Items += 1;
         }
     }
 } 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] GameOver gameOver;
    //[SerializeField] CheckpointController controller;

    private void Awake()
    {
        if (gameOver == null)
        {
            gameOver = GameObject.FindGameObjectWithTag("Smoke").GetComponent<GameOver>(); 
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("collided");
            //gameOver.respawnPosition = collision.transform.position;
        }
    }
}

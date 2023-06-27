using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlatform : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            anim.SetBool("hasCollided", true);

            Destroy(this.gameObject, 2f);


        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public bool isPicked = false;

    public AudioSource Source;

    [SerializeField]
    Items item;
    //[SerializeField]
    //PlayerController player; //keep this to refer to player stats for buffs and debuffs

    private void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isPicked)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            spriteRenderer.enabled = false;

            Destroy(this.gameObject, 2.5f);
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            Source.Play();

            if (isPicked == false)
            {
                StartCoroutine(BuffEffect());

                item.TriggerEffect();

                isPicked = true;
            }

        }

    }


    //Check this coroutine and items script: fix coroutine, not restoring speed of the camera (probably because the script is destroyed before the coroutine finishes)

    IEnumerator BuffEffect()
    {
        CameraMove cameraMove = FindObjectOfType<CameraMove>();

        //Add other buffs/debuff types here with temp values holders

        float tempSpeedHolder = cameraMove.moveSpeed;

        cameraMove.moveSpeed *= item.boostMultiplier; //speed of the camera is halved.

        Debug.Log("cameraspeed buff applied: " + cameraMove.moveSpeed);


        yield return new WaitForSeconds(item.buffDuration);

        cameraMove.moveSpeed = tempSpeedHolder;

        //restore original values here

        Debug.Log("cameraspeed buff ended: " + cameraMove.moveSpeed);
    }


    //buff ideas: boost on jump power
    //defbuffs: 
}
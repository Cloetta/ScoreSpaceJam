using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public bool isPicked = false;

    [SerializeField]
    Items item;

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

        float tempSpeedHolder = cameraMove.moveSpeed;

        cameraMove.moveSpeed *= item.boostMultiplier; //speed of the camera is halved.

        Debug.Log("cameraspeed buff applied: " + cameraMove.moveSpeed);

        //Buff for 3 seconds
        yield return new WaitForSeconds(item.buffDuration);

        cameraMove.moveSpeed = tempSpeedHolder;

        Debug.Log("cameraspeed buff ended: " + cameraMove.moveSpeed);
    }

}

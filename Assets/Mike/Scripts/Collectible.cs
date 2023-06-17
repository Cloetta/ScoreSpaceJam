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
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPicked = true;

            StartCoroutine(BuffEffect());

            item.TriggerEffect();
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
        yield return new WaitForSeconds(1.0f);

        cameraMove.moveSpeed = tempSpeedHolder;

        Debug.Log("cameraspeed buff ended: " + cameraMove.moveSpeed);
    }

}

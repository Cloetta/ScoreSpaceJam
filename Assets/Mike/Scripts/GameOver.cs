using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    Camera cam;

    [SerializeField]
    Collider2D objCollider;

    [SerializeField]
    GameObject gameOverPanel;

    Plane[] planes;

    void Update()
    {
        isGameOver();

        if (isGameOver())
        {
            //Freeze time
            Time.timeScale = 0;

            //Activate pop-up window with score and playagain button
            gameOverPanel.SetActive(true);

        }
        else
        {
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space) && gameOverPanel.activeSelf)
        {
            PlayAgain();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Enable main menu
        }

    }

    public bool isGameOver()
    {
        //Fetching the main Camera in the scene
        cam = Camera.main;

        //Calculating plane area according to cam field of view
        planes = GeometryUtility.CalculateFrustumPlanes(cam);

        //reference 
        objCollider = player.GetComponent<CapsuleCollider2D>();


        if (GeometryUtility.TestPlanesAABB(planes, objCollider.bounds))
        {
            //Nothing happens, still in game, within the range of the camera!

            return false;
        }
        else
        {
            if ((player.transform.position.y - cam.transform.position.y) <= -11.5f)
            {
                //GameOver
                //Debug.Log("Player out of field! Game over!");
                return true;
            }
            else if ((player.transform.position.y - cam.transform.position.y) >= 9.5f)
            {
                //comment this

                /*float moveSpeed = 2f;

                Vector3 camPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                Vector3 targetPosition = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);

                // Move the camera upwards based on the moveSpeed and the elapsed time since the last frame
                transform.position = Vector3.MoveTowards(camPosition, targetPosition, Time.deltaTime * moveSpeed);*/
                return false;

            }


            //Nothing happens, still in game, the player is above the camera
            return false;

        }
    }


    public void PlayAgain()
    {
        //Reload scene from the beginning
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void QuitGame()
    {
        //Quit game
        Application.Quit();
    }


    /*if ((player.transform.position.x - cam.transform.position.x) >= 15.5f)
                {
                    float camX = cam.transform.position.x + 5f;
                    Vector3 newCamPosX = new Vector3(camX, cam.transform.position.y, cam.transform.position.z);
                    transform.Translate(newCamPosX * 6.5f * Time.deltaTime);
                    return false;
                }
                else if ((player.transform.position.x - cam.transform.position.x) <= -15.5f)
                {
                    float camX = cam.transform.position.x + 5f;
                    Vector3 newCamPosX = new Vector3(camX, cam.transform.position.y, cam.transform.position.z);
                    transform.Translate(newCamPosX * 6.5f * Time.deltaTime);
                    return false;
                }*/

}

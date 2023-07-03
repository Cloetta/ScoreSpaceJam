using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver2 : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    SmokeMovement smoke;

    private bool isGameOver = false;

    public int lives = 3;

    [SerializeField]
    GameObject gameOverPanel;


    public Vector2 respawnPosition;

    private void Start()
    {
        isGameOver = false;
    }

    void Update()
    {
        //isGameOver();

        if (isGameOver)
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

            lives--;

            smoke.transform.position += new Vector3(0, -5, 0);

            player.transform.position = respawnPosition;

            //player.transform.position = lastCheckpointPosition;

            Debug.Log("-1 life");

            if(lives <= 0)
            {
                isGameOver = true;
            }

            
        }
    }
}

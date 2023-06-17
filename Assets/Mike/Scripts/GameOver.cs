using JetBrains.Annotations;
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

    }

    private bool isGameOver()
    {
        //Fetching the main Camera in the scene
        cam = Camera.main;

        //Calculating plane area according to cam field of view
        planes = GeometryUtility.CalculateFrustumPlanes(cam);

        //reference 
        objCollider = player.GetComponent<CapsuleCollider2D>();


        if (GeometryUtility.TestPlanesAABB(planes, objCollider.bounds))
        {
            //Nothing happens, still in game!           
            return false;
        }
        else
        {
            //GameOver
            Debug.Log("Player out of field! Game over!");
            return true;

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

}

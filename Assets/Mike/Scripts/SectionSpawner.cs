using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionSpawner : MonoBehaviour
{
    [SerializeField] private GameObject [] levelSections;

    [SerializeField] private Transform environmentParent;

    [SerializeField] private Transform player;

    public List<GameObject> spawnedSections = new List<GameObject>();


    private Vector3 currentPosition;
    private Vector3 nextPosition;

    private int sectionCounter;



    private void Awake()
    {
        currentPosition = new Vector3(0, 0, 0);
        nextPosition = new Vector3(0, 10, 0);
        sectionCounter = 0;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //Spawning 5 sections at the beginning of the game        
        for(int i = 0; i < 5; i++)
        {
            SpawnSpringSection(currentPosition);
            currentPosition += nextPosition;
        }
    
    }


    private void Update()
    {

        if(player.position.y >= spawnedSections[spawnedSections.Count - 1].transform.position.y)
        {
            SpawnSpringSection(currentPosition);
            currentPosition += nextPosition;
            SpawnSpringSection(currentPosition);
            currentPosition += nextPosition;

            if (spawnedSections.Count >= 5)
            {
                //Destroying the least 2 recent sections spawned and remove it from list

                for(int i = 0; i < 2; i++)
                {
                    Destroy(spawnedSections[0]);
                    spawnedSections.Remove(spawnedSections[0]);
                }
                
            }
        }        
    }



    //For different biome sections duplicate this function and make another array of objects with sections of those biomes (for future implementations)
    private void SpawnSpringSection(Vector3 spawnPosition)
    {
        int randomSection = Random.Range(0, levelSections.Length);

        GameObject newSection = (GameObject)Instantiate(levelSections[randomSection], spawnPosition, Quaternion.identity);
        spawnedSections.Add(newSection);

        newSection.transform.parent = environmentParent;

        sectionCounter++;
        
    }


}

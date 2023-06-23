using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public List<Checkpoint> levelCheckpoints = new List<Checkpoint>();

    // Start is called before the first frame update
    void Start()
    {

        foreach (GameObject levelCheckpoint in GameObject.FindGameObjectsWithTag("Checkpoint")) 
        {
            levelCheckpoints.Add(levelCheckpoint.GetComponent<Checkpoint>());
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

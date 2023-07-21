using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] availablePickUps;

    [SerializeField] private Transform parent;

    void Start()
    {
        SpawnPickup(transform.position);
    }

    private void SpawnPickup(Vector3 spawnPosition)
    {
        int randomPickup = Random.Range(0, availablePickUps.Length);

        GameObject newPickup = (GameObject)Instantiate(availablePickUps[randomPickup], spawnPosition, Quaternion.identity);

        newPickup.transform.parent = parent;

    }
}

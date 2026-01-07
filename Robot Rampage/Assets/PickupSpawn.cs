using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pickups;

    void SpawnPickup()
    {
        GameObject pickup = Instantiate(pickups[Random.Range(0, pickups.Length)]);
        pickup.transform.position = transform.position;
        pickup.transform.parent = transform;
        Debug.Log("Spawned");
    }

    IEnumerator RespawnPickup()
    {
        yield return new WaitForSeconds(10);
        Debug.Log("Spawned");
        SpawnPickup();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Spawned");
        SpawnPickup();
    }

    public void PickupWasCollected()
    {
        StartCoroutine("RespawnPickup");
    }

    
}

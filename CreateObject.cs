using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject prefab;
    void OnTriggerEnter()
    {
        Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
    }
}

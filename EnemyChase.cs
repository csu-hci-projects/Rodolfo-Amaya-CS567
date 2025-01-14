﻿using UnityEngine;
using System.Collections;

public class EnemyChase : MonoBehaviour
{
    public Transform Player;
    public Transform Enemy;
    public int MoveSpeed = 4;
    public int MaxDist = 10;
    public int MinDist = 5;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;



            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
            }

        }
    }
}

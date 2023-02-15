using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    int amount = 10;

    [SerializeField]
    bool alwaysTrack = false;

    //property new gives read access to the private variable amount
    public int Amount
    {
        get { return amount; }                     
    }

    Transform playerTransform;
    Vector3 direction;
    Rigidbody2D body;

    [SerializeField]
    float movespeed = 2;

    void Start()
    {
        if (alwaysTrack)
        {
            //find the player in the scene
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            //save a referernce to the player transform
            playerTransform = player.transform;

            body = GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        if (alwaysTrack)
        {
            direction = playerTransform.position - transform.position;
            direction.Normalize();
            body.velocity = direction * movespeed;
        }
    }
}

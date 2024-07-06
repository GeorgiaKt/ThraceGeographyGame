using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; //reference to the player' position (through Tranform)
    public Vector3 offset; //vector3 - stores 3 floats, offset used to set camera a little bit further from the player 

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset; //changes camera's position , 'transform is this script's object (camera)'
        
    }
}

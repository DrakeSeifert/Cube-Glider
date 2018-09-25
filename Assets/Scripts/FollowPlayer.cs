//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    public Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset.x = 0.0f;
        offset.y = 2f;
        offset.z = -6.0f;
    }

    // Update is called once per frame
    void Update () {
        transform.position = player.position + offset;
	}
}

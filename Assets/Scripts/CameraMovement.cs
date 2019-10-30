﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;

    public void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - 7);
    }
}

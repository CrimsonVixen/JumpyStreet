using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneMovement : MonoBehaviour
{
    public GameObject player;

    public void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
    }
}

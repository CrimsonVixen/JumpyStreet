using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed;

    public void Update()
    {
        transform.Translate(Vector3.down / speed); //Higher speed value = slower movement

        //Destroys left spawning cars
        if(transform.tag == "Left" && transform.position.x > 19)
            Destroy(gameObject);

        //Destroys right spawning cars
        else if(transform.tag == "Right" && transform.position.x < -19)
            Destroy(gameObject);
    }
}

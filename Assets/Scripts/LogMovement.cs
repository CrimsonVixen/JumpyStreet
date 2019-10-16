using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMovement : MonoBehaviour
{
    public float speed;

    public void Update()
    {
        if(transform.tag == "LogLeft")
        {
            transform.Translate(Vector3.right / speed); //Higher speed value = slower movement

            if(transform.position.x > 19)
            {
                Destroy(gameObject);
            }
        }

        else if(transform.tag == "LogRight")
        {
            transform.Translate(Vector3.left / speed); //Higher speed value = slower movement

            if(transform.position.x < -19)
            {
                Destroy(gameObject);
            }
        }
    }
}

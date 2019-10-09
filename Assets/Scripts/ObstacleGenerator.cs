using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] obstacles;

    public void Start()
    {
        for(float i = -19.5F; i < 21; i += 1.5F)
        {
            //Generate obstacles in every space behind the player
            //so player can not leave the platform from going backwards
            if(transform.position.z < 0)
            {
                float randomObstacle = Random.value;
                GameObject tempGO = randomObstacle < 0.1F ? obstacles[Random.Range(1, obstacles.Length)] : obstacles[0];
                tempGO.transform.position = new Vector3(i, tempGO.transform.position.y, transform.parent.position.z);
                Instantiate(tempGO, transform.parent, true);
            }

            else
            {
                float random = Random.value;
                float randomObstacle = Random.value;

                //Generate obstacles for left and right side of ground
                if(i < -6 || i > 6 && random < 0.75F)
                {
                    GameObject tempGO = randomObstacle < 0.1F ? obstacles[Random.Range(1, obstacles.Length)] : obstacles[0];
                    tempGO.transform.position = new Vector3(i, tempGO.transform.position.y, transform.parent.position.z);
                    Instantiate(tempGO, transform.parent, true);
                }

                //Generate obstacles for middle part of ground (playable area)
                else if(i < 7.5F && i > -7.5F && random < 0.1F)
                {
                    //Do not spawn obstacle at player starting positiion
                    if(i == 0 && transform.position.z == 3)
                    {
                        return;
                    }

                    GameObject tempGO = randomObstacle < 0.1F ? obstacles[Random.Range(1, obstacles.Length)] : obstacles[0];
                    tempGO.transform.position = new Vector3(i, tempGO.transform.position.y, transform.parent.position.z);
                    Instantiate(tempGO, transform.parent, true);
                }
            }
        }
    }
}

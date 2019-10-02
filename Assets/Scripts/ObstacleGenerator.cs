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
            if(transform.position.z < 0)
            {
                GameObject tempGO = obstacles[0];
                Instantiate(tempGO, transform.parent, true);
                tempGO.transform.position = new Vector3(i, tempGO.transform.position.y, transform.parent.transform.position.z);
            }

            else
            {
                float random = Random.value;

                if (i < -6)
                {
                    if (random < 0.75F)
                    {
                        GameObject tempGO = obstacles[0];
                        Instantiate(tempGO, transform.parent, true);
                        tempGO.transform.position = new Vector3(i, tempGO.transform.position.y, transform.parent.transform.position.z);
                    }
                }

                else if (i < 7.5F && i > -7.5F)
                {
                    if (transform.position.z == 3 && i == 0)
                    {
                        return;
                    }

                    if (random < 0.1F)
                    {
                        GameObject tempGO = obstacles[0];
                        Instantiate(tempGO, transform.parent, true);
                        tempGO.transform.position = new Vector3(i, tempGO.transform.position.y, transform.parent.transform.position.z);
                    }
                }

                else if (i > 6)
                {
                    if (random < 0.75F)
                    {
                        GameObject tempGO = obstacles[0];
                        Instantiate(tempGO, transform.parent, true);
                        tempGO.transform.position = new Vector3(i, tempGO.transform.position.y, transform.parent.transform.position.z);
                    }
                }
            }
        }
    }
}

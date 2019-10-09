using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject[] grounds;
    public GameObject[] obstacles;

    public GameObject groundParent;

    private int groundsToGenerate = 20;

    private float groundPosition = 9;

    private bool useLightGrass = true;

    public void Start()
    {
        //Grounds to initailly generate
        for(int i = 0; i < groundsToGenerate; i++)
        {
            GenerateGround();
        }
    }

    public void GenerateGround()
    {
        //Generate random ground
        GameObject tempGO1 = grounds[Random.Range(0, grounds.Length - 2)];
        
        //Switch between light and dark variants for grass
        if(tempGO1 == grounds[0] || tempGO1 == grounds[1])
        {
            if(useLightGrass)
            {
                tempGO1 = grounds[0];
                useLightGrass = false;
            }

            else if(!useLightGrass)
            {
                tempGO1 = grounds[1];
                useLightGrass = true;
            }
        }

        //Spawn ground
        Instantiate(tempGO1, new Vector3(tempGO1.transform.position.x, tempGO1.transform.position.y, groundPosition), tempGO1.transform.rotation, groundParent.transform);
        groundPosition += 1.5F;

        //If ground is a road
        if(tempGO1 == grounds[3])
        {
            //Generate and spawn middle or end road part
            GameObject tempGO2 = grounds[Random.Range(4, 6)];
            Instantiate(tempGO2, new Vector3(tempGO2.transform.position.x, tempGO2.transform.position.y, groundPosition), tempGO2.transform.rotation, groundParent.transform);
            groundPosition += 1.5F;

            //If ground is middle road part
            if(tempGO2 == grounds[4])
            {
                //Generate and spawn end road part
                GameObject tempGO3 = grounds[5];
                Instantiate(tempGO3, new Vector3(tempGO3.transform.position.x, tempGO3.transform.position.y, groundPosition), tempGO3.transform.rotation, groundParent.transform);
                groundPosition += 1.5F;

                //Generate random ground that is not a road
                //So roads can not be directly next to each other
                GameObject tempGO4 = grounds[Random.Range(0, grounds.Length - 3)];

                //Switch between light and dark variants for grass
                if(tempGO4 == grounds[0] || tempGO4 == grounds[1])
                {
                    if(useLightGrass)
                    {
                        tempGO4 = grounds[0];
                        useLightGrass = false;
                    }

                    else if(!useLightGrass)
                    {
                        tempGO4 = grounds[1];
                        useLightGrass = true;
                    }
                }

                //Spawn ground
                Instantiate(tempGO4, new Vector3(tempGO4.transform.position.x, tempGO4.transform.position.y, groundPosition), tempGO4.transform.rotation, groundParent.transform);
                groundPosition += 1.5F;
            }

            //If ground is end road part
            if(tempGO2 == grounds[5])
            {
                //Generate random ground that is not a road
                //So roads can not be directly next to each other
                GameObject tempGO5 = grounds[Random.Range(0, grounds.Length - 3)];

                //Switch between light and dark variants for grass
                if (tempGO5 == grounds[0] || tempGO5 == grounds[1])
                {
                    if(useLightGrass)
                    {
                        tempGO5 = grounds[0];
                        useLightGrass = false;
                    }

                    else if(!useLightGrass)
                    {
                        tempGO5 = grounds[1];
                        useLightGrass = true;
                    }
                }

                //Spawn ground
                Instantiate(tempGO5, new Vector3(tempGO5.transform.position.x, tempGO5.transform.position.y, groundPosition), tempGO5.transform.rotation, groundParent.transform);
                groundPosition += 1.5F;
            }
        }
    }
}

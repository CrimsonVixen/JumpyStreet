using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficGenerator : MonoBehaviour
{
    public GameObject[] cars;

    private GameObject car;

    private bool rightSide;

    public void Start()
    {
        car = cars[Random.Range(0, cars.Length)]; //Pick random car from array of cars
        rightSide = Random.value < 0.5 ? true : false; //Spawn on left or right side of road
        StartCoroutine(GenerateTraffic());
    }

    //Spawns a car every 2-3 seconds
    private IEnumerator GenerateTraffic()
    {
        while(true)
        {
            int xPos;
            GameObject tempGO = Instantiate(car, transform.parent, true);

            //Spawn on right side
            if(rightSide)
            {
                xPos = 19;
                tempGO.transform.localRotation = Quaternion.Euler(-90, -90, -180);
                tempGO.tag = "Right";
            }

            //Spawn on left side
            else
            {
                xPos = -19;
                tempGO.tag = "Left";
            }

            tempGO.transform.position = new Vector3(xPos, tempGO.transform.position.y, transform.parent.position.z);
            yield return new WaitForSeconds(Random.Range(2, 5));
        }
    }
}

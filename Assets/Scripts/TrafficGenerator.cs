using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficGenerator : MonoBehaviour
{
    public GameObject car;

    public void Start()
    {
        //StartCoroutine(GenerateTraffic());
    }

    private IEnumerator GenerateTraffic()
    {
        while(true)
        {
            int xPos;
            float randomValue = Random.value;
            GameObject tempGO = Instantiate(car, transform.parent, true);

            if(randomValue < 0.5)
            {
                xPos = 19;
                tempGO.transform.localRotation = Quaternion.Euler(0, 0, -90);
            }

            else
            {
                xPos = -19;
            }

            tempGO.transform.position = new Vector3(xPos, tempGO.transform.position.y, transform.parent.position.z);
            yield return new WaitForSeconds(3);
        }
    }
}

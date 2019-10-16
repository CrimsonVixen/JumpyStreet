using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogGenerator : MonoBehaviour
{
    public GameObject log;

    private static bool useRightSide = false;
    private bool rightSide;

    public void Start()
    {
        useRightSide = useRightSide == false ? true : false;
        rightSide = useRightSide;
        StartCoroutine(GenerateLogs());
    }

    private IEnumerator GenerateLogs()
    {
        while(true)
        {
            int xPos;
            GameObject tempGO = Instantiate(log, transform.parent, true);

            //Spawn on right side
            if(rightSide)
            {
                xPos = 19;
                tempGO.tag = "LogRight";
            }

            //Spawn on left side
            else
            {
                xPos = -19;
                tempGO.tag = "LogLeft";
            }

            tempGO.transform.position = new Vector3(xPos, tempGO.transform.position.y, transform.parent.position.z);
            yield return new WaitForSeconds(Random.Range(2, 4));
        }
    }
}

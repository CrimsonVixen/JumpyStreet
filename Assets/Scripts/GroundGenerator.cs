using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject[] grounds;
    public GameObject groundParent;

    private int groundsToGenerate = 20;
    private int groundPosition = 6;

    public void Start()
    {
        for(int i = 0; i < groundsToGenerate; i++)
        {
            GenerateGround();
        }
    }

    public void GenerateGround()
    {
        GameObject tempGO = grounds[Random.Range(0, grounds.Length - 1)];
        Instantiate(tempGO, new Vector3(tempGO.transform.position.x, tempGO.transform.position.y, groundPosition), Quaternion.identity, groundParent.transform);
        groundPosition++;
    }
}

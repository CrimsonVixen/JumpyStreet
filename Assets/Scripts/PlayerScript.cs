using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Vector3 tempPlayerPosition;
    protected float worldGridSize;  //world grid, tile size in unity units
    protected float playerMovementSpeed;  //player movement speed in units per second
    private float internalPlayerSpeed;
    
    void Start()
    {
        bool temp1 = SetWorldGridSide(1.0f);
        bool temp2 = SetPlayerMovementSpeed(1.0f);
        tempPlayerPosition = this.gameObject.transform.position;
    }

    void Update()
    {
        tempPlayerPosition = this.gameObject.transform.position;
        if (Input.GetKey("up"))
        {
            tempPlayerPosition.z += 1.0f * Time.deltaTime;
            this.gameObject.transform.position = tempPlayerPosition;
        }
        if (Input.GetKey("down"))
        {
            tempPlayerPosition.z -= 1.0f * Time.deltaTime;
            this.gameObject.transform.position = tempPlayerPosition;
        }
        if (Input.GetKey("left"))
        {
            tempPlayerPosition.x -= 1.0f * Time.deltaTime;
            this.gameObject.transform.position = tempPlayerPosition;
        }
        if (Input.GetKey("right"))
        {
            tempPlayerPosition.x += 1.0f * Time.deltaTime;
            this.gameObject.transform.position = tempPlayerPosition;
        }
    }

    public bool SetWorldGridSide(float gridSize)  //Set the worldgrid dimensions, must be a
    {                                             //positive number, else will default to 1.0f
        if (gridSize > 0.0f)                      //and return false.
        {
            worldGridSize = gridSize;
            return true;
        }
        else
        {
            worldGridSize = 1.0f;
            return false;
        }
    }

    public bool SetPlayerMovementSpeed(float moveSpeed)  //Set the player move speed, must be a
        {                                                //positive number, else will default to 1.0f
            if (moveSpeed > 0.0f)                        //and return false.
            {
                playerMovementSpeed = moveSpeed;
                return true;
            }
            else
            {
                playerMovementSpeed = 1.0f;
                return false;
            }
        }
    }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Vector3 tempPlayerPosition;
    protected float worldGridSize;  //world grid, tile size in unity units
    protected float playerMovementSpeed;  //player movement speed in units per second
    private float internalPlayerSpeed;
    private float internalAxisValueHorizontal;
    private float internalAxisValueVertical;

    void Start()
    {
        bool temp1 = SetWorldGridSide(4.0f);
        bool temp2 = SetPlayerMovementSpeed(1.0f);
        CalculateActualMoveSpeed();
        tempPlayerPosition = this.gameObject.transform.position;
    }

    void Update()
    {
        tempPlayerPosition = this.gameObject.transform.position;
        internalAxisValueHorizontal = Input.GetAxis("Horizontal");
        internalAxisValueVertical = Input.GetAxis("Vertical");

        if (internalAxisValueVertical > 0)
        {
            tempPlayerPosition.z += internalPlayerSpeed * Time.deltaTime;
            this.gameObject.transform.position = tempPlayerPosition;
        }
        if (internalAxisValueVertical < 0)
        {
            tempPlayerPosition.z -= internalPlayerSpeed * Time.deltaTime;
            this.gameObject.transform.position = tempPlayerPosition;
        }
        if (internalAxisValueHorizontal < 0)
        {
            tempPlayerPosition.x -= internalPlayerSpeed * Time.deltaTime;
            this.gameObject.transform.position = tempPlayerPosition;
        }
        if (internalAxisValueHorizontal > 0)
        {
            tempPlayerPosition.x += internalPlayerSpeed * Time.deltaTime;
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
    {                                                    //positive number, else will default to 1.0f
        if (moveSpeed > 0.0f)                            //and return false.
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

    private void CalculateActualMoveSpeed()
    {
        internalPlayerSpeed = playerMovementSpeed * worldGridSize;  //adjusts movement speed based on
    }                                                               //tile size.

    private float GetPlayerActualMoveSpeed()
    {
        return internalPlayerSpeed;
    }
}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Vector3 playerStartPosition;
    private Vector3 cameraStartPosition;
    private Vector3 modelStartPosition = Vector3.zero;

    private Vector3 tempStartMarker;
    private Vector3 tempEndMarker;  //movement stuff
    private float tempStartTime;
    private bool movementLock;
    //private float distCovered;
    //private float fractionOfJourney;

    protected float worldGridSize;  //world grid, tile size in unity units
    protected float playerMovementSpeed;  //player movement speed in world grids per second
    private float internalPlayerSpeed;  //player movement speed in units per seconds
    private int backStepCount;

    //Scoring stuff
    private int score;      
    //Cant Create new HighScoreManager or UIScript objects because they are monobehavior classes
    //HighScoreManager scoreManager = new HighScoreManager();
    //UIScript UIManager = new UIScript();
    
    void Start()
    {
        bool temp1 = SetWorldGridSide(1.5f);
        bool temp2 = SetPlayerMovementSpeed(3.5f);
        CalculateActualMoveSpeed();

        SetStarts();
        
        tempEndMarker = playerStartPosition;
        tempStartMarker = tempEndMarker;
        tempStartTime = Time.time;
        movementLock = false;

        backStepCount = 0;

        score = 0;        
    }

    void Update()
    {
        if (Input.GetKeyDown("up") && !movementLock)
        {
            tempEndMarker.z += worldGridSize;
            tempStartTime = Time.time;
            movementLock = true;
        }
        if (Input.GetKeyDown("down") && !movementLock)
        {
            tempEndMarker.z -= worldGridSize;
            tempStartTime = Time.time;
            movementLock = true;
        }
        if (Input.GetKeyDown("left") && !movementLock)
        {
            tempEndMarker.x -= worldGridSize;
            tempStartTime = Time.time;
            movementLock = true;
        }
        if (Input.GetKeyDown("right") && !movementLock)
        {
            tempEndMarker.x += worldGridSize;
            tempStartTime = Time.time;
            movementLock = true;
        }

        if (movementLock)
        {
            float distCovered = (Time.time - tempStartTime) * internalPlayerSpeed;
            float fractionOfJourney = distCovered / worldGridSize;
            this.gameObject.transform.position = Vector3.Lerp(tempStartMarker, tempEndMarker, fractionOfJourney);
            if (transform.position == tempEndMarker)
            {
                movementLock = !movementLock;
                tempStartMarker = this.gameObject.transform.position;
                tempEndMarker = tempStartMarker;
            }
        }
        PlayerFallingOffTheWorld();
        
    }

    private void SetStarts()
    {
        playerStartPosition = this.gameObject.transform.position;
        cameraStartPosition;
    }

    private void PlayerFallingOffTheWorld()
    {
        GameObject temp = GetComponentInChildren<Rigidbody>().gameObject;
        if (temp.transform.position.y <= -worldGridSize)
        {
            ResetPosition();
        }
    }

    public bool SetWorldGridSide(float gridSize)  //Set the worldgrid dimensions, must be a
    {                                             //positive number, else will default to 1.5f
        if (gridSize > 0.0f)                      //and return false.
        {
            worldGridSize = gridSize;
            return true;
        }
        else
        {
            worldGridSize = 1.5f;
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
        internalPlayerSpeed = worldGridSize * playerMovementSpeed;  //adjusts movement speed based on
    }                                                               //tile size.
    
    private float GetPlayerActualMoveSpeed()
    {
        return internalPlayerSpeed;
    }
    
    public void StepSide(bool clear)
    {
        if (clear)
        {
            //move side
        }
        else
        {
            //game over
            //do score stuff
            //scoreManager.OnGameEnd(score);
        }
    }

    public void StepForward(bool clear)
    {
        if (clear)
        {
            //move forward
            score += 10;
        }
        else
        {
            //game over
            //do score stuff
            //scoreManager.OnGameEnd(score);
        }
    }

    public void StepBack(bool clear)
    {
        if (clear)
        {
            backStepCount++;
            if (backStepCount >= 3)
            {
                //game over
                //do score stuff


                //scoreManager.OnGameEnd(score);
                //UIManager.GameOver(score);
            }
        }
        else
        {

        }
    }

    private void ResetPosition()
    {
        this.gameObject.transform.position = playerStartPosition;
        this.gameObject.GetComponentInChildren<Rigidbody>().gameObject.transform.position = Vector3.zero;
    }

    
}
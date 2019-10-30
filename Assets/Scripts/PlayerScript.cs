using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Vector3 playerStartPosition;

    //movement stuff
    private Vector3 tempStartMarker;
    private Vector3 tempEndMarker;
    private float tempStartTime;
    private bool movementLock;

    protected float worldGridSize;  //world grid, tile size in unity units
    protected float playerMovementSpeed;  //player movement speed in world grids per second
    private float internalPlayerSpeed;  //player movement speed in units per seconds

    //Scoring stuff
    private int score = 0;
    
    public void Start()
    {
        SetWorldGridSide(1.5f);
        SetPlayerMovementSpeed(3.5f);
        CalculateActualMoveSpeed();

        playerStartPosition = transform.position;
        tempEndMarker = playerStartPosition;
        tempStartMarker = tempEndMarker;
        tempStartTime = Time.time;
        movementLock = false;       
    }

    public void Update()
    {
        if(Input.GetKeyDown("up") && !movementLock)
        {
            tempEndMarker.z += worldGridSize;
            tempStartTime = Time.time;
            movementLock = true;
            score += 10;
            UIScript._instance.UpdateScore(score);
            GroundGenerator.instance.GenerateGround();

            if(transform.position.z >= 12)
            {
                Destroy(GroundGenerator.instance.groundParent.transform.GetChild(0).gameObject);
            }
        }

        if(Input.GetKeyDown("down") && !movementLock)
        {
            tempEndMarker.z -= worldGridSize;
            tempStartTime = Time.time;
            movementLock = true;
            score -= 10;
            UIScript._instance.UpdateScore(score);
        }

        if(Input.GetKeyDown("left") && !movementLock)
        {
            tempEndMarker.x -= worldGridSize;
            tempStartTime = Time.time;
            movementLock = true;
        }

        if(Input.GetKeyDown("right") && !movementLock)
        {
            tempEndMarker.x += worldGridSize;
            tempStartTime = Time.time;
            movementLock = true;
        }

        if(movementLock)
        {
            float distCovered = (Time.time - tempStartTime) * internalPlayerSpeed;
            float fractionOfJourney = distCovered / worldGridSize;
            transform.position = Vector3.Lerp(tempStartMarker, tempEndMarker, fractionOfJourney);

            if(transform.position == tempEndMarker)
            {
                movementLock = !movementLock;
                tempStartMarker = transform.position;
                tempEndMarker = tempStartMarker;
            }
        }
    }

    public bool SetWorldGridSide(float gridSize)  //Set the worldgrid dimensions, must be a
    {                                             //positive number, else will default to 1.5f
        if(gridSize > 0.0f)                       //and return false.
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
        if(moveSpeed > 0.0f)                             //and return false.
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
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("CarLeft") || other.gameObject.CompareTag("CarRight") || other.gameObject.CompareTag("Obstacle"))
        {
            //Collided with obstacle
            SetPlayerMovementSpeed(0.0f);
            internalPlayerSpeed = 0.0f;
            Destroy(GetComponent<Rigidbody>());
            HighScoreManager._instance.OnGameEnd(score);
            UIScript._instance.GameOver(score);
        }
        
        //Player moves onto a log
        if(other.gameObject.CompareTag("PlayerContainer"))
        {
            transform.SetParent(other.transform);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        //While Player is on a log
        if(other.gameObject.CompareTag("PlayerContainer") && !movementLock)
        {
            float tempX = transform.position.x - (transform.position.x % 1.5F);
            tempEndMarker.x = tempX;
            tempStartMarker.x = tempX;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        //Player leaves a log
        if(other.gameObject.CompareTag("PlayerContainer"))
        {
            transform.SetParent(null);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBox : MonoBehaviour
{
    GameObject playerSphere;
    PlayerController playerController;
    GameObject orangeWalls;
    GameObject purpleWalls;
    GameObject blueWalls;

    // Start is called before the first frame update
    void Start()
    {
        playerSphere = GameObject.Find("PlayerSphere");
        playerController = playerSphere.GetComponent<PlayerController>();
        orangeWalls = GameObject.Find("orange walls");
        purpleWalls = GameObject.Find("purple walls");
        blueWalls = GameObject.Find("blue walls");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpeedDoubles()
    {
        Debug.Log("Speed Doubles");
        playerController.DoubleSpeed();
    }

    void RateHalves()
    {
        Debug.Log("Rate Halves");
        playerController.HalveSpeed();
    }

    void CoinsDouble()
    {
        Debug.Log("Coins Double");
        playerController.DoubleCoinShrinkFactor();
    }

    void CoinsHalf()
    {
        Debug.Log("Coins Half");
        playerController.HalveCoinShrinkFactor();
    }

    void openOrange()
    {
        Debug.Log("Open Orange Door");
        orangeWalls.SetActive(false);
    }

    void openPurple()
    {
        Debug.Log("Open Purple Door");
        purpleWalls.SetActive(false);
    }

    void openBlue()
    {
        Debug.Log("Open Blue Door");
        blueWalls.SetActive(false);
    }

  
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            HandleRandomEvent();

            Destroy(gameObject);
        }
    }

    void HandleRandomEvent()
    {
        int randomEvent = Random.Range(1, 8);

        switch (randomEvent)
        {
            case 1:
                SpeedDoubles();
                break;
            case 2:
                RateHalves();
                break;
            case 3:
                CoinsDouble();
                break;
            case 4:
                CoinsHalf();
                break;
            case 5:
                openOrange();
                break;
            case 6:
                openPurple();
                break;
            case 7:
                openBlue();
                break;
            default:
                
                Debug.LogError("Unknown random event: " + randomEvent);
                break;
        }
    }
}


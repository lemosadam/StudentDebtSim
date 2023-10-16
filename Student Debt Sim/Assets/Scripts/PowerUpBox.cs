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
        PlayerController playerController = playerSphere.GetComponent<PlayerController>();
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
        
    }

    void RateHalves()
    {

    }

    void CoinsDouble()
    {

    }

    void CoinsHalf()
    {

    }

    void openOrange()
    {
        orangeWalls.SetActive(false);
    }

    void openPurple()
    {
        purpleWalls.SetActive(false);
    }

    void openBlue()
    {
        blueWalls.SetActive(false);
    }


}

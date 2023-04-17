using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerController playerController;
    private GameManager gameManager;
    private TemperatureMeter tempMeter;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        tempMeter = GameObject.FindGameObjectWithTag("TemperatureMeter").GetComponent<TemperatureMeter>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Flag"))
        {
            Debug.Log("Complete");
            gameManager.FinishLevel();
        }
        else if (gameManager.tooCold && collision.gameObject.CompareTag("TooColdTraps"))
        {
            gameManager.DEATH();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("WarmZone"))
        {
            tempMeter.warmZone = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("WarmZone"))
        {
            tempMeter.warmZone = true;
        }
        else if (collision.tag.Equals("Ice"))
        {
            playerController._moveClamp = 20;
            playerController._acceleration = 20;
            playerController._deAcceleration = 15;
        }
        else
        {
            playerController._moveClamp = 8;
            playerController._acceleration = 90;
            playerController._deAcceleration = 60;
        }
    }
}

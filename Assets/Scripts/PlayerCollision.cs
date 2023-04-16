using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
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
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Ice"))
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

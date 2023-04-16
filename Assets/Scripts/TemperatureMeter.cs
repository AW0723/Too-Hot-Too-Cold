using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TemperatureMeter : MonoBehaviour
{
    private float temp = 0.3f;
    private GameManager gameManager;
    private const float changeSpeed = 0.8f;
    private GameObject tempIndicator;
    private const float indicatorPos = 115;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        tempIndicator = GameObject.FindGameObjectWithTag("TemperatureIndicator");
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.tooCold)
        {
            temp -= changeSpeed * Time.deltaTime;
        } else
        {
            temp += changeSpeed * Time.deltaTime;
        }
        temp = Mathf.Clamp(temp, 0, 1);
        float newPos = Mathf.Lerp(-indicatorPos, indicatorPos, temp);
        tempIndicator.transform.localPosition = new Vector2(newPos, tempIndicator.transform.localPosition.y);
    }
}

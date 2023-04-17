using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TemperatureMeter : MonoBehaviour
{
    private float temp = 0.3f;
    private GameManager gameManager;
    private const float changeSpeed = 0.3f;
    private GameObject tempIndicator;
    private const float indicatorPos = 115;
    public bool warmZone = true;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        tempIndicator = GameObject.FindGameObjectWithTag("TemperatureIndicator");
    }

    // Update is called once per frame
    void Update()
    {
        if (warmZone)
        {
            MoveTowardsTemperature(0.5f);
        }
        else if (gameManager.tooCold)
        {
            temp -= changeSpeed * Time.deltaTime;
        }
        else
        {
            temp += changeSpeed * Time.deltaTime;
        }
        temp = Mathf.Clamp(temp, 0, 1);
        if(temp == 0 || temp == 1)
        {
            gameManager.DEATH();
        }
        float newPos = Mathf.Lerp(-indicatorPos, indicatorPos, temp);
        tempIndicator.transform.localPosition = new Vector2(newPos, tempIndicator.transform.localPosition.y);
    }

    private void MoveTowardsTemperature(float target)
    {
        if (temp > target)
        {
            temp -= changeSpeed * Time.deltaTime;
            if (temp < target)
                temp = target;
        }
        else if (temp < target)
        {
            temp += changeSpeed * Time.deltaTime;
            if (temp > target)
                temp = target;
        }
    }
}

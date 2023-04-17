using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameObject gameOverScreen;
    private GameObject levelCompleteScreen;

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen = GameObject.FindGameObjectWithTag("GameOverScreen");
        gameOverScreen.SetActive(false);

        levelCompleteScreen = GameObject.FindGameObjectWithTag("LevelCompleteScreen");
        levelCompleteScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void FinishLevel()
    {
        levelCompleteScreen.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    private GameObject tooColdMutable;
    private GameObject tooHotMap;

    private GameObject tooColdPrstnt;
    private GameObject tooHotPrstnt;

    private const float fadeVal = 0.6f;
    public bool tooCold = true;
    [SerializeField] private int curLevel = 0;

    private UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        tooColdMutable = GameObject.FindGameObjectWithTag("TooColdMutable");
        tooHotMap = GameObject.FindGameObjectWithTag("TooHot");
        tooColdPrstnt = GameObject.FindGameObjectWithTag("TooColdPersistent");
        tooHotPrstnt = GameObject.FindGameObjectWithTag("TooHotPersistent");
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        UpdateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleTooCold()
    {
        tooCold = !tooCold;
        UpdateMap();
    }

    private void UpdateMap()
    {
        if (tooCold)
        {
            //tooColdMutable.layer = LayerMask.NameToLayer("Interactable");
            tooHotMap.layer = LayerMask.NameToLayer("Default");
            for (int i = 0; i < tooColdMutable.transform.childCount; i++)
            {
                tooColdMutable.transform.GetChild(i).GetComponent<Tilemap>().color = new Color(1, 1, 1, 1);
                tooColdMutable.transform.GetChild(i).gameObject.layer = LayerMask.NameToLayer("Interactable");
            }
            tooHotMap.GetComponent<Tilemap>().color = new Color(1, 1, 1, fadeVal);

            tooColdPrstnt.SetActive(true);
            tooHotPrstnt.SetActive(false);
        }
        else
        {
            tooHotMap.layer = LayerMask.NameToLayer("Interactable");
            tooColdMutable.layer = LayerMask.NameToLayer("Default");
            tooHotMap.GetComponent<Tilemap>().color = new Color(1, 1, 1, 1);
            for (int i = 0; i < tooColdMutable.transform.childCount; i++)
            {
                tooColdMutable.transform.GetChild(i).GetComponent<Tilemap>().color = new Color(1, 1, 1, fadeVal);
                tooColdMutable.transform.GetChild(i).gameObject.layer = LayerMask.NameToLayer("Default");
            }

            tooHotPrstnt.SetActive(true);
            tooColdPrstnt.SetActive(false);
        }
    }

    public void FinishLevel()
    {
        Time.timeScale = 0;
        uiManager.FinishLevel();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void DEATH()
    {
        Time.timeScale = 0;
        uiManager.GameOver();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

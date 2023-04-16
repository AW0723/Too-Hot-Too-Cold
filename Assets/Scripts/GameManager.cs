using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    private GameObject tooColdMap;
    private GameObject tooHotMap;

    private GameObject tooColdPrstnt;
    private GameObject tooHotPrstnt;

    private const float fadeVal = 0.6f;

    public bool tooCold = true;

    // Start is called before the first frame update
    void Start()
    {
        tooColdMap = GameObject.FindGameObjectWithTag("TooCold");
        tooHotMap = GameObject.FindGameObjectWithTag("TooHot");
        tooColdPrstnt = GameObject.FindGameObjectWithTag("TooColdPersistent");
        tooHotPrstnt = GameObject.FindGameObjectWithTag("TooHotPersistent");

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
            tooColdMap.layer = LayerMask.NameToLayer("Interactable");
            tooHotMap.layer = LayerMask.NameToLayer("Default");
            tooColdMap.GetComponent<Tilemap>().color = new Color(1, 1, 1, 1);
            tooHotMap.GetComponent<Tilemap>().color = new Color(1, 1, 1, fadeVal);

            tooColdPrstnt.SetActive(true);
            tooHotPrstnt.SetActive(false);
        }
        else
        {
            tooHotMap.layer = LayerMask.NameToLayer("Interactable");
            tooColdMap.layer = LayerMask.NameToLayer("Default");
            tooHotMap.GetComponent<Tilemap>().color = new Color(1, 1, 1, 1);
            tooColdMap.GetComponent<Tilemap>().color = new Color(1, 1, 1, fadeVal);

            tooHotPrstnt.SetActive(true);
            tooColdPrstnt.SetActive(false);
        }
    }
}

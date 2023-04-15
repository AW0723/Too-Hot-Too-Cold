using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InputManager : MonoBehaviour
{
    private GameObject tooColdMap;
    private GameObject tooHotMap;

    private const float fadeVal = 0.6f;
    private bool tooCold = true;

    // Start is called before the first frame update
    void Start()
    {
        tooColdMap = GameObject.FindGameObjectWithTag("TooCold");
        tooHotMap = GameObject.FindGameObjectWithTag("TooHot");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            tooCold = !tooCold;
        }
        UpdateMap();
    }

    private void UpdateMap()
    {
        if(tooCold)
        {
            tooColdMap.layer = LayerMask.NameToLayer("Interactable");
            tooHotMap.layer = LayerMask.NameToLayer("Default");
            tooColdMap.GetComponent<Tilemap>().color = new Color(1, 1, 1, 1);
            tooHotMap.GetComponent<Tilemap>().color = new Color(1, 1, 1, fadeVal);
        } else
        {
            tooHotMap.layer = LayerMask.NameToLayer("Interactable");
            tooColdMap.layer = LayerMask.NameToLayer("Default");
            tooHotMap.GetComponent<Tilemap>().color = new Color(1, 1, 1, 1);
            tooColdMap.GetComponent<Tilemap>().color = new Color(1, 1, 1, fadeVal);
        }
    }
}

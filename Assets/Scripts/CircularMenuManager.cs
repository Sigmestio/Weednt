using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMenuManager : MonoBehaviour
{
    [SerializeField] private PlacementSystem placementSystem;
    [SerializeField] private GameObject circularMenu;


    void Start()
    {
        circularMenu.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            bool isEnabled = !circularMenu.activeSelf;
            circularMenu.SetActive(isEnabled);
        }
    }

    public void DisableCircularMenu()
    {
        circularMenu.SetActive(false);
    }
}

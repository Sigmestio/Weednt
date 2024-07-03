using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SaveTester : MonoBehaviour
{
    private SaveManager saveManager;

    private void Start()
    {
        saveManager = FindObjectOfType<SaveManager>();
    }

    public void Save()
    {
        saveManager.SaveGame();
    }

    public void SaveQuit()
    {
        saveManager.SaveGameAndQuit();
    }

    public void Load()
    {
        saveManager.LoadGame();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SaveTester : MonoBehaviour
{
    public SaveData saveData;
    
    [ContextMenu("Save")]
    public void Save()
    {
        Debug.Log("I'm saving");
        SerializationManager.Save("test", saveData);
    }

    [ContextMenu("Load")]
    public void Load()
    {
        Debug.Log("I'm loading");
        saveData = (SaveData)SerializationManager.Load("test");
    }
}
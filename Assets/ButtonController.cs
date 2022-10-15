using System.Collections;
using System.Collections.Generic;
using Game_Manager;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void Save()
    {
        SaveManager.Instance.Save();
    }

    public void Load()
    {
        Debug.Log(SaveManager.Instance == null);
        SaveManager.Instance.Load();
    }
}

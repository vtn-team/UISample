using System;
using System.Collections.Generic;
using UnityEngine;

public class MonoTask : MonoBehaviour
{
    void Start()
    {
        InputrManager.Instance.Setup();
        GameUI.Instance.Setup();
    }

    void Update()
    {
        InputrManager.Instance.UpdateInput();
        GameUI.Instance.UpdateUI();
    }
}

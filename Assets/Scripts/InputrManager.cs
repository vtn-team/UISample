using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputrManager : MonoBehaviour
{
    private void Start()
    {
        GameUI.Instance.Setup();    
    }

    void Update()
    {
        GameUI.Instance.Update();
    }
}

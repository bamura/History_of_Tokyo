using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafetyCheckerScript : MonoBehaviour
{
    //public Text ModeText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FloodButton()
    {
        WhatBis.SafetyChecker = 1;
        //ModeText.text = "安全性(洪水)";
    }
    public void StructureButtonDown()
    {
        WhatBis.SafetyChecker = 2;
        //ModeText.text = "安全性(躯体強度等のサンプル)";
    }

}

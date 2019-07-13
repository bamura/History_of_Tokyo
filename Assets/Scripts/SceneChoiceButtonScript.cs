using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Text表示用
//using UnityEngine.SceneManagement;

public class SceneChoiceButtonScript : MonoBehaviour
{
    //public GameObject SceneCoiceButtons;
    public GameObject AgeHistogram;
    public GameObject BreakHistogram;
    public GameObject HistoryHistogram;
    public GameObject PhotoHistogram;
    public GameObject SafetyHistogram;

    public GameObject PhotoSpotPrefab;

    public Button AgeButton;
    public Button BreakButton;
    public Button HistoryButton;
    public Button PictureButton;
    public Button SafetyButton;
    public Button MoneyButton;


    Color btnColor1 = new Color(1f, 1f, 1f);
    Color btnColor2 = new Color(1f, 1f, 0.8f);

    //public Text ModeText; //Text用変数
    //public Text HistogramOpenCloseText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AOB_Button()
    {
        WhatBis.Mode = 1;
        //ModeText.text = "築年数";
        //SceneCoiceButtons.SetActive(false);
        AgeHistogram.SetActive(true);//true
        BreakHistogram.SetActive(false);
        HistoryHistogram.SetActive(false);
        PhotoHistogram.SetActive(false);
        PhotoSpotPrefab.SetActive(false);
        SafetyHistogram.SetActive(false);
        //HistogramOpenCloseText.text = "詳細を開く";

        AgeButton.image.color = btnColor2;
        BreakButton.image.color = btnColor1;
        HistoryButton.image.color = btnColor1;
        PictureButton.image.color = btnColor1;
        SafetyButton.image.color = btnColor1;
        MoneyButton.image.color = btnColor1;

    }
    public void BF_Button()
    {
        WhatBis.Mode = 2;
        //ModeText.text = "解体";
        //SceneCoiceButtons.SetActive(false);
        AgeHistogram.SetActive(false);
        BreakHistogram.SetActive(true); //true
        HistoryHistogram.SetActive(false);
        PhotoHistogram.SetActive(false);
        PhotoSpotPrefab.SetActive(false);
        SafetyHistogram.SetActive(false);
        //HistogramOpenCloseText.text = "詳細を開く";

        AgeButton.image.color = btnColor1;
        BreakButton.image.color = btnColor2;
        HistoryButton.image.color = btnColor1;
        PictureButton.image.color = btnColor1;
        SafetyButton.image.color = btnColor1;
        MoneyButton.image.color = btnColor1;

    }
    public void History_Button()
    {
        WhatBis.Mode = 3;
        //ModeText.text = "歴史";
        //SceneCoiceButtons.SetActive(false);
        AgeHistogram.SetActive(false);
        BreakHistogram.SetActive(false);
        HistoryHistogram.SetActive(true); //true
        PhotoHistogram.SetActive(false);
        PhotoSpotPrefab.SetActive(false);
        SafetyHistogram.SetActive(false);
        //HistogramOpenCloseText.text = "詳細を開く";

        AgeButton.image.color = btnColor1;
        BreakButton.image.color = btnColor1;
        HistoryButton.image.color = btnColor2;
        PictureButton.image.color = btnColor1;
        SafetyButton.image.color = btnColor1;
        MoneyButton.image.color = btnColor1;

    }
    public void Picture_Button()
    {
        WhatBis.Mode = 4;
        //ModeText.text = "写真";
        //SceneCoiceButtons.SetActive(false);
        AgeHistogram.SetActive(false);
        BreakHistogram.SetActive(false);
        HistoryHistogram.SetActive(false);
        PhotoHistogram.SetActive(true); //true
        PhotoSpotPrefab.SetActive(true); //true
        SafetyHistogram.SetActive(false);
        //HistogramOpenCloseText.text = "詳細を開く";

        AgeButton.image.color = btnColor1;
        BreakButton.image.color = btnColor1;
        HistoryButton.image.color = btnColor1;
        PictureButton.image.color = btnColor2;
        SafetyButton.image.color = btnColor1;
        MoneyButton.image.color = btnColor1;

    }
    public void Safety_Button()
    {
        WhatBis.Mode = 5;
        WhatBis.SafetyChecker = 0;
        //ModeText.text = "安全性";
        //SceneCoiceButtons.SetActive(false);
        AgeHistogram.SetActive(false);
        BreakHistogram.SetActive(false);
        HistoryHistogram.SetActive(false);
        PhotoHistogram.SetActive(false);
        PhotoSpotPrefab.SetActive(false);
        SafetyHistogram.SetActive(true);
        //HistogramOpenCloseText.text = "詳細を開く";

        AgeButton.image.color = btnColor1;
        BreakButton.image.color = btnColor1;
        HistoryButton.image.color = btnColor1;
        PictureButton.image.color = btnColor1;
        SafetyButton.image.color = btnColor2;
        MoneyButton.image.color = btnColor1;

    }
    public void Relarive_Button()
    {
        WhatBis.Mode = 6;
        //ModeText.text = "お金・水・電気等"+"(サンプル)";
        //SceneCoiceButtons.SetActive(false);
        AgeHistogram.SetActive(false);
        BreakHistogram.SetActive(false);
        HistoryHistogram.SetActive(false);
        PhotoHistogram.SetActive(false);
        PhotoSpotPrefab.SetActive(false);
        SafetyHistogram.SetActive(false);
        //HistogramOpenCloseText.text = "詳細を開く";

        AgeButton.image.color = btnColor1;
        BreakButton.image.color = btnColor1;
        HistoryButton.image.color = btnColor1;
        PictureButton.image.color = btnColor1;
        SafetyButton.image.color = btnColor1;
        MoneyButton.image.color = btnColor2;

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Text表示用

public class HistogramOpenCloseScript : MonoBehaviour
{
    //public Text HistogramOpenCloseText;

    public GameObject AgeHistogram; //Mode1
    public GameObject BreakHistogram; //Mode2
    public GameObject HistoryHistogram; //Mode3
    public GameObject PictureHistogram; //Mode4
    public GameObject SafetyHistogram; //Mode5

    bool Check = false;

    // Start is called before the first frame update
    void Start()
    {
        //HistogramOpenCloseText.text = "詳細を開く";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HistogramOpenCloseButton()
    {

        if (Check)
        {
            if(WhatBis.Mode == 1)
            {
                AgeHistogram.SetActive(true); //true
                BreakHistogram.SetActive(false);
                HistoryHistogram.SetActive(false);
                PictureHistogram.SetActive(false);
                SafetyHistogram.SetActive(false);
                Check = false;
            }
            if (WhatBis.Mode == 2)
            {
                AgeHistogram.SetActive(false); 
                BreakHistogram.SetActive(true); //true
                HistoryHistogram.SetActive(false);
                PictureHistogram.SetActive(false);
                SafetyHistogram.SetActive(false);
                Check = false;
            }
            if (WhatBis.Mode == 3)
            {
                AgeHistogram.SetActive(false);
                BreakHistogram.SetActive(false);
                HistoryHistogram.SetActive(true); //true
                PictureHistogram.SetActive(false);
                SafetyHistogram.SetActive(false);
                Check = false;
            }
            if (WhatBis.Mode == 4)
            {
                AgeHistogram.SetActive(false);
                BreakHistogram.SetActive(false);
                HistoryHistogram.SetActive(false);
                PictureHistogram.SetActive(true); //true
                SafetyHistogram.SetActive(false);
                Check = false;
            }

            if (WhatBis.Mode == 5)
            {
                AgeHistogram.SetActive(false);
                BreakHistogram.SetActive(false);
                HistoryHistogram.SetActive(false);
                PictureHistogram.SetActive(false);
                SafetyHistogram.SetActive(true); //true
                Check = false;
            }


            /*else
            {
                AgeHistogram.SetActive(false);
                BreakHistogram.SetActive(false);
                Check = false;
            }*/

            //HistogramOpenCloseText.text = "詳細を閉じる";
        }
        else
        if (!Check)
        {
            //if (WhatBis.Mode == 1)
            //{
            AgeHistogram.SetActive(false);
            BreakHistogram.SetActive(false);
            HistoryHistogram.SetActive(false);
            PictureHistogram.SetActive(false);
            SafetyHistogram.SetActive(false);
            Check = true;
            //}
            //if (WhatBis.Mode == 2)
            //{
            //    AgeHistogram.SetActive(false);
            //    BreakHistogram.SetActive(false);
            //    HistoryHistogram.SetActive(false);
            //    Check = true;
            //}
            /*else
            {
                AgeHistogram.SetActive(false);
                BreakHistogram.SetActive(false);
                Check = true;
            }*/

            //HistogramOpenCloseText.text = "詳細を開く";
        }

    }
}

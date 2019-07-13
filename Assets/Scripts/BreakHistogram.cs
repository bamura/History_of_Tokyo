using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakHistogram : MonoBehaviour
{
    public GameObject canvas; //キャンバス
    public static List<Image> BreakHistograms = new List<Image>();
    public Image BreakHistogram_prefab;
    private Image BreakHistogramBars;
    private Vector2 BreakBarsScale;

    public Text BreakHistogramText;

    public float second;

    // Start is called before the first frame update
    void Start()
    {
        second = 0f;
        //10個の棒グラフ用の棒
        for (int n = 1; n < 11; n++)
        {
            Image whitebar = Instantiate(BreakHistogram_prefab);
            whitebar.transform.SetParent(canvas.transform, false);
            BreakHistogramBars = whitebar.GetComponent<Image>();
            RectTransform BreakBarsTransform;
            Vector3 BreakBarsPosition;
            //RectTransform AgeHistogramTransform = AgeHistogramBars.GetComponent<RectTransform>;
            BreakBarsTransform = whitebar.GetComponent<RectTransform>();
            //WhatBis whatBuilding = building.GetComponent<WhatBis>();

            BreakBarsPosition = BreakBarsTransform.localPosition;

            /*AgeBarsPosition.x = 12f*n;
            AgeBarsPosition.y = 100f;
            AgeBarsPosition.z = 0f;
            */

            BreakHistogramBars.GetComponent<Image>().color = new Color(1f, 0f , 0f, 1.0f);

            BreakBarsTransform.localPosition = BreakBarsPosition;

            BreakHistograms.Add(whitebar);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.second = SecondCount.seconds;
        var second = this.second;
        float secforyear = second;
        var intseconds = Mathf.FloorToInt(secforyear);


        List<int> BreakList = new List<int>();

        //10個の0を格納
        for (int n = 1; n < 11; n++)
        {
            BreakList.Add(0);
        }

        for (int i = 0; i < CSVreader.ConstantInfos.Count; i++)
        {
            if (CSVreader.RealKYEAR[i] < second)
            {
                for (int n = 0; n < 10; n++)
                {
                    if ((n * 10 <= (CSVreader.RealKYEAR[i] - CSVreader.NiseSYEAR[i])) && ((CSVreader.RealKYEAR[i] - CSVreader.NiseSYEAR[i]) < n * 10 + 10))
                    {
                        BreakList[n]+= CSVreader.Check1[i];
                    }
                }
            }

        }
        for (int n = 1; n < 11; n++)
        {
            //棒の位置とサイズ
            BreakBarsScale = new Vector2(BreakList[n - 1] * 10f, 9f);
            BreakHistograms[n - 1].rectTransform.sizeDelta = BreakBarsScale;
            BreakHistograms[n - 1].rectTransform.localPosition = new Vector3(/*-98*/-6.2f + BreakBarsScale.x/2, 1.5f-14.4f*n , 0f);
        }
        //Debug.Log("BreakList[0]=" + BreakList[0]);

        BreakHistogramText.text = "<size=14><b>＜解体開始時の築年数＞</b></size>\r\n" + "  0～  9年：" + BreakList[0] + "棟\r\n10～19年：" + BreakList[1] + "棟\r\n20～29年：" + BreakList[2] + "棟\r\n30～39年：" + BreakList[3] + "棟\r\n40～49年：" + BreakList[4] + "棟\r\n50～59年：" + BreakList[5] + "棟\r\n60～69年：" + BreakList[6] + "棟\r\n70～79年：" + BreakList[7] + "棟\r\n80～89年：" + BreakList[8] + "棟\r\n90～99年：" + BreakList[9] + "棟";
        //AgeHistograms[0].transform.localScale = 
    }
}

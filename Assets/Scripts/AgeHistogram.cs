using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgeHistogram : MonoBehaviour
{
    public GameObject canvas; //キャンバス
    public static List<Image> AgeHistograms = new List<Image>();
    public Image AgeHistogram_prefab;
    private Image AgeHistogramBars;
    private Vector2 AgeBarsScale;

    public float second;

    // Start is called before the first frame update
    void Start()
    {
        second = 0f;

        for (int n = 1; n < 31; n++)
        {
            Image whitebar = Instantiate(AgeHistogram_prefab);
            whitebar.transform.SetParent(canvas.transform, false);
            AgeHistogramBars = whitebar.GetComponent<Image>();
            RectTransform AgeBarsTransform;
            Vector3 AgeBarsPosition;
            //RectTransform AgeHistogramTransform = AgeHistogramBars.GetComponent<RectTransform>;
            AgeBarsTransform = whitebar.GetComponent<RectTransform>();
            //WhatBis whatBuilding = building.GetComponent<WhatBis>();

            AgeBarsPosition = AgeBarsTransform.localPosition;

            /*AgeBarsPosition.x = 12f*n;
            AgeBarsPosition.y = 100f;
            AgeBarsPosition.z = 0f;
            */

            AgeHistogramBars.GetComponent<Image>().color = new Color(0f, 0.95f- n * 0.024f, 0f, 1.0f);

            AgeBarsTransform.localPosition = AgeBarsPosition;

            AgeHistograms.Add(whitebar);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.second = SecondCount.seconds;
        var second = this.second;
        float secforyear = second;
        var intseconds = Mathf.FloorToInt(secforyear);


        List<int> AgeList = new List<int>();

        //30個の0を格納
        for (int n = 1; n < 31; n++)
        {
            AgeList.Add(0);
        }

        for (int i = 0; i < CSVreader.ConstantInfos.Count; i++)
        {
            if ((CSVreader.NiseSYEAR[i] <= second) && (second <= CSVreader.NiseKYEAR[i]))
            {
                for (int n = 0; n < 30; n++)
                {
                    if (n * 3 <= (intseconds - Mathf.FloorToInt(CSVreader.RealSYEAR[i])) && (intseconds - Mathf.FloorToInt(CSVreader.RealSYEAR[i])) < n * 3 + 3)
                    {
                        AgeList[n]+= CSVreader.Check1[i];
                    }
                }
            }

        }
        for (int n = 1; n < 31; n++)
        {

            AgeBarsScale = new Vector2(8, AgeList[n - 1] * 8);
            AgeHistograms[n - 1].rectTransform.sizeDelta = AgeBarsScale;
            AgeHistograms[n - 1].rectTransform.localPosition = new Vector3(/*-98*/-135+10f*n, -86f/*63f/*148.8*/+ (AgeList[n - 1] * 4f), 0f);
        }
        //Debug.Log("AgeList[0]=" + AgeList[0]);
        //AgeHistograms[0].transform.localScale = 
    }
}

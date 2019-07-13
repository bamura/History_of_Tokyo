using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //csv参照用
using System.Text; //csv参照用
using System;
using UnityEngine.UI; //Text表示用

public class ConstantInfoScript : MonoBehaviour
{
    private float FloorAve;
    private float ArchitecturalAreaAve;
    private float AgeAve;
    private float HeightAve;
    public Text ConstantInfoText; //Text
    //public Text AgeListText; //Text

    public float second;

    private List<string[]> ConstantInfos = new List<string[]>();
    public static List<float> RealSYEAR = new List<float>();
    public static List<float> RealKYEAR = new List<float>();
    private List<float> NiseSYEAR = new List<float>();
    private List<float> NiseKYEAR = new List<float>();
    private List<float> Floor = new List<float>();
    private List<int> Check1 = new List<int>();
    private List<float> FloorArea = new List<float>();
    private List<float> ArchitecturalArea = new List<float>();
    private List<float> Height = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        second = 0f;

        // csvファイル名
        var fileName = "ConstantInfoList0205";
        // Resourcesのcsvフォルダ内のcsvファイルをTextAssetとして取得
        var csvFile = Resources.Load("csv/" + fileName) as TextAsset;
        // csvファイルの内容をStringReaderに変換
        var floorreader = new StringReader(csvFile.text);

        while (floorreader.Peek() > -1)
        {
            // 一行読み込む
            var lineData = floorreader.ReadLine();
            // カンマ(,)区切りのデータを文字列の配列に変換
            var floorproperty = lineData.Split(',');
            // リストに追加
            ConstantInfos.Add(floorproperty);
            // 末尾まで繰り返し...
        }
        //各パラメータの配列にcsvの各行のパラメータの値を順に格納していくことを繰り返す
        foreach (var data in ConstantInfos)
        {
            RealSYEAR.Add(float.Parse(data[0]));
            RealKYEAR.Add(float.Parse(data[1]));
            NiseSYEAR.Add(float.Parse(data[2]));
            NiseKYEAR.Add(float.Parse(data[3]));
            Floor.Add(float.Parse(data[4]));
            Check1.Add(Int32.Parse(data[5]));
            FloorArea.Add(float.Parse(data[6]));
            ArchitecturalArea.Add(float.Parse(data[7]));
            Height.Add(float.Parse(data[8]));
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.second = SecondCount.seconds;
        var second = this.second;
        float secforyear = second;
        var intseconds = Mathf.FloorToInt(secforyear);
        
        //合計値用
        float FloorSum = 0f;
        float ArchitecturalAreaSum = 0f;
        int AgeSum = 0;
        float HeightSum = 0f;
        int NumOfBldgs = 0;
        //割る数用
        int floorcounter = 0;
        int ArchitecturalAreacounter = 0;
        int Agecounter = 0;
        int Heightcounter = 0;


        for (int i=0; i < ConstantInfos.Count; i++)
        {
            if ( (NiseSYEAR[i] <= second) && (second <= NiseKYEAR[i]) /*&& (Check1[i] != 0)*/ )
            {
                // 足す処理
                FloorSum += Floor[i];
                // カウンターを１増やす
                floorcounter/*++*/+= Check1[i];
            }
            if ((NiseSYEAR[i] <= second) && (second <= NiseKYEAR[i]))
            {
                // 足す処理
                ArchitecturalAreaSum += ArchitecturalArea[i];
                // カウンターを１増やす
                ArchitecturalAreacounter/*++*/+= Check1[i];
                // 足す処理
                AgeSum += intseconds - Mathf.FloorToInt(NiseSYEAR[i]); //切り捨て
                // カウンターを１増やす
                Agecounter/*++*/+= Check1[i];
                // 足す処理
                HeightSum += Height[i] * Check1[i];
                // カウンターを１増やす
                Heightcounter/*++*/+= Check1[i];
                // カウンターを１増やす
                NumOfBldgs += Check1[i];

                /*for (int n = 0; n < 30; n++)
                {
                    if (n * 3 <= (intseconds - Mathf.FloorToInt(NiseSYEAR[i])) && (intseconds - Mathf.FloorToInt(NiseSYEAR[i])) < n * 3 + 3)
                    {
                        AgeList[n]++;
                    }
                }*/
            }
        }
        // 合計÷カウンター＝平均
        if ( floorcounter == 0)
        {
            FloorAve = 0;
        }
        else
        {
            FloorAve = FloorSum / floorcounter;
        }
        if (ArchitecturalAreacounter == 0)
        {
            ArchitecturalAreaAve = 0;
        }
        else
        {
            ArchitecturalAreaAve = ArchitecturalAreaSum / ArchitecturalAreacounter;
        }
        if (Agecounter == 0)
        {
            AgeAve = 0;
        }
        else
        {
            AgeAve = AgeSum / Agecounter;
        }
        if (Heightcounter == 0)
        {
            HeightAve = 0;
        }
        else
        {
            HeightAve = HeightSum / Heightcounter;
        }


        var FloorText = Math.Round(FloorAve, 1, MidpointRounding.AwayFromZero);
        var ArchitecturalAreaText = Math.Round(ArchitecturalAreaAve, 1, MidpointRounding.AwayFromZero);
        var AgeText = Math.Round(AgeAve, 1, MidpointRounding.AwayFromZero);
        var HeightText = Math.Round(HeightAve, 1, MidpointRounding.AwayFromZero);
        ConstantInfoText.text = "建物総数：" + NumOfBldgs + "棟\r\n平均階数：" + FloorText + "階" + "\r\n" + "平均延床面積：" + ArchitecturalAreaText + "㎡" + "\r\n" + "平均築年数：" + AgeText + "年\r\n平均高さ：" + HeightText + "ｍ";
        //AgeListText.text = "築年数分布" + "\r\n" + "0～9年：" + AgeList[0] + "棟  10～19年:" + AgeList[1] + "棟  20～29年:" + AgeList[2] + "棟\r\n" + "30～39年：" + AgeList[3] + "棟  40～49年:" + AgeList[4] + "棟  50～59年:" + AgeList[5] + "棟\r\n" + "60～69年：" + AgeList[6] + "棟  70～79年:" + AgeList[7] + "棟  80～89年:" + AgeList[8] + "棟";        //AgeSlider0to5.value = AgeList[0];

    }
}

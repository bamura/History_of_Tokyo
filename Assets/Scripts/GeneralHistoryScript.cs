using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //csv参照用
using System.Text; //csv参照用
using UnityEngine.UI;
using System;
using System.Drawing;

public class GeneralHistoryScript : MonoBehaviour
{
    public float second;

    private List<string[]> GeneralHistories = new List<string[]>();
    private List<string> Seireki = new List<string>();
    private List<string> Affairs = new List<string>();
    public Text HistoryList;
    public Text Affair;
    //public Text Now;

    // Start is called before the first frame update
    void Start()
    {
        second = 0f;

        // csvファイル名
        var fileName = "GeneralHistory";
        // Resourcesのcsvフォルダ内のcsvファイルをTextAssetとして取得
        var csvFile = Resources.Load("csv/" + fileName) as TextAsset;
        // csvファイルの内容をStringReaderに変換
        var reader = new StringReader(csvFile.text);

        // csvファイルの内容を一行ずつ末尾まで取得しリストを作成
        while (reader.Peek() > -1)
        {
            // 一行読み込む
            var lineData = reader.ReadLine();
            // カンマ(,)区切りのデータを文字列の配列に変換
            var generalhistory = lineData.Split(',');
            // リストに追加
            GeneralHistories.Add(generalhistory);
            // 末尾まで繰り返し...
        }
        foreach (var data in GeneralHistories)
        {
            Seireki.Add(data[0]);
            Affairs.Add(data[1]);
        }

    }

    // Update is called once per frame
    void Update()
    {
        this.second = SecondCount.seconds;
        var second = this.second;
        float secforyear = second;
        var intseconds = Mathf.FloorToInt(secforyear);

        //真ん中にその年が入るヴァージョン
        if (0 <= intseconds && intseconds <= 4)
        {
            HistoryList.text =　"<size=14><b>＜年表＞</b></size>\r\n" + "<i>"+Seireki[0] + "　" + Affairs[0] + "\r\n" + Seireki[1] + "　" + Affairs[1] + "\r\n" + Seireki[2] + "　" + Affairs[2] + "\r\n" + Seireki[3] + "　" + Affairs[3] + "\r\n" + Seireki[4] + "　" + Affairs[4] + "\r\n</i>" + Seireki[5] + "　" + Affairs[5] + "\r\n" + Seireki[6] + "　" + Affairs[6] + "\r\n" + Seireki[7] + "　" + Affairs[7] + "\r\n" + Seireki[8] + "　" + Affairs[8] + "\r\n" + Seireki[9] + "　" + Affairs[9] + "\r\n" + Seireki[10] + "　" + Affairs[10];
        }
        if (96<=intseconds && intseconds<=100)
        {
            HistoryList.text = "<size=14><b>＜年表＞</b></size>\r\n" + Seireki[90] + "　" + Affairs[90] + "\r\n" + Seireki[91] + "　" + Affairs[91] + "\r\n" + Seireki[92] + "　" + Affairs[92] + "\r\n" + Seireki[93] + "　" + Affairs[93] + "\r\n" + Seireki[94] + "　" + Affairs[94] + "\r\n" + Seireki[95] + "　" + Affairs[95] + "\r\n<i>" + Seireki[96] + "　" + Affairs[96] + "\r\n" + Seireki[97] + "　" + Affairs[97] + "\r\n" + Seireki[98] + "　" + Affairs[98] + "\r\n" + Seireki[99] + "　" + Affairs[99] + "\r\n" + Seireki[100] + "　" + Affairs[100]+"</i>";
        }
        for(int n=5; n<96; n++)
        {
            if (intseconds == n)
            {
                HistoryList.text = "<size=14><b>＜年表＞</b></size>\r\n" + Seireki[n - 5] + "　" + Affairs[n - 5] + "\r\n" + Seireki[n - 4] + "　" + Affairs[n - 4] + "\r\n" + Seireki[n - 3] + "　" + Affairs[n - 3] + "\r\n" + Seireki[n - 2] + "　" + Affairs[n - 2] + "\r\n" + Seireki[n - 1] + "　" + Affairs[n - 1] + "\r\n<color=#ff0000><i>" + Seireki[n] + "　" + Affairs[n] + "</i></color>\r\n" + Seireki[n + 1] + "　" + Affairs[n + 1] + "\r\n" + Seireki[n + 2] + "　" + Affairs[n + 2] + "\r\n" + Seireki[n + 3] + "　" + Affairs[n + 3] + "\r\n" + Seireki[n + 4] + "　" + Affairs[n + 4] + "\r\n" + Seireki[n + 5] + "　" + Affairs[n + 5];
            }
        }

        //一番下がその年になるヴァージョン
        /*if (0 <= intseconds && intseconds <= 10)
        {
            HistoryList.text = Seireki[0] + "　" + Affairs[0] + "\r\n" + Seireki[1] + "　" + Affairs[1] + "\r\n" + Seireki[2] + "　" + Affairs[2] + "\r\n" + Seireki[3] + "　" + Affairs[3] + "\r\n" + Seireki[4] + "　" + Affairs[4] + "\r\n" + Seireki[5] + "　" + Affairs[5] + "\r\n" + Seireki[6] + "　" + Affairs[6] + "\r\n" + Seireki[7] + "　" + Affairs[7] + "\r\n" + Seireki[8] + "　" + Affairs[8] + "\r\n" + Seireki[9] + "　" + Affairs[9] + "\r\n" + Seireki[10] + "　" + Affairs[10];
        }
        for (int n = 11; n < 101; n++)
        {
            if (intseconds == n)
            {
                //Now.text = Seireki[n] + "　" + Affairs[n] + "\r\n";
                //Now.color =new Color (1,0,0,1);
                HistoryList.text = Seireki[n - 10] + "　" + Affairs[n - 10] + "\r\n" + Seireki[n - 9] + "　" + Affairs[n - 9] + "\r\n" + Seireki[n - 8] + "　" + Affairs[n - 8] + "\r\n" + Seireki[n - 7] + "　" + Affairs[n - 7] + "\r\n" + Seireki[n - 6] + "　" + Affairs[n - 6] + "\r\n" + Seireki[n - 5] + "　" + Affairs[n - 5] + "\r\n" + Seireki[n - 4] + "　" + Affairs[n - 4] + "\r\n" + Seireki[n - 3] + "　" + Affairs[n - 3] + "\r\n" + Seireki[n - 2] + "　" + Affairs[n - 2] + "\r\n" + Seireki[n - 1] + "　" + Affairs[n - 1] + "\r\n<color=#ff0000>" + Seireki[n] + "　" + Affairs[n] + "</color>";
            }
        }
        */
        Affair.text = Seireki[intseconds] + "年　"  + Affairs[intseconds];
    }
}

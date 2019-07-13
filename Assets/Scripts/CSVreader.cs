using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //csv参照用
using System.Text; //csv参照用
using System;

public class CSVreader : MonoBehaviour
{
    public static List<string[]> ConstantInfos = new List<string[]>();
    public static List<float> RealSYEAR = new List<float>();
    public static List<float> RealKYEAR = new List<float>();
    public static List<float> NiseSYEAR = new List<float>();
    public static List<float> NiseKYEAR = new List<float>();
    public static List<float> Floor = new List<float>();
    public static List<int> Check1 = new List<int>();
    public static List<float> FloorArea = new List<float>();
    public static List<float> ArchitecturalArea = new List<float>();

    public static List<string[]> TokyoBldgProperty = new List<string[]>();
    public static List<float> YearforK = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        // csvファイル名
        var fileName1 = "ConstantInfoList0205";
        // Resourcesのcsvフォルダ内のcsvファイルをTextAssetとして取得
        var csvFile1 = Resources.Load("csv/" + fileName1) as TextAsset;
        // csvファイルの内容をStringReaderに変換
        var floorreader = new StringReader(csvFile1.text);

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
        }

        var fileName2 = "Tokyo100History0124";
        // Resourcesのcsvフォルダ内のcsvファイルをTextAssetとして取得
        var csvFile2 = Resources.Load("csv/" + fileName2) as TextAsset;
        // csvファイルの内容をStringReaderに変換
        var reader = new StringReader(csvFile2.text);

        // csvファイルの内容を一行ずつ末尾まで取得しリストを作成
        while (reader.Peek() > -1)
        {
            // 一行読み込む
            var lineData = reader.ReadLine();
            // カンマ(,)区切りのデータを文字列の配列に変換
            var bldgproperty = lineData.Split(',');
            // リストに追加
            TokyoBldgProperty.Add(bldgproperty);
            // 末尾まで繰り返し...
        }
        foreach (var data in TokyoBldgProperty)
        {
            YearforK.Add(float.Parse(data[6]));
        }
    }
     // Update is called once per frame
       void Update()
    {
    }
}

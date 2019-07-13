﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //csv参照用
using System.Text; //csv参照用
using System;
//using System.Collections.Generic;

public class BF_CreateB : MonoBehaviour
{
    public GameObject BF_Building;
    private List<string[]> BF_TokyoBldgProperty = new List<string[]>();
    //public static float FloorAve;

    // Start is called before the first frame update
    void Start()
    {
        // csvファイル名
        var fileName = "Tokyo100HIS";
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
            var bldgproperty = lineData.Split(',');
            // リストに追加
            BF_TokyoBldgProperty.Add(bldgproperty);
            // 末尾まで繰り返し...
        }


        /*string line;
        while ((line = reader.ReadLine()) != null)
        {
            // ここに、文字列を分割して、出力するコードを書く
            string[] bldgproperty = line.Split(',');
            TokyoBldgProperty.Add(bldgproperty);
        }*/

        foreach (var data in BF_TokyoBldgProperty)
        {
            GameObject building = Instantiate(BF_Building) as GameObject;
            BF_WhatBis whatBuilding = building.GetComponent<BF_WhatBis>();

            whatBuilding.NAME = data[0];
            //Debug.Log(data[0]);
            whatBuilding.realSYEAR = float.Parse(data[1]);
            //Debug.Log(data[1]);
            whatBuilding.realKYEAR = float.Parse(data[2]);
            //Debug.Log(data[2]);
            whatBuilding.YearforS = float.Parse(data[3]);
            //Debug.Log(data[3]);
            whatBuilding.niseSYEAR = float.Parse(data[4]);
            //Debug.Log(data[4]);
            whatBuilding.niseKYEAR = float.Parse(data[5]);
            //Debug.Log(data[5]);
            whatBuilding.YearforK = float.Parse(data[6]);
            //Debug.Log(data[6]);
            whatBuilding.XLENGTH = float.Parse(data[7]);
            //Debug.Log(data[7]);
            whatBuilding.ZLENGTH = float.Parse(data[8]);
            //Debug.Log(data[8]);
            whatBuilding.HEIGHT = float.Parse(data[9]);
            //Debug.Log(data[9]);
            whatBuilding.XPOSITION = float.Parse(data[10]);
            //Debug.Log(data[10]);
            whatBuilding.ZPOSITION = float.Parse(data[11]);
            //Debug.Log(data[11]);
            whatBuilding.KAKUDO = float.Parse(data[12]);
            //Debug.Log(data[12]);
            //whatBuilding.FLOOR = float.Parse(data[13]);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //csv参照用
using System.Text; //csv参照用
using System;
using UnityEngine.UI; //Text表示用

//using System.Collections.Generic;

public class CreateP : MonoBehaviour
{
    public GameObject canvas; //キャンバス
    public GameObject PhotoSpotLeader; //親

    public Button DescriptionButton;
    public GameObject PhotoSpot;
    private List<string[]> PhotoProperty = new List<string[]>();
    private List<PhotoIconButton> photoIcon;
    //public static float FloorAve;
    public static List<string> TitleList = new List<String>();

    // Start is called before the first frame update
    void Start()
    {
        // csvファイル名
        var fileName = "CityPhotoes";
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
            var photoproperty = lineData.Split(',');
            // リストに追加
            PhotoProperty.Add(photoproperty);
            // 末尾まで繰り返し...
        }

        int Serial = 0;
        foreach (var data in PhotoProperty)
        {
            //GameObject pin = Instantiate(PhotoSpot) as GameObject;

            Button description = Instantiate(DescriptionButton) as Button;
            description.transform.SetParent(canvas.transform, false);
            Vector2 ButtonSize = new Vector2 (140f, 20f);
            description.GetComponent<RectTransform>().sizeDelta = ButtonSize;

            PhotoIconButton whatIcon = description.GetComponent<PhotoIconButton>();

            whatIcon.Title = data[0];
            whatIcon.ShortTitle = data[1];
            whatIcon.positionX = float.Parse(data[2]);
            whatIcon.positionY = float.Parse(data[3]);
            whatIcon.positionZ = float.Parse(data[4]);
            whatIcon.rotationX = float.Parse(data[5]);
            whatIcon.rotationY  = float.Parse(data[6]);
            whatIcon.rotationZ = float.Parse(data[7]);
            whatIcon.serial = Serial;
            Serial++;
            TitleList.Add(data[0]);
        }
        Serial = 0;

        foreach (var data in PhotoProperty)
        {
            GameObject pin = Instantiate(PhotoSpot) as GameObject;
            pin.transform.SetParent(PhotoSpotLeader.transform, false);

            PhotoIconButton whatIcon = pin.GetComponent<PhotoIconButton>();

            whatIcon.Title = data[0];
            whatIcon.ShortTitle = data[1];
            whatIcon.positionX = float.Parse(data[2]);
            whatIcon.positionY = float.Parse(data[3]);
            whatIcon.positionZ = float.Parse(data[4]);
            whatIcon.rotationX = float.Parse(data[5]);
            whatIcon.rotationY = float.Parse(data[6]);
            whatIcon.rotationZ = float.Parse(data[7]);
            whatIcon.serial = Serial;
            Serial++;

            pin.SetActive(true);
        }
        /*
        Button Irandescription = Instantiate(DescriptionButton) as Button;
        Irandescription.transform.SetParent(canvas.transform, false);
        //Irandescription.transform.position = new Vector3(20000, 20000, 200000);
        Vector2 IranButtonSize = new Vector2(120f, 40f);
        Irandescription.GetComponent<RectTransform>().sizeDelta = IranButtonSize;
        PhotoIconButton IranWhatIcon = Irandescription.GetComponent<PhotoIconButton>();
        IranWhatIcon.serial = 6;
        IranWhatIcon.positionX = 0f;
        IranWhatIcon.positionY = 0f;
        IranWhatIcon.positionZ = 0f;
        IranWhatIcon.rotationX = 0f;
        IranWhatIcon.rotationY = 0f;
        IranWhatIcon.rotationZ = 0f;
        IranWhatIcon.Title = "Iran";
        TitleList.Add("Iran");
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
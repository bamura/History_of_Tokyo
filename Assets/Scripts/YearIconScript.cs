using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //BldgNameText表示用

public class YearIconScript : MonoBehaviour
{
    public GameObject YearIcon;
    public GameObject YearHandle;
    public float second;
    public Text YearNumber;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //西暦を獲得
        this.second = SecondCount.seconds;
        var second = this.second;
        float secforyear = second;
        var intseconds = Mathf.FloorToInt(secforyear);
        var seireki = 1920 + intseconds;
        //テキストとして表示
        YearNumber.text = seireki.ToString();

        //ハンドルの移動に合わせてアイコンのy座標を変化
        Vector3 IconPosition = YearIcon.transform.localPosition;
        IconPosition.y = YearHandle.transform.localPosition.y ;
        YearIcon.transform.localPosition = IconPosition;
    }
}

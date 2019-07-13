using UnityEngine;
using UnityEngine.UI;

public class ButtonColorControl : MonoBehaviour
{
    //ボタンをキャッシュする変数
    Button btn;
    bool btnChangeFlag = true;

    //ここでカラーを設定
    static readonly Color btnColor1 = new Color(1f, 1f, 1f);
    static readonly Color btnColor2 = new Color(1.0f, 1.0f, 0.8f);

    void Awake()
    {
        //何度もアクセスするのでこの変数にキャッシュ
        btn = gameObject.GetComponent<Button>();
        btn.image.color = btnColor1;
    }

    void Start()
    {
        btn.onClick.AddListener( OnClick );
    }

    public void OnClick()
    {
        btnChangeFlag = !btnChangeFlag;
        btn.image.color = btnChangeFlag ? btnColor1 : btnColor2;
        
        /*var Mode = WhatBis.Mode;
        if(WhatBis.Mode != Mode)
        {
            btnChangeFlag = !btnChangeFlag;
            btn.image.color = btnColor1;
        }*/

    }
}
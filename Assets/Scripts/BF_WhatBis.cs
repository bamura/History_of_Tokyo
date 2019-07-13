using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //BldgNameText表示用

public class BF_WhatBis : MonoBehaviour
{
    public Text BldgNameText; //適当建物名
    public Text YearText; //Text用変数
    //public Text FloorCountText; //平均階数
    public string NAME;
    public float realSYEAR;
    public float realKYEAR;
    public float YearforS;
    public float niseSYEAR;
    public float niseKYEAR;
    public float YearforK;
    public float XLENGTH;
    public float ZLENGTH;
    public float HEIGHT;
    public float XPOSITION;
    public float ZPOSITION;
    public float KAKUDO;
    //public float FLOOR;
    public float second;
    Collider m_Collider;

    public Renderer _renderer;
    public Material originalMaterial;

    // Start is called before the first frame update
    void Start()
    {
        second = 0f;
        m_Collider = GetComponent<Collider>();

        _renderer = GetComponent<Renderer>();
        originalMaterial = new Material(_renderer.material);
    }

    void OnMouseOver()
    {
        //_didMouseOverOccurThisframe = true;
        BldgNameText.text = NAME + "\r\n" + (realSYEAR + 1920) + "年～" + (1920 + realKYEAR) + "年"; //マウスオーバーして建物名寿命

        _renderer.material.EnableKeyword("_EMISSION"); //キーワードの有効化
        _renderer.material.SetColor("_EmissionColor", new Color(1, 1, 0)); //色に光らせる

        Debug.Log("OnMouseEnter");
    }
    void OnMouseExit()
    {
        BldgNameText.text = null; //マウスオーバーやめると表示消える
        GetComponent<Renderer>().material.color = Color.gray;

        _renderer.material = originalMaterial; //元に戻す

        Debug.Log("OnMouseExit");
    }


    // Update is called once per frame
    void Update()
    {
        /*float second;
        second = secondCount.Seconds;*/
        //建物サイズを調整していく
        this.second = SecondCount.seconds;
        var second = this.second;

        Transform myTransform = this.transform;
        Vector3 localScale = myTransform.localScale;


        if ((second < (niseSYEAR - YearforS / 1000)) || (second > (niseKYEAR + YearforK / 1000)))
        {
            localScale.x = 0f; // ローカル座標を基準にした、x軸方向を0にするサイズ変更
        }

        if (((niseSYEAR - YearforS / 1000) <= second) && (second <= (niseKYEAR + YearforK / 1000)))
        {
            localScale.x = XLENGTH; // ローカル座標を基準にした、x軸方向へのサイズ変更
        }

        if (((niseSYEAR - YearforS / 1000) <= second) && (second <= niseSYEAR))
        {
            localScale.y = (2 * HEIGHT / (YearforS / 1000)) * second - 2 * HEIGHT * (niseSYEAR - YearforS / 1000) / (YearforS / 1000); //ローカル座標を基準に、y軸を関数でサイズ変更
            GetComponent<Renderer>().material.color = Color.cyan;
            m_Collider.enabled = true;
        }
        if ((niseSYEAR < second) && (second <= niseKYEAR))
        {
            localScale.y = 2 * HEIGHT;
            m_Collider.enabled = true;
            GetComponent<Renderer>().material.color = Color.gray;
        }
        if ((niseKYEAR < second) && (second <= (niseKYEAR + YearforK / 1000)))
        {
            localScale.y = (-1) * 2 * HEIGHT * second / (YearforK / 1000) + 2 * HEIGHT * (niseKYEAR / (YearforK / 1000) + 1);
            m_Collider.enabled = true;
            GetComponent<Renderer>().material.color = Color.red;
        }
        if ((second < (niseSYEAR - YearforS / 1000)) || (second > (niseKYEAR + YearforK / 1000)))
        {
            localScale.y = 0;
            //GetComponent<BoxCollider>();
            m_Collider.enabled = false;
        }

        if ((second < (niseSYEAR - YearforS / 1000)) || (second > (niseKYEAR + YearforK / 1000)))
        {
            localScale.z = 0f; // ローカル座標を基準にした、z軸方向を0にするサイズ変更
        }

        if (((niseSYEAR - YearforS / 1000) <= second) && (second <= (niseKYEAR + YearforK / 1000)))
        {
            localScale.z = ZLENGTH; // ローカル座標を基準にした、z軸方向へのサイズ変更
        }

        myTransform.localScale = localScale;

        //建物位置を指定する
        Vector3 worldPos = myTransform.position;
        worldPos.x = XPOSITION;    // ワールド座標を基準に、x座標を変更
        worldPos.y = 0.0f;    // ワールド座標を基準に、y座標を変更
        worldPos.z = ZPOSITION;    // ワールド座標を基準に、z座標を変更
        myTransform.position = worldPos;  // ワールド座標での座標を設定

        //y軸に対して回転させる
        myTransform.localEulerAngles = new Vector3(0.0f, KAKUDO, 0.0f);

        //Textとして表示
        float secforyear = second;
        var intseconds = Mathf.FloorToInt(secforyear);
        var seireki = 1920 + intseconds;
        YearText.text = seireki + "年";

        //AOBで使用
        /*for (int n = 0; n < 21; n++)
        {
            if (n * 5 <= (intseconds - Mathf.FloorToInt(niseSYEAR)) && (intseconds - Mathf.FloorToInt(niseSYEAR)) < n * 5 + 5)
            {
                GetComponent<Renderer>().material.color = new Color(0.95f - n * 0.04f, 0.95f - n * 0.04f, 0.95f - n * 0.04f, 1.0f);
                if ((niseKYEAR < second) && (second <= (niseKYEAR + YearforK / 1000)))
                {
                    GetComponent<Renderer>().material.color = Color.red;
                }

            }
        }*/
    }
}

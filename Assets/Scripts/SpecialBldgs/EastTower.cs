using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //BldgNameText表示用

public class EastTower : MonoBehaviour
{
    public Text BldgNameText; //建物名
    private string NAME;
    private float realSYEAR;
    private float realKYEAR;
    private float YearforS;
    private float niseSYEAR;
    private float niseKYEAR;
    private float YearforK;
    private float HEIGHT;
    private float second;
    Collider m_Collider;

    private float Mode2start;
    private float nextTime;
    private float interval = 1.0f;   // 点滅周期

    public GameObject Pictures;

    public Renderer _renderer;
    public Material originalMaterial;

    //public static int Mode;
    //public static int SafetyChecker;

    //相対値用
    private List<float> RelativeScores = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        //基本データ欄。ここに手打ちしていく
        NAME = "大手町ファーストスクエアイーストタワー";
        realSYEAR = 77f;
        realKYEAR = 100f;
        YearforS = 3000f; //sample
        niseSYEAR = 77.417f; //sample
        niseKYEAR = 110f;
        YearforK = 0f;
        HEIGHT = 107f;

        second = 0f;
        m_Collider = GetComponent<Collider>();

        _renderer = GetComponent<Renderer>();
        originalMaterial = new Material(_renderer.material);

        //nextTime = Time.time;

        if (realKYEAR < 100)
        {
            Mode2start = realKYEAR - 3;//解体3年前から点滅を開始
        }
        if(realKYEAR >= 100)
        {
            Mode2start = niseKYEAR - 3;//解体3年前から点滅を開始
        }

        nextTime = Mode2start;

        int KYEAR = Mathf.FloorToInt(realKYEAR);
        int SYEAR = Mathf.FloorToInt(realSYEAR);
        for (int t = 1; t < KYEAR - SYEAR + 3; t++)
        {
            //RelativeScores.Add(Random.Range((1 -t / 80) * 0.95f, (1 -t / 80) * 1.01f));
            RelativeScores.Add(Random.Range((1 - t / (realKYEAR - realSYEAR)) * 0.95f, (1 - t / (realKYEAR - realSYEAR)) * 1.05f));
        }
        //Debug.Log(RelativeScores[20]);

    }

    void OnMouseEnter()
    {
        //_didMouseOverOccurThisframe = true;
        BldgNameText.text = NAME + "\r\n" + (realSYEAR + 1920) + "年～" + (1920 + realKYEAR) + "年"; //マウスオーバーして建物名寿命

        _renderer.material.EnableKeyword("_EMISSION"); //キーワードの有効化
        _renderer.material.SetColor("_EmissionColor", new Color(1, 1, 0)); //色に光らせる

        Debug.Log("OnMouseEnter");

        if (Pictures.transform.Find(NAME) == null)
        {
            Pictures.transform.Find("NoData").gameObject.SetActive(true);
        }
        else
        {
            Pictures.transform.Find(NAME).gameObject.SetActive(true);
        }

    }
    void OnMouseExit()
    {
        BldgNameText.text = null; //マウスオーバーやめると表示消える
        //GetComponent<Renderer>().material.color = Color.gray;

        _renderer.material = originalMaterial; //元に戻す

        Debug.Log("OnMouseExit");

        if (Pictures.transform.Find(NAME) == null)
        {
            Pictures.transform.Find("NoData").gameObject.SetActive(false);
        }
        else
        {
            Pictures.transform.Find(NAME).gameObject.SetActive(false);
        }

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
            localScale.x = 0.5f; // ローカル座標を基準にした、x軸方向へのサイズ変更 //0.5倍になっていれば良いなぁ
        }

        if (((niseSYEAR - YearforS / 1000) <= second) && (second <= (niseKYEAR + YearforK / 1000)))
        {
            localScale.y = 0.5f; //ローカル座標を基準に、y軸を関数でサイズ変更
            m_Collider.enabled = true;
        }

        if ((second < (niseSYEAR - YearforS / 1000)) || (second > (niseKYEAR + YearforK / 1000)))
        {
            localScale.y = 0f;
            m_Collider.enabled = false;
            nextTime = Mode2start;//解体モード用の数値初期化
        }

        if ((second < (niseSYEAR - YearforS / 1000)) || (second > (niseKYEAR + YearforK / 1000)))
        {
            localScale.z = 0f; // ローカル座標を基準にした、z軸方向を0にするサイズ変更
        }

        if (((niseSYEAR - YearforS / 1000) <= second) && (second <= (niseKYEAR + YearforK / 1000)))
        {
            localScale.z = 0.5f; // ローカル座標を基準にした、z軸方向へのサイズ変更
        }

        myTransform.localScale = localScale;

        //建物位置を指定する
        Vector3 worldPos = myTransform.position;
        if ((second < (niseSYEAR - YearforS / 1000)) || (second > (niseKYEAR + YearforK / 1000)))
        {
            worldPos.y = -HEIGHT - 50f;    // ワールド座標を基準に、y座標を変更
        }
        if (((niseSYEAR - YearforS / 1000) <= second) && (second <= niseSYEAR))
        {
            worldPos.y = HEIGHT / 2 + ((HEIGHT / 2) * second) / (YearforS / 1000) - (HEIGHT / 2) - (HEIGHT * niseSYEAR * 1000) / (2 * YearforS);    // ワールド座標を基準に、y座標を変更
        }
        if ((niseSYEAR < second) && (second <= niseKYEAR))
        {
            worldPos.y = 0f;
        }
        if ((niseKYEAR < second) && (second <= (niseKYEAR + YearforK / 1000)))
        {
            worldPos.y = HEIGHT / 2 - (HEIGHT * second) / (2 * (YearforK / 1000)) + (HEIGHT * niseKYEAR * 1000) / (2 * YearforK);
        }


        myTransform.position = worldPos;  // ワールド座標での座標を設定

        //Textとして表示
        float secforyear = second;
        var intseconds = Mathf.FloorToInt(secforyear);
        //var seireki = 1920 + intseconds;
        //YearText.text = seireki + "年";


        if (WhatBis.Mode == 1 || WhatBis.Mode == 3) //1：築年数モード・3：歴史モード
        {
            for (int n = 0; n < 34; n++)
            {
                if (n * 3 <= (intseconds - Mathf.FloorToInt(niseSYEAR)) && (intseconds - Mathf.FloorToInt(niseSYEAR)) < n * 3 + 3)
                {
                    GetComponent<Renderer>().material.color = new Color(0.95f - n * 0.024f, 0.95f - n * 0.024f, 0.95f - n * 0.024f, 1.0f);
                    if ((niseKYEAR < second) && (second <= (niseKYEAR + YearforK / 1000)))
                    {
                        GetComponent<Renderer>().material.color = Color.red;
                    }

                }
            }
            if (((niseSYEAR - YearforS / 1000) <= second) && (second <= niseSYEAR))
            {
                GetComponent<Renderer>().material.color = Color.cyan;
            }
            if ((niseKYEAR < second) && (second <= (niseKYEAR + YearforK / 1000)))
            {
                GetComponent<Renderer>().material.color = Color.red;
            }
        }


        if (WhatBis.Mode == 2) //2：解体
        {
            if (((niseSYEAR - YearforS / 1000) <= second) && (second <= niseSYEAR))
            {
                GetComponent<Renderer>().material.color = Color.cyan;
                nextTime = Mode2start;
            }
            if ((niseKYEAR <= second) && (second <= (niseKYEAR + YearforK / 1000)))
            {
                GetComponent<Renderer>().material.color = Color.red;
                nextTime = Mode2start;
            }
            if ((niseSYEAR < second) && (second < Mode2start))
            {
                GetComponent<Renderer>().material.color = Color.gray;
                nextTime = Mode2start;
            }
            if (realKYEAR < 100)
            {
                if ((Mode2start <= second) && (second < realKYEAR))
                {
                    if (second > nextTime)
                    {
                        GetComponent<Renderer>().material.color = Color.red;

                        nextTime += interval;
                    }
                    else
                    {
                        GetComponent<Renderer>().material.color = Color.gray;
                    }
                }
            }
            if (realKYEAR >= 100)
            {
                if ((Mode2start <= second) && (second < niseKYEAR))
                {
                    if (second > nextTime)
                    {
                        GetComponent<Renderer>().material.color = Color.red;
                        nextTime += interval;
                    }
                    else
                    {
                        GetComponent<Renderer>().material.color = Color.gray;
                    }
                }

            }
        }

        if (WhatBis.Mode == 4) //4：解体
        {
            if (((niseSYEAR - YearforS / 1000) <= second) && (second <= niseSYEAR))
            {
                GetComponent<Renderer>().material.color = Color.cyan;
            }
            if ((niseKYEAR <= second) && (second <= (niseKYEAR + YearforK / 1000)))
            {
                GetComponent<Renderer>().material.color = Color.red;
            }
            if ((niseSYEAR < second) && (second < niseKYEAR))
            {
                GetComponent<Renderer>().material.color = Color.gray;
            }
        }


        if (WhatBis.Mode == 5) //5：安全性モード
        {
            if (((niseSYEAR - YearforS / 1000) <= second) && (second <= niseSYEAR))
            {
                GetComponent<Renderer>().material.color = Color.cyan;
            }
            if ((niseKYEAR < second) && (second <= (niseKYEAR + YearforK / 1000)))
            {
                GetComponent<Renderer>().material.color = Color.red;
            }
            if ((niseSYEAR < second) && (second < niseKYEAR))
            {
                if (WhatBis.SafetyChecker == 0)
                {
                    GetComponent<Renderer>().material.color = Color.gray;
                }
                if (WhatBis.SafetyChecker == 1)
                {
                    //その建物が洪水レベルがどうかで適宜変更
                    GetComponent<Renderer>().material.color = Color.yellow;
                }
                if (WhatBis.SafetyChecker == 2)
                {
                    for (int t = 1; t < Mathf.FloorToInt(realKYEAR) - Mathf.FloorToInt(realSYEAR) + 3; t++)
                    {
                        if (t <= intseconds - Mathf.FloorToInt(niseSYEAR) && intseconds - Mathf.FloorToInt(niseSYEAR) < t + 1)
                        {
                            if (RelativeScores[t] >= 1f)
                            {
                                GetComponent<Renderer>().material.color = Color.white;
                            }
                            if (RelativeScores[t] <= 0f)
                            {
                                GetComponent<Renderer>().material.color = new Color(1f, 0f, 1f, 1f);
                            }
                            if (0f < RelativeScores[t] && RelativeScores[t] < 1f)
                            {
                                float ColorPara = Mathf.Sin(RelativeScores[t] * Mathf.PI / 2);
                                GetComponent<Renderer>().material.color = new Color(1f, ColorPara, 1f, 1f);
                                //GetComponent<Renderer>().material.color = new Color(1f, RelativeScores[t], 1f, 1f);
                            }
                        }

                    }
                }
            }
        }


        if (WhatBis.Mode == 6) //Mode6:相対評価
        {
            if (((niseSYEAR - YearforS / 1000) <= second) && (second <= niseSYEAR))
            {
                GetComponent<Renderer>().material.color = Color.cyan;
            }
            if ((niseKYEAR <= second) && (second <= (niseKYEAR + YearforK / 1000)))
            {
                GetComponent<Renderer>().material.color = Color.red;
            }
            if ((niseSYEAR < second) && (second < niseKYEAR))
            {
                int KYEAR = Mathf.FloorToInt(realKYEAR);
                int SYEAR = Mathf.FloorToInt(realSYEAR);

                if (0 <= intseconds - Mathf.FloorToInt(niseSYEAR) && intseconds - Mathf.FloorToInt(niseSYEAR) < 1)
                {
                    GetComponent<Renderer>().material.color = Color.white;
                }
                for (int t = 1; t < KYEAR - SYEAR + 3; t++)
                {
                    if (t <= intseconds - Mathf.FloorToInt(niseSYEAR) && intseconds - Mathf.FloorToInt(niseSYEAR) < t + 1)
                    {
                        if (RelativeScores[t] >= 1f)
                        {
                            GetComponent<Renderer>().material.color = Color.white;
                        }
                        if (RelativeScores[t] <= 0f)
                        {
                            GetComponent<Renderer>().material.color = new Color(1f, 0f, 1f, 1f);
                        }
                        if (0f < RelativeScores[t] && RelativeScores[t] < 1f)
                        {
                            float ColorPara = Mathf.Sin(RelativeScores[t] * Mathf.PI / 2);
                            GetComponent<Renderer>().material.color = new Color(1f, ColorPara, 1f, 1f);
                            //GetComponent<Renderer>().material.color = new Color(1f, RelativeScores[t], 1f, 1f);
                        }
                    }

                }
            }
        }
    }
}

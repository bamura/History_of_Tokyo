using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //csv参照用
using System.Text; //csv参照用
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PhotoIconButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject PhotoIcon;
    public Button DescriptionButton;
    public GameObject Camera; //メインカメラをつける
    public GameObject CityPhoto;

    public Text TitleText;
    //public Text TitleText2;
    public TextMesh ShortTitleText;
    public Text IranText;

    public String Title;
    //public String Title2;
    public String ShortTitle;
    public float positionX;
    public float positionY;
    public float positionZ;
    public float rotationX;
    public float rotationY;
    public float rotationZ;

    public int serial;
    //public int serial2;
    public static int isSelected;
    //public static int isSelected2;


    // Start is called before the first frame update
    void Start()
    {
        Transform myTransform = PhotoIcon.transform;

        //ピンの位置を指定する
        Vector3 worldPos = myTransform.position;
        worldPos.x = positionX;    // ワールド座標を基準に、x座標を変更
        worldPos.y = positionY;    // ワールド座標を基準に、y座標を変更
        worldPos.z = positionZ;    // ワールド座標を基準に、z座標を変更
        myTransform.position = worldPos;  // ワールド座標での座標を設定

        //説明分の位置を指定する
        Transform DescriptionButtonTransform = DescriptionButton.transform;
        Vector3 ButtonPos = DescriptionButtonTransform.position;

        ButtonPos.x = /*210f*/508f;
        ButtonPos.y = /*262f*/1000f- serial * 30f;
        ButtonPos.z = 0f;
        DescriptionButtonTransform.position = ButtonPos;

        //TitleText2.text = Title2;
        if(Title == " ")
        {
            TitleText.text = Title;
        }
        else
        {
            TitleText.text = "【" + ShortTitle + "】" + Title;
        }
        ShortTitleText.text = ShortTitle;
    }



    public void PhotoIconDown()
    {
        /*foreach(var title in CreateP.TitleList)
        {
            CityPhoto.transform.Find(title).gameObject.SetActive(false);
            if(title == Title)
            {
                TitleText.color = Color.red;
            }
            else
            {
                TitleText.color = Color.black;
            }
        }*/

        Vector3 OriginalCamera_pos;

        OriginalCamera_pos = new Vector3(positionX, positionY, positionZ);

        Camera.transform.position = OriginalCamera_pos;
        Camera.transform.rotation = Quaternion.Euler(rotationX, rotationY, rotationZ);

        isSelected = serial;
        TitleText.color = Color.red;

        Debug.Log("Title=" + Title);
        //CityPhoto.transform.Find(Title).gameObject.SetActive(true);

    }

    public void OnPointerClick(PointerEventData data)
    {
        /*foreach (var title in CreateP.TitleList)
        {
            CityPhoto.transform.Find(title).gameObject.SetActive(false);
            if (title == Title)
            {
                TitleText.color = Color.red;
            }
            else
            {
                TitleText.color = Color.black;
            }
        }*/
        Vector3 OriginalCamera_pos;

        OriginalCamera_pos = new Vector3(positionX, positionY, positionZ);

        Camera.transform.position = OriginalCamera_pos;
        Camera.transform.rotation = Quaternion.Euler(rotationX, rotationY, rotationZ);
        Debug.Log("serial=" + serial);
        //Debug.Log("serial2=" + serial2);

        isSelected = serial;
        Debug.Log("isSelected2=" + isSelected);
        //TitleText.color = Color.green;
        //Debug.Log("TitleText2.text=" + TitleText.text);
        Debug.Log("Title2=" + Title);
        //CityPhoto.transform.Find(Title).gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (serial == isSelected)
        {
            TitleText.color = Color.red;
            foreach(var title in CreateP.TitleList)
            {
                CityPhoto.transform.Find(title).gameObject.SetActive(false);
                //Debug.Log("Title3=" + Title);
            }
            CityPhoto.transform.Find(Title).gameObject.SetActive(true);
        }
        else
        {
            TitleText.color = Color.black;
        }
        /*if (serial != isSelected2)
        {
            TitleText.color = Color.black;
        }*/
    }

}
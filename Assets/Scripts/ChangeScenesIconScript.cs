using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScenesIconScript : MonoBehaviour
{
    public GameObject SceneCoiceButtons;
    bool check = false;//条件分岐用のbool変数
    //bool firstcheck = false;

    // Start is called before the first frame update
    void Start()
    {
        SceneCoiceButtons.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScenesIcon()
    {
        /*SceneCoiceButtons.SetActive(true);
        if (!firstcheck)
        {
            SceneCoiceButtons.SetActive(true);
            firstcheck = true;
        }*/

        if (check)
        {
            SceneCoiceButtons.SetActive(true);
            check = false;
        }
        else
        if (!check)
        {
            SceneCoiceButtons.SetActive(false);
            check = true;
        }

    }

}

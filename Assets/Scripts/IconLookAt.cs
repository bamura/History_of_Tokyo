using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconLookAt : MonoBehaviour
{
    //オブジェクトを常にカメラ向きにしておく
    void Update()
    {
        Vector3 p = Camera.main.transform.position;
        p.y = transform.position.y;
        transform.LookAt(p);
    }
}

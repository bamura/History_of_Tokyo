using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//YearText表示用

public class SecondCount : MonoBehaviour
{
    public static float seconds;

    // Start is called before the first frame update
    void Start()
    {
        seconds = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds>=101)
        {
            seconds = seconds - 101;
        }
    }
}

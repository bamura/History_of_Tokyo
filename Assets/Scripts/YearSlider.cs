using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YearSlider : MonoBehaviour
{
    public static Slider yearSlider;
    // Start is called before the first frame update
    void Start()
    {
        yearSlider = GameObject.Find("Slider").GetComponent<Slider>();

        float maxYR = 100.5f;
        float minYR = 0.0001f;

        yearSlider.minValue = minYR;
        yearSlider.maxValue = maxYR;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SecondCount.seconds = yearSlider.value; //スライダーは自由に動かせるが、自動では動かない。スライダーを動かすことでsecondsを決定させる。
        }
        else
        {
            yearSlider.value = SecondCount.seconds; //スライダーはsecondsを表すので秒数に合わせて自動で動くが、手動の操作は効かない。
        }
    }
}

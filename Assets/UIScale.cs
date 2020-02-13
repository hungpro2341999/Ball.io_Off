using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScale : MonoBehaviour
{
    public RectTransform ui;

    public float baseWidth = 720;
    public float baseHeight = 1280;


    private void Awake()
    {
        var scaler = GetScale();//GetChangeResolution();


        ui.localScale = new Vector3(1 * scaler, 1 * scaler, 1 * scaler);

    }


    float GetScale()
    {
        float w = Screen.width;
        float h = Screen.height;
        var s = w / h;
        var s1 = baseWidth / baseHeight;
        return s1 / s;
    }
}
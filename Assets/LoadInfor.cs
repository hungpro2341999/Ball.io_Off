using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadInfor : MonoBehaviour
{
    public Image image;
    // Start is called before the first frame update
    public void SetImage(Sprite img)
    {
        image.sprite = img;
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}

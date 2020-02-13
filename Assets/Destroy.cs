using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    public Text text;
    public Transform trans;
    public Vector2 OffSet;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Start_Destroy(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Start_Destroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
     public void SetPosText(Vector3 pos)
    {
        trans.position = Camera.main.WorldToScreenPoint(pos+(Vector3)OffSet);
    }
}

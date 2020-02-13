using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGSheet : MonoBehaviour
{
    public string id;
    public string sheetName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ReadExcelOnline.GetTable(id, sheetName, GenerateData);
        }
    }

    private void GenerateData(IDictionary<int, Dictionary<int, string>> obj)
    {
        int count = 0;
        foreach (var row in obj.Keys)
        {
            var r = obj[row];
            foreach (var rKey in r.Keys)
            {
                Debug.Log(count + " " + rKey + "  " + r[rKey]);
            }

            count++;
        }
    }
}

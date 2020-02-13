using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
     public GameObject[] Effect;
    public static SpawnEffect Instance = null;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject getEffectName(string name)
    {
        for(int i = 0; i < Effect.Length; i++)
        {
            if(Effect[i].name == name)
            {
                return Effect[i].gameObject;
            }
        }
        return null;
    }
    public void SpawnStatus(string s)
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObj : MonoBehaviour
{
    public string objectID;
    // Start is called before the first frame update
    /*private void Awake()
    {
        objectID = name + transform.position.ToString();
    }*/
    void Start()
    {
        for (int i = 0; i < Object.FindObjectsOfType<DontDestroyObj>().Length; i++)
        {
            if (Object.FindObjectsOfType<DontDestroyObj>()[i] != this)
            {
                if (Object.FindObjectsOfType<DontDestroyObj>()[i].name == gameObject.name)
                {
                    Destroy(gameObject);
                }
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
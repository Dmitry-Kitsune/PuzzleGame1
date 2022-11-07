using UnityEngine;

public class DontDestroyObj : MonoBehaviour
{
    public string objectID;

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
}
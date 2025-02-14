using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> Roads = new List<GameObject>();
    [SerializeField] private Transform playerPrefab;
    float roadLength = 35.94f;

    void Start()
    {
        if (Roads.Count > 0)
        {
            Instantiate(Roads[0], Roads[0].transform.position, transform.rotation);
        }
        else
        {
            Debug.LogError("Roads listesi boþ! Lütfen Inspector'den ekleyin.");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMover : MonoBehaviour
{
    [SerializeField] float carSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, carSpeed);
    }
}

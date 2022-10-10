using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateConstantly : MonoBehaviour
{
    
    void Start()
    {
               
    }

    void Update()
    {
        gameObject.transform.Rotate(new Vector3(50.0f * Time.deltaTime, 0, 0));
    }
}

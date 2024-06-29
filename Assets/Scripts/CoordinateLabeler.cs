using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
        }
    }

    void DisplayCoordinates()
    {
        label.text = "--,--";
    }
}

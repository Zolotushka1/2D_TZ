using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CameraMovement : MonoBehaviour
{
    private int layer = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            layer = layer + 2;
            Vector3 Zpos = transform.position;
            Zpos.z = layer;
            transform.position = Zpos;
            Debug.Log("Layer" + layer);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            layer = layer - 2;
            Vector3 Zpos = transform.position;
            Zpos.z = layer;
            transform.position = Zpos;
            Debug.Log("Layer" + layer);
        }
    }
}

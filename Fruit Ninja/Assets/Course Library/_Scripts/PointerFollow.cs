using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerFollow : MonoBehaviour
{
    [SerializeField] Camera _camera;
    void Start()
    {
        
    }

    
    void Update()
    {
        Vector3 cameraPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        cameraPos = new Vector3(cameraPos.x, cameraPos.y);
        transform.position = cameraPos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mouse.x, mouse.y, -10);
    }
}

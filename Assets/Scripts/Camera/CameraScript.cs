using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private Camera c;
    public float fustrumHeight;
    public float fustrumWidth;
    void Start()
    {
        c = this.GetComponent<Camera>();

        fustrumHeight = -1 * 2.0f * c.transform.position.z * Mathf.Tan(c.fieldOfView * 0.5f * Mathf.Deg2Rad);

        fustrumWidth = fustrumHeight * c.aspect;

        // Debug.Log(fustrumHeight);
    }


}

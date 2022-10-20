using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBox : MonoBehaviour
{
    public float rotate= 180;
    // Start is called before the first frame update
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation",rotate+Time.time*1.2f);
    }

}

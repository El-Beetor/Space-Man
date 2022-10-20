using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGBColor : MonoBehaviour
{
    private GameObject[] RGB;

    public GameObject refPlayer;
    private PlayerController playerScript;
    public float zDist = 1f;
    //private Animator Red;
    // private Animator green;
    //private Animator blue;
    private int r, b, g;
    public int distance;
    // private SpriteRenderer[] SR;
    void Start()
    {
        playerScript = refPlayer.GetComponent<PlayerController>();

        RGB = GameObject.FindGameObjectsWithTag("RGB");

        //   Red = RGB[0].GetComponent<Animator>();
        //  green = RGB[1].GetComponent<Animator>();
        // blue = RGB[2].GetComponent<Animator>();

        float z = zDist;
        for (int i = 0; i < RGB.Length; i++)
        {
            z += .05f;
            RGB[i].transform.position = new Vector3(0, 0, z);
            // SR = RGB[i].GetComponent<SpriteRenderer>();
        }

    }

    void Update()
    {

        //Red.SetInteger("Angle", playerScript.angle);
        //  green.SetInteger("Angle", playerScript.angle);
        // blue.SetInteger("Angle", playerScript.angle);

        // Vector3 Diff = new Vector3(refPlayer.transform.position.x-playerScript.momentum[3],refPlayer.transform.position.y - playerScript.momentum[2],-1);
        // RGB[0].transform.position = new Vector3(playerScript.momentum[3],playerScript.momentum[2], 3);
        float z = zDist;

        // if (playerScript.timer >= .2)
        // {
        //     if (playerScript.timeCount % 2 != 0) playerScript.timeCount++;
        //     g = playerScript.timeCount;
        //     RGB[0].transform.position = new Vector3(playerScript.momentum[r + 1], playerScript.momentum[r], 3);
        //     RGB[1].transform.position = new Vector3(playerScript.momentum[g + 1], playerScript.momentum[g], 3);
        // }
        // else if (playerScript.timer >= 0.1)
        // {
        //     if (playerScript.timeCount % 2 != 0) playerScript.timeCount++;
        //     r = playerScript.timeCount;
        // }


        for (int i = 0; i < RGB.Length; i++)
        {
            z += .5f;
            int mult = i + 1;
            RGB[i].transform.position = new Vector3(playerScript.momentum[distance * mult + 1], playerScript.momentum[distance * mult], z);
            // if (playerScript.momentum[0] == 1 || playerScript.momentum[1] == 1) RGB[i].enable = true;
        }


    }

}

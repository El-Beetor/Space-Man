using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCharge : MonoBehaviour
{
    public float time;
    private GameObject[] Bolts;
    private float timer = 0.0f;
    private bool shot = false;
    //public GameObject light;
    // Start is called before the first frame update
    void Start()
    {
        Bolts = GameObject.FindGameObjectsWithTag("Lightning");
        for (int i = 0; i < 4; i++)
        {
            Bolts[i].GetComponent<LineRenderer>().enabled = false;
        }
        //  light.GetComponent<Light>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (shot) { timer += Time.deltaTime; }

        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < 4; i++)
            {
                Bolts[i].GetComponent<LineRenderer>().enabled = true;
            }
            //  light.GetComponent<Light>().enabled = true;
            shot = true;
        }

        if (timer >= time)
        {
            TurnOff();
        }

    }

    void TurnOff()
    {
        // light.GetComponent<Light>().enabled = false;
        for (int i = 0; i < 4; i++)
        {
            Bolts[i].GetComponent<LineRenderer>().enabled = false;
        }
        timer = 0.0f;
        shot = false;
    }
}

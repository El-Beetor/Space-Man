using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class smoke : MonoBehaviour
{
    // private GameObject[] Exuasts;
    public bool left, right, top, bottom;
    private float h, v;
    public float min, max;
    //private Experimental.VFX.VFXEventAttribute Smoke;
    // Start is called before the first frame update
    private VisualEffect visualEffect;
    void Start()
    {
        // Exuasts = GameObject.FindGameObjectsWithTag("smoke");
        visualEffect = this.GetComponent<VisualEffect>();
        visualEffect.enabled = true;
        visualEffect.Stop();
        // GetComponent<effect>().play();
    }

    // Update is called once per frame
    void Update()
    {
        h = (int)Input.GetAxisRaw("Horizontal");
        v = (int)Input.GetAxisRaw("Vertical");
        if (Input.GetButton("Dash")) visualEffect.SetFloat("Speed", max);
        else visualEffect.SetFloat("Speed", min);

        if (left)
        {
            if (Input.GetAxisRaw("Horizontal") < 0) visualEffect.Play();
            else visualEffect.Stop();
        }
        else if (right)
        {
            if (Input.GetAxisRaw("Horizontal") > 0) visualEffect.Play();
            else visualEffect.Stop();
        }
        else if (top)
        {
            if (Input.GetAxisRaw("Vertical") < 0) visualEffect.Play();
            else visualEffect.Stop();
        }
        else if (bottom)
        {
            if (Input.GetAxisRaw("Vertical") > 0) visualEffect.Play();
            else visualEffect.Stop();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;
public class Helmet : MonoBehaviour
{
    public int min, max;
    public PlayerController player;
    //public gunsprite refScript;
    private float dist;
    private float angle;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        dist = (mouse.y - transform.position.y);

        //angle = map(dist, -10, 10, min, max) * -1;
        //transform.roatation = transform.Rotate(angle, 0, 0);
        //transform.eulerAngles = new Vector3(angle, 0, 0);
        this.transform.rotation = Quaternion.Euler(new Vector3(dist, player.angle + 180, 0));
        // Debug.Log(player.transform.rotation.y);
    }
    float map(float input, float min1, float max1, float min2, float max2)
    {
        float newValue;
        if (input < min1)
        {
            input = min1;
        }
        if (input > max1)
        {
            input = max1;
        }
        float ogTotal = Abs(min1) + Abs(max1);
        float inputPlus = input + Abs(min1);
        float percentage = inputPlus / ogTotal;
        float newTotal;
        if (min2 < max2)
            newTotal = Abs(min2) + Abs(max2);
        else
            newTotal = Abs(max2) - min2;
        newValue = (newTotal * percentage) + min2;
        return newValue;
    }


}

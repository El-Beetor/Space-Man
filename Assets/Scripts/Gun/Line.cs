using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    // public GameObject line;
    private LineRenderer LineRenderer;
    private GameObject origin;
    private GameObject Destination;
    private bool New = false;

    public void CreateLine(LineRenderer newLine, GameObject NewOrigin, GameObject NewDestination)
    {
        //LineRenderer = line.GetComponent<LineRenderer>();
        LineRenderer = newLine;
        LineRenderer.enabled = true;
        origin = NewOrigin;
        Destination = NewDestination;
        New = true;
    }

    void Update()
    {
        if (New)
        {
            // float x = Destination.transform.position.x - origin.transform.position.x;
            // float y = Destination.transform.position.y - origin.transform.position.y;
            // Vector3 ThreeFourths = new Vector3(origin.transform.position.x + (3 * x / 4), origin.transform.position.y + (3 * y / 4), 0);
            // Vector3 TwoFourths = new Vector3(origin.transform.position.x + (2 * x / 4), origin.transform.position.y + (2 * y / 4), 0);
            // Vector3 Fourth = new Vector3(origin.transform.position.x + (x / 4), origin.transform.position.y + (y / 4), 0);

            LineRenderer.SetPosition(0, Destination.transform.position);
            //  LineRenderer.SetPosition(1, ThreeFourths);
            // LineRenderer.SetPosition(2, TwoFourths);
            // LineRenderer.SetPosition(3, Fourth);
            LineRenderer.SetPosition(1, origin.transform.position);
        }
    }
    // // Start is called before the first frame update
    // void Start()
    // {
    //     LineRenderer = GetComponent<LineRenderer>();
    //     //  for (int i = 0; i < 5; i++)
    //     //  {
    //     LineRenderer.SetPosition(0, Destination.position);
    //     LineRenderer.SetPosition(1, origin.position);
    //     //}
    // }

    // // Update is called once per frame
    // void Update()
    // {

    //     //  for (int i = 0; i < 5; i++)
    //     // {
    //     // Vector3 spread = new Vector3(origin.position.x + i, origin.position.y, 0);
    //     // LineRenderer.SetPosition(i, origin.position);
    //     // }
    //     LineRenderer.SetPosition(0, Destination.position);
    //     LineRenderer.SetPosition(1, origin.position);

    // }
}

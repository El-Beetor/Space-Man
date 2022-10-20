using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update    \

    public GameObject playerObject;
    private PlayerController player;
    public float speed = 1000f;
    private GameObject newLine;
    public GameObject line;
    public GameObject origin;
    public GameObject Destination;
    //private Line lineScript;
    void Start()
    {
        player = playerObject.GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 dir = Quaternion.AngleAxis(player.ArmAngle, Vector3.forward) * Vector3.left;
            Vector3 pos = transform.position;

            newLine = Instantiate(line, pos, Quaternion.identity);
            GameObject newOrigin = Instantiate(origin, pos, Quaternion.identity);
            GameObject newDest = Instantiate(Destination, pos, Quaternion.identity);

            Rigidbody newOriginRB = newOrigin.GetComponent<Rigidbody>();
            Rigidbody newDestRB = newDest.GetComponent<Rigidbody>();
            newOriginRB.AddForce(dir * (speed / 2));
            newDestRB.AddForce(dir * speed);
            Line lineScript = newLine.GetComponent<Line>();
            LineRenderer LineRenderer = newLine.GetComponent<LineRenderer>(); ;
            //LineRenderer.enabled = true;
            lineScript.CreateLine(LineRenderer, newOrigin, newDest);

            //Destroys Bullet
            Destroy(newLine, 3.0f);
            Destroy(newOrigin, 3.0f);
            Destroy(newDest, 3.0f);
        }
    }
}

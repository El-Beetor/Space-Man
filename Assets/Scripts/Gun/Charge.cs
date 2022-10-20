using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    public GameObject line;
    private LineRenderer LineRenderer;
    public Transform start;
    public Transform end;
    private Vector3 pos;
    // start is called before the first frame update
    void Start()
    {
        LineRenderer = line.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    private void OnEnable()
    {
        Application.onBeforeRender += UpdateLightning;
    }

    private void OnDisable()
    {
        Application.onBeforeRender -= UpdateLightning;
    }
    public void UpdateLightning()
    {
        float x = end.position.x - start.position.x;
        float y = end.position.y - start.position.y;
        float z = end.position.z - start.position.z;
        LineRenderer.SetPosition(0, start.position);

        for (int i = 1; i < 3; i++)
        {
            if (i == 1) { pos = new Vector3(Random.Range(start.position.x, (start.position.x + (x / 2))), Random.Range(start.position.y, (start.position.y + (y / 2))), Random.Range(start.position.z, (start.position.z + (z / 2)))); }
            else pos = new Vector3(Random.Range((start.position.x + (x / 2)), end.position.x), Random.Range((start.position.y + (y / 2)), end.position.y), Random.Range((start.position.z + (z / 2)), end.position.z));
            LineRenderer.SetPosition(i, pos);
        }
        LineRenderer.SetPosition(3, end.position);

    }
}

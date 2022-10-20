using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySprite : MonoBehaviour
{
    public Sprite[] spriteArray;

    public Sprite none;
    public GameObject refPlayer;
    private PlayerController playerScript;
    // public int i;
    private int angle;
    private SpriteRenderer body;
    void Start()
    {
        playerScript = refPlayer.GetComponent<PlayerController>();

        body = this.GetComponent<SpriteRenderer>();


    }

    void Update()
    {
        if (playerScript.momentum[0] != 0 || playerScript.momentum[1] != 0)
        {
            angle = playerScript.angle - 180;

            int index = (int)30 + (angle / 3) * -1;
            // Debug.Log(index);
            if (index >= 0 && index <= 61)
            {
                body.sprite = spriteArray[index];
            }
        }
        else
            body.sprite = none;
        // else if (index >= -61)
        // {
        //     body.sprite = spriteArray[index];
        // }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbSprite : MonoBehaviour
{

    public Sprite none;
    public GameObject Leg;
    private LegAnimation LegScript;
    public Sprite[] ForwardspriteArray;
    public Sprite[] BackwardspriteArray;
    // public Sprite[] idleSpriteArray;

    public GameObject refPlayer;
    private PlayerController playerScript;
    // public int i;
    private int angle;
    //private bool changing = false;
    //private bool pastForward = false;
    private SpriteRenderer Limb;
    private int index;
    //private double timer = 0;
    void Start()
    {
        LegScript = Leg.GetComponent<LegAnimation>();
        playerScript = refPlayer.GetComponent<PlayerController>();

        Limb = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (playerScript.momentum[0] != 0 || playerScript.momentum[1] != 0)
        {
            angle = playerScript.angle - 180;

            index = (int)30 + (angle / 3) * -1;

            //  if (changing) ImChanging();
            if (index >= 0 && index <= 61)
            {
                if (LegScript.forward) forward();
                else if (LegScript.Backward) backward();

            }
        }
        else Limb.sprite = none;
    }
    void backward()
    {
        //if (pastForward) ImChanging();

        Limb.sprite = BackwardspriteArray[index];
        //  pastForward = false;
    }

    void forward()
    {
        //  if (!pastForward) ImChanging();
        Limb.sprite = ForwardspriteArray[index];
        // pastForward = true;
    }

}

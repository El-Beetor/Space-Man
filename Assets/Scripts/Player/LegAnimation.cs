using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegAnimation : MonoBehaviour
{
    public GameObject Leg;
    public GameObject playerObject;
    private PlayerController player;
    private Animator LegAnime;
    private int dir = 1;
    private int avgangle;
    public bool forward = false;
    public bool Backward = false;

    void Start()
    {
        player = playerObject.GetComponent<PlayerController>();

        LegAnime = Leg.GetComponent<Animator>();
        avgangle = (int)(player.angleView) / 2;
        if (avgangle < 90)
        {
            dir = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Dash"))
        {
            LegAnime.SetBool("Fast", true);
        }
        else
        {
            LegAnime.SetBool("Fast", false);
        }

        if (player.Teleported && Input.mousePosition.x < 2 * Screen.width / 3 && Input.mousePosition.x > Screen.width / 3)
        {
            LegAnime.SetTrigger("Teleport");
        }
        else if (player.momentum[1] == dir)
        {
            LegAnime.ResetTrigger("Teleport");
            if (player.angle > 180)
            {
                back();
            }
            else
            {
                Forward();
            }
            // else
            // {
            //     LegAnime.SetTrigger("Idle");
            // }
        }
        else if (player.momentum[1] == dir * -1)
        {
            LegAnime.ResetTrigger("Teleport");
            if (player.angle < 180)
            {
                back();
            }
            else
            {
                Forward();
            }
            // else
            // {
            //     LegAnime.SetTrigger("Idle");
            // }
        }
    }
    void back()
    {
        forward = false;
        Backward = true;
        LegAnime.ResetTrigger("Forward");
        LegAnime.SetTrigger("Back");
    }

    void Forward()
    {
        Backward = false;
        forward = true;
        LegAnime.ResetTrigger("Back");
        LegAnime.SetTrigger("Forward");
    }
}

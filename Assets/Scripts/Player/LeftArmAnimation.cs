using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArmAnimation : MonoBehaviour
{
    public GameObject Arm;
    public GameObject playerObject;
    private PlayerController player;
    private Animator ArmAnime;
    void Start()
    {
        player = playerObject.GetComponent<PlayerController>();

        ArmAnime = Arm.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float h = (int)Input.GetAxisRaw("Horizontal");
        float v = (int)Input.GetAxisRaw("Vertical");

        if (h == 1)
        {
            ArmAnime.SetBool("Lefts", true);
        }
        else
        {
            ArmAnime.SetBool("Lefts", false);
        }
        if (h == -1)
        {
            ArmAnime.SetBool("Rights", true);
        }
        else
        {
            ArmAnime.SetBool("Rights", false); ;
        }
        if (v == 1)
        {
            ArmAnime.SetBool("Ups", true);
        }
        else
        {
            ArmAnime.SetBool("Ups", false); ;
        }
        if (v == -1)
        {
            ArmAnime.SetBool("Downs", true);
        }
        else
        {
            ArmAnime.SetBool("Downs", false); ;
        }

    }
}

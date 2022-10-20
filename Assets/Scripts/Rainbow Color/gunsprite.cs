using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;
public class gunsprite : MonoBehaviour
{
    public Sprite[] SideViewArray;
    public Sprite[] FrontViewArray;
    public Sprite none;
    // public Sprite[] idleSpriteArray;
    public GameObject refPlayer;
    public int dist;
    private PlayerController playerScript;
    // public int i;
    private int playerAngle;
    private int ArmAngle;
    private SpriteRenderer arm;
    //private double timer = 0;
    void Start()
    {
        playerScript = refPlayer.GetComponent<PlayerController>();

        arm = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (playerScript.momentum[0] != 0 || playerScript.momentum[1] != 0)
        {
            playerAngle =(int) playerScript.angle - 180;
            ArmAngle = (int) playerScript.NewArmAngle;

            int index = (int)30 + (playerAngle / 3) * -1;
            // Debug.Log(ArmAngle);
            if (index >= 0 && index <= 20)
            {
                // Debug.Log("unflip");
                arm.sprite = SideViewArray[index];
                // arm.flipX = false;
                if (playerScript.angle < 180) ArmAngle *= -1;
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, ArmAngle));
            }
            else if (index >= 35 && index < 61)
            {
                arm.sprite = none;
                // //Debug.Log("flip");
                // index = (35 - index) * -1;
                // arm.sprite = SideViewArray[index];
                // arm.flipX = true;
                // // Debug.Log("flip");
                // if (playerScript.angle < 180) ArmAngle *= -1;
                // this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, ArmAngle));
            }
            else
            {

                arm.flipX = false;
                dist = (int)(playerScript.ArmPos.y - playerScript.mouseOnScreen.y);
                int newIndex = (int)map(dist, -Screen.height, Screen.height, 61, 0);
                //Debug.Log(newIndex);
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                if (newIndex > 0 && newIndex < 61)
                    arm.sprite = FrontViewArray[newIndex];
            }

        }
        else arm.sprite = none;

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

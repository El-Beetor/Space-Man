using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;
public class PlayerController : MonoBehaviour
{
    private GameObject player;
    private Camera cam;
    private CameraScript camRef;
    public GameObject GunHand;
    public float reduceMomentum;
    public float speed;
    public float dashSpeed;
    public float teleportDistance;
    public int angleView;
    public int mouseZ;

    //for other scripts
    public int angle;
    public float NewArmAngle;
    private bool Dashed = false;
    public float ArmAngle;
    public bool Teleported;
    public List<float> momentum = new List<float>(40);
    public Vector3 mouseOnScreen;
    public Vector2 ArmPos;

    void Start()
    {
        cam = Camera.main;
        camRef = cam.GetComponent<CameraScript>();

        player = GameObject.Find("Player");

        player.transform.position = new Vector3(0, 0, 0);

        for (int i = 0; i < 38; i++)
        {
            momentum.Insert(0, 0);
        }
    }

    void Update()
    {
        Teleported = false;

        //rotates the space man to look at mouse
        PlayerRotate();
        //Rotates Arm
        ArmRotate();

        if (Input.GetButton("Dash"))
        {
            if (!Dashed)
            {
                speed *= dashSpeed;
            }
            Dashed = true;
        }
        else if (Dashed)
        {
            speed /= dashSpeed;
            Dashed = false;
        }

        //teleports the player to the opposite side of the screen if they go out of bounds.
        teleport();


        float h = (int)Input.GetAxisRaw("Horizontal");
        float v = (int)Input.GetAxisRaw("Vertical");

        player.transform.position += Vector3.right * h * speed * Time.deltaTime;
        player.transform.position += Vector3.up * v * speed * Time.deltaTime;


        //preserves the players vertical momentum
        if (v == 0)
        {
            player.transform.position += Vector3.up * speed * Time.deltaTime * momentum[0] / reduceMomentum;
        }
        //preserves the players horizontal momentum
        if (h == 0)
        {
            if (Input.GetButton("<") && Input.GetButton(">"))
            {
                player.transform.position += Vector3.right * momentum[1] * speed * Time.deltaTime;
            }
            else player.transform.position += Vector3.right * speed * Time.deltaTime * momentum[1] / reduceMomentum;
        }

        //records vertical movement
        if (v != 0)
        {
            momentum[0] = v;
        }
        //records horizontal movement
        if (h != 0)
        {
            momentum[1] = h;
        }

        momentum.Insert(2, player.transform.position.y);
        momentum.Insert(3, player.transform.position.x);

        momentum.RemoveAt(momentum.Count - 1);
        momentum.RemoveAt(momentum.Count - 1);

    }

    void teleport()
    {
        if (player.transform.position.x > (camRef.fustrumWidth / 2) + teleportDistance || player.transform.position.x < (-1 * camRef.fustrumWidth / 2) - teleportDistance
      || player.transform.position.y > (camRef.fustrumHeight / 2) + (teleportDistance / 2) || player.transform.position.y < (-1 * camRef.fustrumHeight / 2) - (teleportDistance / 2))
        {
            player.transform.position = new Vector3((-.9f * player.transform.position.x), (-.9f * player.transform.position.y), 0);
            Teleported = true;
        }
    }
    void PlayerRotate()
    {
        Vector2 playerPos = cam.WorldToScreenPoint(player.transform.position);

        mouseOnScreen = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mouseZ);

        angle = (int)AngleBetweenTwoPoints(playerPos, mouseOnScreen, "Z/X");

        angle = angleView - angle;

        player.transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));

    }
    void ArmRotate()
    {
        // Vector3 mice = cam.ScreenToWorldPoint(Input.mousePosition);
        // ArmAngle = (int)AngleBetweenTwoPoints(GunHand.transform.position, mice, "Y/X");
        // NewArmAngle = ArmAngle;
        // if (NewArmAngle > 90)
        // {
        //     NewArmAngle = 180 - NewArmAngle;
        // }
        // if (ArmAngle < -90)
        // {
        //     NewArmAngle = -180 - NewArmAngle;
        // }

        // GunHand.transform.rotation = Quaternion.Euler(new Vector3(NewArmAngle, angle, 0));
        ArmPos = cam.WorldToScreenPoint(GunHand.transform.position);

        ArmAngle = AngleBetweenTwoPoints(ArmPos, mouseOnScreen, "Y/X");
        NewArmAngle = ArmAngle;
        if (NewArmAngle > 90)
        {
            NewArmAngle = 180 - NewArmAngle;
        }
        if (ArmAngle < -90)
        {
            NewArmAngle = -180 - NewArmAngle;
        }
        //ArmAngle = NewArmAngle;

        GunHand.transform.rotation = Quaternion.Euler(new Vector3(NewArmAngle, angle, 0));

    }


    float AngleBetweenTwoPoints(Vector3 a, Vector3 b, string TOA)
    {
        if (TOA == "Z/X") return Mathf.Atan2(a.z - b.z, a.x - b.x) * Mathf.Rad2Deg;
        if (TOA == "Y/X") return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        return 0;
    }


}

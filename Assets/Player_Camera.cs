using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    public static Player_Camera init;
    public PlayerController player;
    public Camera cameraObj;

    [Header("Camera settings")]
    private Vector3 vel;
    private float smooth_speed = 1;


    private void Awake()
    {
        
    }

    private void Start()
    {

    }

    public void CameraActions()
    {
        if (player != null)
        {
            print("movement");
            follow_player();
        }
    }

     private void follow_player()
     {
        Vector3 Player_pos = Vector3.SmoothDamp(transform.position, player.transform.position, ref vel, smooth_speed * Time.deltaTime);
        transform.position = Player_pos;
     }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeeed = 1;


    [SerializeField]
    private float lookSens;


    [SerializeField] bool DodgeInput = false;

    private Vector2 moveVector;

    private Vector3 rollDir;

    private Vector2 lookVector;

    private Vector3 rotation;

    private CharacterController characterController;

    private Animator animator;

    public Player_Camera cams;

    private void Awake()
    {
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per framef
    void Update()
    {
        Move();
        Rotate();

    }

    private void LateUpdate()
    {
        //cams.CameraActions();
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();

        if (moveVector.magnitude > 0)
        {
            animator.SetBool("move", true);
        }
        else
            animator.SetBool("move", false);
    }

    private void Move()
    {
        Vector3 move = transform.right * moveVector.x + transform.forward * moveVector.y;
        characterController.Move(move * moveSpeeed * Time.deltaTime);

    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookVector = context.ReadValue<Vector2>();
    }

    public void OnRoll(InputAction.CallbackContext context)
    {
        //rollDir = context.ReadValue<Vector3>();
        print("roll");
        DodgeInput = true;
        DodgeHandler();
    }

    private void Rotate()
    {
        rotation.y += lookVector.x * lookSens * Time.deltaTime;
        transform.localEulerAngles = rotation;
    }

    private void DodgeHandler()
    {
        if (DodgeInput == true)
        {
            animator.Play("roll");
        }
        print("no roll");

    }
}

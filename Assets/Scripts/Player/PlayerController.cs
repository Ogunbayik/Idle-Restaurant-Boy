using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string HORIZONTAL_INPUT = "Horizontal";
    private const string VERTICAL_INPUT = "Vertical";

    private PlayerAnimationController animationController;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform body;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 movementDirection;

    private bool isMove;
    private bool isCarry = false;
    private void Awake()
    {
        animationController = GetComponentInChildren<PlayerAnimationController>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        HandleMovement();

        if (Input.GetKeyDown(KeyCode.Q))
            isCarry = true;
        else if (Input.GetKeyDown(KeyCode.E))
            isCarry = false;

        if (isCarry)
            animationController.CarryAnimation(true);
        else
            animationController.CarryAnimation(false);
    }

    private void HandleMovement()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL_INPUT);
        verticalInput = Input.GetAxis(VERTICAL_INPUT);

        movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
        movementDirection.Normalize();

        if (movementDirection != Vector3.zero)
            isMove = true;
        else
            isMove = false;

        if (isMove)
        {
            transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
            animationController.RunAnimation(true);
            HandleRotation();
        }
        else
            animationController.RunAnimation(false);
    }

    private void HandleRotation()
    {
        if (movementDirection != Vector3.zero)
        {
            var rotationY = Quaternion.LookRotation(movementDirection, Vector3.up);
            body.transform.rotation = Quaternion.RotateTowards(body.transform.rotation, rotationY, rotationSpeed * Time.deltaTime);
        }
    }
}

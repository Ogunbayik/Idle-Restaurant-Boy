using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerMovement : MonoBehaviour
{
    [SerializeField] private Transform enterPoint;
    private Table table;

    private enum States
    {
        GoEnterPoint,
        GoInside,
        TryToSit,
        Sit,
        TryToStandUp,
    }

    private States currentState;

    private CustomerCheckTable checkTable;
    private CustomerAnimationController animationController;
    private NavMeshAgent agent;

    private bool isWalk;
    private bool isSit;

    private Transform desiredPosition;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        checkTable = GetComponent<CustomerCheckTable>();
        animationController = GetComponentInChildren<CustomerAnimationController>();
    }
    void Start()
    {
        table = null;
        currentState = States.GoEnterPoint;
    }

    void Update()
    {
        agent.SetDestination(enterPoint.position);
        switch (currentState)
        {
            case States.GoEnterPoint:
                HandleMovement(enterPoint.position);

                var distanceBetweenEnterPoint = Vector3.Distance(transform.position, enterPoint.position);
                if (distanceBetweenEnterPoint <= 0.9f)
                    currentState = States.GoInside;

                break;
            case States.GoInside:
                table = checkTable.GetEmptyTable();
                desiredPosition = table.gameObject.transform.GetChild(0);
                HandleMovement(desiredPosition.position);
                break;
            case States.TryToSit:

                break;
            case States.Sit:
                break;
            case States.TryToStandUp:
                break;
        }

        if (agent.velocity != Vector3.zero)
            isWalk = true;
        else
            isWalk = false;

        if (isWalk)
            animationController.WalkAnimation(true);
        else
            animationController.WalkAnimation(false);


    }
    private void HandleMovement(Vector3 position)
    {
        agent.SetDestination(position);
    }
}

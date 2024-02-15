using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerMovement : MonoBehaviour
{
    private Transform enterPoint;
    private Transform outsidePoint;

    private Table table;

    private enum States
    {
        GoEnterPoint,
        CheckTable,
        Sit,
        StandUp,
        GoingOutside
    }

    private States currentState;

    private CustomerCheckTable checkTable;
    private NavMeshAgent agent;

    private bool isWalk;
    private bool isSit;
    private bool correctRecipe;

    private Transform desiredPosition;
    private Transform sitPosition;

    private float delayTimer;
    private float foodWaitingTimer = 5f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        checkTable = GetComponent<CustomerCheckTable>();

        enterPoint = FindObjectOfType<EnterPoint>().transform;
        outsidePoint = FindObjectOfType<OutsidePoint>().transform;
    }
    void Start()
    {
        table = null;
        currentState = States.GoEnterPoint;
        delayTimer = foodWaitingTimer;
    }

    void Update()
    {
        agent.SetDestination(enterPoint.position);
        switch (currentState)
        {
            case States.GoEnterPoint:
                GoingEnterPoint();
                break;
            case States.CheckTable:
                CheckingEmptyTable();
                break;
            case States.Sit:
                Sitting();
                break;
            case States.StandUp:
                isSit = false;
                transform.position = desiredPosition.position;

                if (correctRecipe)
                {
                    Debug.Log("Earn Money");
                    currentState = States.GoingOutside;
                    desiredPosition = outsidePoint;
                }
                else
                {
                    Debug.Log("Lose Money");
                    currentState = States.GoingOutside;
                    desiredPosition = outsidePoint;
                }
                break;
            case States.GoingOutside:
                agent.isStopped = false;
                HandleMovement(desiredPosition.position);
                break;
        }

        if (agent.velocity != Vector3.zero)
            isWalk = true;
        else
            isWalk = false;
    }

    private void GoingEnterPoint()
    {
        HandleMovement(enterPoint.position);

        var distanceBetweenEnterPoint = Vector3.Distance(transform.position, enterPoint.position);
        if (distanceBetweenEnterPoint <= 0.9f)
            currentState = States.CheckTable;
    }
    private void CheckingEmptyTable()
    {
        table = checkTable.GetEmptyTable();

        if (table != null)
        {
            //Have empty table..
            desiredPosition = table.gameObject.transform.GetChild(0);
        }
        else
        {
            //Dont have empty table..
            desiredPosition = outsidePoint;
        }

        HandleMovement(desiredPosition.position);

        var distanceBetweenDesiredPoint = Vector3.Distance(transform.position, desiredPosition.position);
        if (distanceBetweenDesiredPoint <= 0.1f)
        {
            currentState = States.Sit;
        }
    }
    private void Sitting()
    {
        isSit = true;
        agent.isStopped = true;
        sitPosition = checkTable.GetSitPosition();
        transform.position = sitPosition.position;
        transform.rotation = Quaternion.identity;

        delayTimer -= Time.deltaTime;
        if (delayTimer <= 0)
        {
            Debug.Log("You cant bring food!");
            currentState = States.StandUp;
            correctRecipe = true;
        }
    }

    private void HandleMovement(Vector3 position)
    {
        agent.SetDestination(position);
    }

    public bool GetIsWalk()
    {
        return isWalk;
    }

    public bool GetIsSit()
    {
        return isSit;
    }
}

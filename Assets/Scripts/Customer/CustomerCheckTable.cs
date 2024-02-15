using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerCheckTable : MonoBehaviour
{
    [SerializeField] private List<Table> tableList;

    private Table emptyTable;
    private Transform randomPosition;
    private void Start()
    {
        emptyTable = null;
    }
    private void OnTriggerEnter(Collider other)
    {
        var enterPoint = other.gameObject.GetComponent<EnterPoint>();

        if (enterPoint)
            CheckEmptyTable();

        var table = other.gameObject.GetComponent<Table>();

        if(table)
        {
            randomPosition = table.GetRandomBench().GetRandomSitPosition();
        }
    }
    private void CheckEmptyTable()
    {
        var allTables = FindObjectsOfType<Table>();

        for (int i = 0; i < allTables.Length; i++)
        {
            tableList.Add(allTables[i]);
        }

        foreach (var table in tableList)
        {
            var canSit = table.GetCanSit();
            if (canSit)
                emptyTable = table;

            if (emptyTable != null)
                Debug.Log(emptyTable.name);
        }

    }

    public Transform GetSitPosition()
    {
        return randomPosition;
    }
    public Table GetEmptyTable()
    {
        return emptyTable;
    }
}

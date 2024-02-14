using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private Transform walkPosition;
    [SerializeField] private List<Bench> benchList = new List<Bench>();
    [SerializeField] private bool canSit;

    private Bench randomBench;
    private int randomIndex;

    private void Start()
    {
        Debug.Log(GetRandomBench());
    }

    public Bench GetRandomBench()
    {
        randomIndex = Random.Range(0, benchList.Count);
        randomBench = benchList[randomIndex];
        return randomBench;
    }
    public void SwitchSittingState(bool canSit)
    {
        this.canSit = canSit;
    }

    public bool GetCanSit()
    {
        return canSit;
    }


}

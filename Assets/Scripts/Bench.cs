using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bench : MonoBehaviour
{
    [SerializeField] private Transform[] sitPositions;

    private int randomIndex;
    private Transform randomSitPosition;

    public Transform GetRandomSitPosition()
    {
        randomIndex = Random.Range(0, sitPositions.Length);
        randomSitPosition = sitPositions[randomIndex];
        return randomSitPosition;
    }
}

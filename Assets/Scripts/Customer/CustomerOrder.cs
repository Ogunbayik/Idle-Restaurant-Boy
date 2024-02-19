using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    [SerializeField] private List<Order> orderList;
    private Order order;

    private int randomIndex;
    private void Awake()
    {
        randomIndex = Random.Range(0, orderList.Count);
    }
    private void Start()
    {
        order = orderList[randomIndex];
    }

    public Order GetOrder()
    {
        return order;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Order", menuName = "Scriptable Object/Order")]
public class OrderSO : ScriptableObject
{
    [SerializeField] private string orderName;
    [SerializeField] private Sprite orderSrite;
    [SerializeField] private Transform orderPrefab;

}

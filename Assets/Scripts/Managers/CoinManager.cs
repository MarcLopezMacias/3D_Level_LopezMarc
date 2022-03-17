using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{

    [SerializeField]
    int Quantity;

    void Start()
    {
        Quantity = 0;
    }

    public void Add(int amount)
    {
        Quantity += amount;
    }

    public int GetAmount()
    {
        return Quantity;
    }
}

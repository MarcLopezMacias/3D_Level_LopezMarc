using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField]
    int CoinValue;

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            AddCoin();
        }
    }

    private void AddCoin()
    {
        Debug.Log("SHOULD ADD COIN");
        GameManager.Instance.GetComponent<CoinManager>().Add(CoinValue);
    }


}

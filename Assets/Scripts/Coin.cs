using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private MeshCollider collider;

    void Start()
    {
        collider = gameObject.GetComponent<MeshCollider>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameManager.Instance.GetComponent<CoinManager>().Add(1);
        }
    }


}

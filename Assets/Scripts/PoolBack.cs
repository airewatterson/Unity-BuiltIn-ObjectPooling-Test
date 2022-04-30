using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolBack : MonoBehaviour
{
    [SerializeField]private Spawner spawner;

    private List<GameObject> _list;

    [SerializeField] private GameManager gameManager;

    private void Update()
    {
        _list = GameManager.Instance.spawnedGameObjects;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            if (_list.Count == 0)
            {
                Debug.LogWarning("No spawned gameobject!");
                return;
            }
        
            spawner.Despawn(other.gameObject);
            _list.RemoveAt(_list.Count - 1);
            Debug.LogError("pooled");
        }

        
        
    }


    private void Pool()
    {
        
        ;
    }
}

using System.Collections.Generic;
using System.Linq;
using General;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private Spawner spawner;
    
    [Header("Boundary")]

    [SerializeField] private TMP_Text logText;
 
    [FormerlySerializedAs("_spawnedGameObjects")] public List<GameObject> spawnedGameObjects;

    private void Start()
    {
        spawnedGameObjects = new List<GameObject>();
    }

    public void Spawn()
    {
        var obj = spawner.Spawn();
        if (!obj)
        {
            Debug.LogWarning("No gameobject returned from pool");
            return;
        }
        
        spawnedGameObjects.Add(obj);



        obj.transform.position = transform.position;
    }

    public void DeSpawn()
    {
        if (spawnedGameObjects.Count == 0)
        {
            Debug.LogWarning("No spawned gameobject!");
            return;
        }

        spawner.Despawn(spawnedGameObjects.Last());
        spawnedGameObjects.RemoveAt(spawnedGameObjects.Count - 1);
    }
    
}
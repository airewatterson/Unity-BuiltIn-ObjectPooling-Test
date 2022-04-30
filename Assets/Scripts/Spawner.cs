using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    //物件池主程式
    
    //哪些東西要生成？
    [SerializeField] private GameObject bulletPrefab;
    //最大生成多少？
    [SerializeField] private int maxPoolSize;
    
    //Pool
    private ObjectPool<GameObject> _pool;

    public int CountAll => _pool.CountAll;
    public int CountActive => _pool.CountActive;
    public int CountInactive => _pool.CountInactive;
    public int MaxPoolSize => maxPoolSize;
    
    void Start()
    {
        //(如果場地上沒有物件創建物件，如果有重新創建(開啟物件)，釋放物件(關閉物件)，確認是否有收集垃圾，預設值，最大值)
        _pool = new ObjectPool<GameObject>(OnCreatePoolObject,
            OnGetPoolObject,
            OnReleasePoolObject,
            OnDestroyPoolObject, 
            false, 
            maxPoolSize, 
            maxPoolSize);
    }

    GameObject OnCreatePoolObject()
    {
        var obj = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
        obj.transform.SetParent(transform);
        return obj;
    }

    private void OnGetPoolObject(GameObject obj)
    {
        obj.SetActive(true);
    }

    private void OnReleasePoolObject(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void OnDestroyPoolObject(GameObject obj)
    {
        Destroy(obj);
    }

    public GameObject Spawn()
    {
        Debug.Log(_pool);
        if (_pool.CountActive == maxPoolSize)
        {
            Debug.LogWarning("Max pool size reached! spawn() will be ignored.");
            return null;
        }
        
        GameObject obj = _pool.Get();
        return obj;
    }

    //釋放對象物件
    public void Despawn(GameObject obj)
    {
        _pool.Release(obj);
    }
}

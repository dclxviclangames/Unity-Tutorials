using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Car : MonoBehaviour
{
    private IObjectPool<Car> carPool;

    public void SetPool(IObjectPool<Car> pool)
    {
        carPool = pool;
    }

    // Start is called before the first frame update
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Progress.Instance.PlayerInfo.spawnBackgroubd = 1;
            carPool.Release(this);
        }
    }
}

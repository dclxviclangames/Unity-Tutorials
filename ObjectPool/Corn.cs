using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Corn : MonoBehaviour
{
    private IObjectPool<Corn> cornPool;

    public void SetPool(IObjectPool<Corn> pool)
    {
        cornPool = pool;
    }

    // Start is called before the first frame update
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Progress.Instance.PlayerInfo.spawnBackgroubd = 1;
            cornPool.Release(this);
        }
    }
}

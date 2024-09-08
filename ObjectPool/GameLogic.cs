using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Pool?
using UnityEngine.Pool;


public class GameLogic : MonoBehaviour
{
    [SerializeField] private ZombieInto enemyPref;
    [SerializeField] private Forest forestPref;
    [SerializeField] private Corn cornPref;
    [SerializeField] private Village villagePref;
    [SerializeField] private Car carPref;
    [SerializeField] private Bridge bridgePref;

  /*  [SerializeField]
    private GameObject ammo;

    [SerializeField]
    private GameObject ammoS;

   */ 

    public Transform[] zombSpawnPos;
    public Transform maPos;
    public Transform ammoPos;
    public Transform cornPos;
    public Transform carPos;

    float spawntime = 0;

    private int zombieIndex = 7;
 
    int randomNum;

    private IObjectPool<ZombieInto> enemyPool;
    private IObjectPool<Forest> forestPool;
    private IObjectPool<Village> villagePool;
    private IObjectPool<Bridge> bridgePool;
    private IObjectPool<Car> carPool;
    private IObjectPool<Corn> cornPool;

    private void Start()
    {
       // Instantiate(ammo, ammoPos.position, Quaternion.identity);
        enemyPool = new ObjectPool<ZombieInto>(CreateEnemy, OnGet, OnRelease);
        forestPool = new ObjectPool<Forest>(FreateEnemy, OnFet, OnFelease);
        villagePool = new ObjectPool<Village>(VreateEnemy, OnVet, OnVelease);
        bridgePool = new ObjectPool<Bridge>(BreateEnemy, OnBet, OnBelease);
        carPool = new ObjectPool<Car>(CCreateEnemy, OnCet, OnCelease);
        cornPool = new ObjectPool<Corn>(KreateEnemy, OnKet, OnKelease);
        forestPool.Get();
    }

    private void OnGet(ZombieInto enemy)
    {
        enemy.gameObject.SetActive(true);
        StartCoroutine(RandomNumb());
        Transform randomSpawnPoint = zombSpawnPos[randomNum];
        enemy.transform.position = randomSpawnPoint.position;
    }

    private void OnRelease(ZombieInto enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private ZombieInto CreateEnemy()
    {
        ZombieInto enemy = Instantiate(enemyPref, zombSpawnPos[randomNum].position, Quaternion.identity);
        enemy.SetPool(enemyPool);
        return enemy;

    }

    //MapPooling?=)

    private void OnFet(Forest enemy)
    {
        enemy.gameObject.SetActive(true);
        Transform randomSpawnPoint = maPos;
        enemy.transform.position = randomSpawnPoint.position;
    }

    private void OnFelease(Forest enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private Forest FreateEnemy()
    {
        Forest enemy = Instantiate(forestPref, maPos.position, Quaternion.identity);
        enemy.SetPool(forestPool);
        return enemy;

    }

    private void OnVet(Village enemy)
    {
        enemy.gameObject.SetActive(true);
        Transform randomSpawnPoint = cornPos;
        enemy.transform.position = randomSpawnPoint.position;
    }

    private void OnVelease(Village enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private Village VreateEnemy()
    {
        Village enemy = Instantiate(villagePref, cornPos.position, Quaternion.identity);
        enemy.SetPool(villagePool);
        return enemy;

    }

    private void OnBet(Bridge enemy)
    {
        enemy.gameObject.SetActive(true);
        Transform randomSpawnPoint = cornPos;
        enemy.transform.position = randomSpawnPoint.position;
    }

    private void OnBelease(Bridge enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private Bridge BreateEnemy()
    {
        Bridge enemy = Instantiate(bridgePref, cornPos.position, Quaternion.identity);
        enemy.SetPool(bridgePool);
        return enemy;

    }

    private void OnCet(Car enemy)
    {
        enemy.gameObject.SetActive(true);
        Transform randomSpawnPoint = carPos;
        enemy.transform.position = randomSpawnPoint.position;
    }

    private void OnCelease(Car enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private Car CCreateEnemy()
    {
        Car enemy = Instantiate(carPref, carPos.position, Quaternion.identity);
        enemy.SetPool(carPool);
        return enemy;

    }

    private void OnKet(Corn enemy)
    {
        enemy.gameObject.SetActive(true);
        Transform randomSpawnPoint = cornPos;
        enemy.transform.position = randomSpawnPoint.position;
    }

    private void OnKelease(Corn enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private Corn KreateEnemy()
    {
        Corn enemy = Instantiate(cornPref, cornPos.position, Quaternion.identity);
        enemy.SetPool(cornPool);
        return enemy;

    }

    //??MapPooling

    private void Update()
    {
        spawntime += Time.deltaTime;

        if (Progress.Instance.PlayerInfo.spawnBackgroubd == 1)
        {   
            StartCoroutine(RandomNumb());
            if (randomNum == 0)
            {
                forestPool.Get();
             //   Instantiate(ammo, ammoPos.position, Quaternion.identity);
                Progress.Instance.PlayerInfo.spawnBackgroubd = 0;

            }

            if (randomNum == 1)
            {
                cornPool.Get();
                
            //    Instantiate(ammo, ammoPos.position, Quaternion.identity);
                Progress.Instance.PlayerInfo.spawnBackgroubd = 0;
            }
            if (randomNum == 2)
            {
                
                bridgePool.Get();
                
              //  Instantiate(ammoS, ammoPos.position, Quaternion.identity);
                Progress.Instance.PlayerInfo.spawnBackgroubd = 0;
            }
            if (randomNum == 3)
            {
                
                villagePool.Get();
                
             //   Instantiate(ammo, ammoPos.position, Quaternion.identity);
                Progress.Instance.PlayerInfo.spawnBackgroubd = 0;
            }
            if (randomNum == 4)
            {
                carPool.Get();
              //  Instantiate(ammoS, ammoPos.position, Quaternion.identity);
                Progress.Instance.PlayerInfo.spawnBackgroubd = 0;
               
            }
        }
        else
        {
            StopCoroutine(RandomNumb());
        }

        if(spawntime > zombieIndex && Progress.Instance.PlayerInfo.gameOver == 0)
        {
            enemyPool.Get();
            spawntime = 0;
        }
        else
        {
            spawntime += Time.deltaTime;
        }

        if (Time.frameCount % 30 == 0)
        {
            System.GC.Collect();
        }
    }

    private IEnumerator RandomNumb()
    {
        yield return new WaitForSeconds(0.01f);
        randomNum = Random.Range(0, 5);
        StopCoroutine(RandomNumb());

    }
}

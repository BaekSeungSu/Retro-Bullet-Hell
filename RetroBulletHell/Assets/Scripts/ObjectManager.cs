using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject bossPrefab;

    public GameObject enemyLPrefab;
    public GameObject enemyMPrefab;
    public GameObject enemySPrefab;

    public GameObject itemScorePrefab;
    public GameObject itemPowerPrefab;
    public GameObject itemBoomPrefab;

    public GameObject bulletPlayerAPrefab;
    public GameObject bulletPlayerBPrefab;
    public GameObject bulletPlayerCPrefab;
    public GameObject bulletPlayerDPrefab;
    public GameObject bulletPlayerEPrefab;

    public GameObject bulletEnemyAPrefab;
    public GameObject bulletEnemyBPrefab;

    //public GameObject bulletFollowerPrefab;
    public GameObject bulletBossAPrefab;
    public GameObject bulletBossBPrefab;
    public GameObject bulletBossCPrefab;

    GameObject[] boss;

    GameObject[] enemyL;
    GameObject[] enemyM;
    GameObject[] enemyS;

    GameObject[] itemScore;
    GameObject[] itemPower;
    GameObject[] itemBoom;

    GameObject[] bulletPlayerA;
    GameObject[] bulletPlayerB;
    GameObject[] bulletPlayerC;
    GameObject[] bulletPlayerD;
    GameObject[] bulletPlayerE;

    GameObject[] bulletEnemyA;
    GameObject[] bulletEnemyB;

    //GameObject[] bulletFollower;
    GameObject[] bulletBossA;
    GameObject[] bulletBossB;
    GameObject[] bulletBossC;

    GameObject[] targetPool;

    void Awake()
    {
        boss = new GameObject[10];
        enemyL = new GameObject[10];
        enemyM = new GameObject[10];
        enemyS = new GameObject[20];

        itemScore = new GameObject[20];
        itemPower = new GameObject[10];
        itemBoom = new GameObject[10];

        bulletPlayerA = new GameObject[100];
        bulletPlayerB = new GameObject[100];
        bulletPlayerC = new GameObject[100];
        bulletPlayerD = new GameObject[100];
        bulletPlayerE = new GameObject[100];

        bulletEnemyA = new GameObject[100];
        bulletEnemyB = new GameObject[500];
        
        //bulletFollower = new GameObject[100];
        
        bulletBossA = new GameObject[100];
        bulletBossB = new GameObject[100];
        bulletBossC = new GameObject[500];

        Generate();
    }
    
    void Generate()
    {
        //Enemy
        for (int index = 0; index < boss.Length; index++)
        {
            boss[index] = Instantiate(bossPrefab);
            boss[index].SetActive(false);
        }

        for (int index = 0; index < enemyL.Length; index++)
        {
            enemyL[index] = Instantiate(enemyLPrefab);
            enemyL[index].SetActive(false);
        }


        for (int index = 0; index < enemyM.Length; index++)
        {
            enemyM[index] = Instantiate(enemyMPrefab);
            enemyM[index].SetActive(false);
        }

        for (int index = 0; index < enemyS.Length; index++)
        {
            enemyS[index] = Instantiate(enemySPrefab);
            enemyS[index].SetActive(false);
        }

        //Item
        for (int index = 0; index < itemScore.Length; index++)
        {
            itemScore[index] = Instantiate(itemScorePrefab);
            itemScore[index].SetActive(false);
        }

        for (int index = 0; index < itemPower.Length; index++)
        {
            itemPower[index] = Instantiate(itemPowerPrefab);
            itemPower[index].SetActive(false);
        }

        for (int index = 0; index < itemBoom.Length; index++)
        {
            itemBoom[index] = Instantiate(itemBoomPrefab);
            itemBoom[index].SetActive(false);
        }

        //Bullet
        for (int index = 0; index < bulletPlayerA.Length; index++)
        {
            bulletPlayerA[index] = Instantiate(bulletPlayerAPrefab);
            bulletPlayerA[index].SetActive(false);
        }

        for (int index = 0; index < bulletPlayerB.Length; index++)
        {
            bulletPlayerB[index] = Instantiate(bulletPlayerBPrefab);
            bulletPlayerB[index].SetActive(false);
        }

        for (int index = 0; index < bulletPlayerC.Length; index++)
        {
            bulletPlayerC[index] = Instantiate(bulletPlayerCPrefab);
            bulletPlayerC[index].SetActive(false);
        }

        for (int index = 0; index < bulletPlayerD.Length; index++)
        {
            bulletPlayerD[index] = Instantiate(bulletPlayerDPrefab);
            bulletPlayerD[index].SetActive(false);
        }

        for (int index = 0; index < bulletPlayerE.Length; index++)
        {
            bulletPlayerE[index] = Instantiate(bulletPlayerEPrefab);
            bulletPlayerE[index].SetActive(false);
        }

        for (int index = 0; index < bulletEnemyA.Length; index++)
        {
            bulletEnemyA[index] = Instantiate(bulletEnemyAPrefab);
            bulletEnemyA[index].SetActive(false);
        }

        for (int index = 0; index < bulletEnemyB.Length; index++)
        {
            bulletEnemyB[index] = Instantiate(bulletEnemyBPrefab);
            bulletEnemyB[index].SetActive(false);
        }
        /*
        for (int index = 0; index < bulletFollower.Length; index++)
        {
            bulletFollower[index] = Instantiate(bulletFollowerPrefab);
            bulletFollower[index].SetActive(false);
        }
        */
        for (int index = 0; index < bulletBossA.Length; index++)
        {
            bulletBossA[index] = Instantiate(bulletBossAPrefab);
            bulletBossA[index].SetActive(false);
        }

        for (int index = 0; index < bulletBossB.Length; index++)
        {
            bulletBossB[index] = Instantiate(bulletBossBPrefab);
            bulletBossB[index].SetActive(false);
        }

        for (int index = 0; index < bulletBossC.Length; index++)
        {
            bulletBossC[index] = Instantiate(bulletBossCPrefab);
            bulletBossC[index].SetActive(false);
        }

    }

    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "Boss":
                targetPool = boss;
                break;
            case "EnemyL":
                targetPool = enemyL;
                break;
            case "EnemyM":
                targetPool = enemyM;
                break;
            case "EnemyS":
                targetPool = enemyS;
                break;
            case "ItemScore":
                targetPool = itemScore;
                break;
            case "ItemPower":
                targetPool = itemPower;
                break;
            case "ItemBoom":
                targetPool = itemBoom;
                break;
            case "BulletPlayerA":
                targetPool = bulletPlayerA;
                break;
            case "BulletPlayerB":
                targetPool = bulletPlayerB;
                break;
            case "BulletPlayerC":
                targetPool = bulletPlayerC;
                break;
            case "BulletPlayerD":
                targetPool = bulletPlayerD;
                break;
            case "BulletPlayerE":
                targetPool = bulletPlayerE;
                break;
            case "BulletEnemyA":
                targetPool = bulletEnemyA;
                break;
            case "BulletEnemyB":
                targetPool = bulletEnemyB;
                break;
            /*
            case "BulletFollower":
                targetPool = bulletFollower;
                break;
            */
            case "BulletBossA":
                targetPool = bulletBossA;
                break;
            case "BulletBossB":
                targetPool = bulletBossB;
                break;
            case "BulletBossC":
                targetPool = bulletBossC;
                break;

        }

        for (int index = 0; index < targetPool.Length; index++)
        {
            if (!targetPool[index].activeSelf)
            {
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }

        return null;
    }

    public GameObject[] GetPool(string type)
    {
        switch (type)
        {
            case "Boss":
                targetPool = boss;
                break;
            case "EnemyL":
                targetPool = enemyL;
                break;
            case "EnemyM":
                targetPool = enemyM;
                break;
            case "EnemyS":
                targetPool = enemyS;
                break;
            case "ItemScore":
                targetPool = itemScore;
                break;
            case "ItemPower":
                targetPool = itemPower;
                break;
            case "ItemBoom":
                targetPool = itemBoom;
                break;
            case "BulletPlayerA":
                targetPool = bulletPlayerA;
                break;
            case "BulletPlayerB":
                targetPool = bulletPlayerB;
                break;
            case "BulletPlayerC":
                targetPool = bulletPlayerC;
                break;
            case "BulletPlayerD":
                targetPool = bulletPlayerD;
                break;
            case "BulletPlayerE":
                targetPool = bulletPlayerE;
                break;
            case "BulletEnemyA":
                targetPool = bulletEnemyA;
                break;
            case "BulletEnemyB":
                targetPool = bulletEnemyB;
                break;
            /*
            case "BulletFollower":
                targetPool = bulletFollower;
                break;
            */
            case "BulletBossA":
                targetPool = bulletBossA;
                break;
            case "BulletBossB":
                targetPool = bulletBossB;
                break;
            case "BulletBossC":
                targetPool = bulletBossC;
                break;
        }
        return targetPool;
    }
}

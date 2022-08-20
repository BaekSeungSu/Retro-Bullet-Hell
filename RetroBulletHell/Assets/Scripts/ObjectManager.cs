using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject boss1Prefab;
    public GameObject boss2Prefab;

    public GameObject enemyLPrefab;
    public GameObject enemyMPrefab;
    public GameObject enemySPrefab;

    public GameObject enemyLLPrefab;
    public GameObject enemyMMPrefab;
    public GameObject enemySSPrefab;

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
    public GameObject bulletEnemyCPrefab;
    public GameObject bulletEnemyDPrefab;
    public GameObject bulletEnemyEPrefab;

    //public GameObject bulletFollowerPrefab;

    //Stage1 Boss Bullet
    public GameObject bulletBossAPrefab;
    public GameObject bulletBossBPrefab;
    public GameObject bulletBossCPrefab;

    //Stage2 Boss Bullet
    public GameObject bulletBossDPrefab;
    public GameObject bulletBossEPrefab;
    public GameObject bulletBossFPrefab;

    public GameObject explosionPrefab;

    GameObject[] boss1;
    GameObject[] boss2;

    GameObject[] enemyL;
    GameObject[] enemyM;
    GameObject[] enemyS;
    GameObject[] enemyLL;
    GameObject[] enemyMM;
    GameObject[] enemySS;

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
    GameObject[] bulletEnemyC;
    GameObject[] bulletEnemyD;
    GameObject[] bulletEnemyE;

    //Stage1 Boss Bullet
    GameObject[] bulletBossA;
    GameObject[] bulletBossB;
    GameObject[] bulletBossC;

    //Stage2 Boss Bullet
    GameObject[] bulletBossD;
    GameObject[] bulletBossE;
    GameObject[] bulletBossF;

    GameObject[] targetPool;

    GameObject[] explosion;
    void Awake()
    {
        boss1 = new GameObject[1];
        boss2 = new GameObject[1];
        enemyL = new GameObject[10];
        enemyM = new GameObject[10];
        enemyS = new GameObject[20];
        enemyLL = new GameObject[10];
        enemyMM = new GameObject[10];
        enemySS = new GameObject[20];

        itemScore = new GameObject[20];
        itemPower = new GameObject[10];
        itemBoom = new GameObject[10];

        bulletPlayerA = new GameObject[100];
        bulletPlayerB = new GameObject[100];
        bulletPlayerC = new GameObject[100];
        bulletPlayerD = new GameObject[100];
        bulletPlayerE = new GameObject[100];

        bulletEnemyA = new GameObject[1000];
        bulletEnemyB = new GameObject[1000];
        bulletEnemyC = new GameObject[1000];
        bulletEnemyD = new GameObject[1000];
        bulletEnemyE = new GameObject[1000];

        //bulletFollower = new GameObject[100];

        bulletBossA = new GameObject[1000];
        bulletBossB = new GameObject[1000];
        bulletBossC = new GameObject[1000];
        bulletBossD = new GameObject[1000];
        bulletBossE = new GameObject[1000];
        bulletBossF = new GameObject[1000];

        explosion = new GameObject[50];

        Generate();
    }
    
    void Generate()
    {
        //Enemy
        for (int index = 0; index < boss1.Length; index++)
        {
            boss1[index] = Instantiate(boss1Prefab);
            boss1[index].SetActive(false);
        }

        for (int index = 0; index < boss2.Length; index++)
        {
            boss2[index] = Instantiate(boss2Prefab);
            boss2[index].SetActive(false);
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

        for (int index = 0; index < enemySS.Length; index++)
        {
            enemySS[index] = Instantiate(enemySSPrefab);
            enemySS[index].SetActive(false);
        }

        for (int index = 0; index < enemyLL.Length; index++)
        {
            enemyLL[index] = Instantiate(enemyLLPrefab);
            enemyLL[index].SetActive(false);
        }


        for (int index = 0; index < enemyM.Length; index++)
        {
            enemyMM[index] = Instantiate(enemyMMPrefab);
            enemyMM[index].SetActive(false);
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

        for (int index = 0; index < bulletEnemyC.Length; index++)
        {
            bulletEnemyC[index] = Instantiate(bulletEnemyCPrefab);
            bulletEnemyC[index].SetActive(false);
        }

        for (int index = 0; index < bulletEnemyD.Length; index++)
        {
            bulletEnemyD[index] = Instantiate(bulletEnemyDPrefab);
            bulletEnemyD[index].SetActive(false);
        }

        for (int index = 0; index < bulletEnemyE.Length; index++)
        {
            bulletEnemyE[index] = Instantiate(bulletEnemyEPrefab);
            bulletEnemyE[index].SetActive(false);
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

        for (int index = 0; index < bulletBossD.Length; index++)
        {
            bulletBossD[index] = Instantiate(bulletBossDPrefab);
            bulletBossD[index].SetActive(false);
        }

        for (int index = 0; index < bulletBossE.Length; index++)
        {
            bulletBossE[index] = Instantiate(bulletBossEPrefab);
            bulletBossE[index].SetActive(false);
        }

        for (int index = 0; index < bulletBossF.Length; index++)
        {
            bulletBossF[index] = Instantiate(bulletBossFPrefab);
            bulletBossF[index].SetActive(false);
        }

        for (int index = 0; index < explosion.Length; index++)
        {
            explosion[index] = Instantiate(explosionPrefab);
            explosion[index].SetActive(false);
        }

    }

    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "Boss1":
                targetPool = boss1;
                break;
            case "Boss2":
                targetPool = boss2;
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
            case "EnemyLL":
                targetPool = enemyLL;
                break;
            case "EnemyMM":
                targetPool = enemyMM;
                break;
            case "EnemySS":
                targetPool = enemySS;
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
            case "BulletEnemyC":
                targetPool = bulletEnemyC;
                break;
            case "BulletEnemyD":
                targetPool = bulletEnemyD;
                break;
            case "BulletEnemyE":
                targetPool = bulletEnemyE;
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
            case "BulletBossD":
                targetPool = bulletBossD;
                break;
            case "BulletBossE":
                targetPool = bulletBossE;
                break;
            case "BulletBossF":
                targetPool = bulletBossF;
                break;
            case "Explosion":
                targetPool = explosion;
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
            case "Boss1":
                targetPool = boss1;
                break;
            case "Boss2":
                targetPool = boss2;
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
            case "EnemyLL":
                targetPool = enemyLL;
                break;
            case "EnemyMM":
                targetPool = enemyMM;
                break;
            case "EnemySS":
                targetPool = enemySS;
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
            case "BulletEnemyC":
                targetPool = bulletEnemyC;
                break;
            case "BulletEnemyD":
                targetPool = bulletEnemyD;
                break;
            case "BulletEnemyE":
                targetPool = bulletEnemyE;
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
            case "BulletBossD":
                targetPool = bulletBossD;
                break;
            case "BulletBossE":
                targetPool = bulletBossE;
                break;
            case "BulletBossF":
                targetPool = bulletBossF;
                break;
            case "Explosion":
                targetPool = explosion;
                break;
        }
        return targetPool;
    }
    public void DeleteAllObj(string type)
    {
        if (type == "Boss1" || type == "Boss2")
        {
            for (int index = 0; index < bulletBossA.Length; index++)
                bulletBossA[index].SetActive(false);

            for (int index = 0; index < bulletBossB.Length; index++)
                bulletBossA[index].SetActive(false);
        }
    }
}

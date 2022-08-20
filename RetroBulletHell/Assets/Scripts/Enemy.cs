using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public int enemyScore;
    public float speed;
    [SerializeField]
    private int health;
    public Sprite[] sprites;

    [SerializeField]
    private float maxShotDelay;
    [SerializeField]
    private float curShotDelay;

    public GameObject bulletObjA;
    public GameObject bulletObjB;
    public GameObject bulletObjC;
    public GameObject bulletObjD;
    public GameObject bulletObjE;
    public GameObject itemScore;
    public GameObject itemPower;
    public GameObject itemBoom;
    public GameObject player;
    public GameManager gameManager;
    public ObjectManager objectManager;


    public int patternIndex;
    public int curPatternCount;
    public int[] maxPatternCount;

   

    void Awake()
    {
        
    }

    void OnEnable()
    {
        switch (enemyName)
        {
            case "Boss1":
                health = 1000;
                Invoke("StopBoss1",2);
                break;
            case "Boss2":
                health = 1000;
                Invoke("StopBoss2", 2f);
                break;
            case "L":
                health = 8;
                break;
            case "M":
                health = 4;
                break;
            case "S":
                health = 2;
                break;
            case "LL":
                health = 14;
                break;
            case "MM":
                health = 9;
                break;
            case "SS":
                health = 5;
                break;
        }
    }

    void StopBoss1()
    {
        if (!gameObject.activeSelf)
            return;

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.zero;

        Invoke("Boss1_Think", 2);

    }

    void StopBoss2()
    {
        if (!gameObject.activeSelf)
            return;

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.zero;

        Invoke("Boss2_Think", 2);

    }

    void Boss1_Think()
    {
        if (health > 500)
            patternIndex = Random.Range(0, 3);
        else
            patternIndex = Random.Range(0, 4);
        curPatternCount = 0;

        switch (patternIndex)
        {
            case 0:
                Boss1_FireFoward();
                break;
            case 1:
                Boss1_FireShot();
                break;
            case 2:
                Boss1_FireArc();
                break;
            case 3:
                Boss1_FireAround();
                break;
        }
    }

    void Boss2_Think()
    {
        if(health >500)
            patternIndex = Random.Range(0, 3);
        else
            patternIndex = Random.Range(0, 4);
        curPatternCount = 0;

        switch (patternIndex)
        {
            case 0:
                Boss2_FireFoward();
                break;
            case 1:
                Boss2_FireShot();
                break;
            case 2:
                Boss2_FireLaser();
                break;
            case 3:
                Boss2_FireSpin();
                break;
        }
    }

    //Stage 1 Boss Pattern
    void Boss1_FireFoward()
    {
        if (health <= 0)
            return;
        //전방 발사
        GameObject bossBulletL = objectManager.MakeObj("BulletBossB");
        bossBulletL.transform.position = transform.position + Vector3.left * 2.3f;
        GameObject bossBulletLL = objectManager.MakeObj("BulletBossB");
        bossBulletLL.transform.position = transform.position + Vector3.left * 2.9f;
        GameObject bossBulletR = objectManager.MakeObj("BulletBossB");
        bossBulletR.transform.position = transform.position + Vector3.right * 2.3f;
        GameObject bossBulletRR = objectManager.MakeObj("BulletBossB");
        bossBulletRR.transform.position = transform.position + Vector3.right * 2.9f;

        Rigidbody2D rigidL = bossBulletL.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidLL = bossBulletLL.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidR = bossBulletR.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidRR = bossBulletRR.GetComponent<Rigidbody2D>();

        Vector3 dirVecL = player.transform.position - (transform.position + Vector3.left * 2.3f);
        Vector3 dirVecLL = player.transform.position - (transform.position + Vector3.left * 2.9f);
        Vector3 dirVecR = player.transform.position - (transform.position + Vector3.right * 2.3f);
        Vector3 dirVecRR = player.transform.position - (transform.position + Vector3.right * 2.9f);

        rigidL.AddForce(dirVecL.normalized * 7, ForceMode2D.Impulse);
        rigidLL.AddForce(dirVecLL.normalized * 7, ForceMode2D.Impulse);
        rigidR.AddForce(dirVecR.normalized * 7, ForceMode2D.Impulse);
        rigidRR.AddForce(dirVecRR.normalized * 7, ForceMode2D.Impulse);

        curPatternCount++;

        if(curPatternCount < maxPatternCount[patternIndex])
            Invoke("Boss1_FireFoward", 0.5f);
        else
            Invoke("Boss1_Think", 0.5f);
    }

    void Boss1_FireShot()
    {
        if (health <= 0)
            return;
        for (int indeex = 0; indeex < 9; indeex++)
        {
            GameObject bulletR = objectManager.MakeObj("BulletEnemyB");
            bulletR.transform.position = transform.position + Vector3.left * 2.3f + Vector3.down * 1.0f;
            Rigidbody2D rigidBR = bulletR.GetComponent<Rigidbody2D>();
            Vector2 dirVec = player.transform.position - transform.position;
            Vector2 ranVec = new Vector2(Random.Range(-0.9f, 4.0f), 0);
            dirVec += ranVec;
            rigidBR.AddForce(dirVec.normalized * 4, ForceMode2D.Impulse);
        }
        StartCoroutine(WaitForIt());
        for (int indeex = 0; indeex < 9; indeex++)
        {
            GameObject bulletL = objectManager.MakeObj("BulletEnemyB");
            bulletL.transform.position = transform.position + Vector3.right * 2.3f + Vector3.down * 1.0f;
            Rigidbody2D rigidBL = bulletL.GetComponent<Rigidbody2D>();
            Vector2 dirVec = player.transform.position - transform.position;
            Vector2 ranVec = new Vector2(Random.Range(-4.0f, 0.9f),0);
            dirVec += ranVec;
            rigidBL.AddForce(dirVec.normalized * 4, ForceMode2D.Impulse);
        }
        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("Boss1_FireShot", 1f);
        else
            Invoke("Boss1_Think", 0.5f);
    }

    void Boss1_FireArc()
    {
        if (health <= 0)
            return;
        GameObject bullet = objectManager.MakeObj("BulletBossC");
        bullet.transform.position = transform.position;
        bullet.transform.rotation = Quaternion.identity;

        Rigidbody2D rigidB = bullet.GetComponent<Rigidbody2D>();
        Vector2 dirVec = new Vector2(Mathf.Sin(Mathf.PI * 10 * curPatternCount/maxPatternCount[patternIndex]), -1);
        rigidB.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);
        

        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("Boss1_FireArc", 0.05f);
        else
            Invoke("Boss1_Think", 0.5f);
    }

    void Boss1_FireAround()
    {
        if (health <= 0)
            return;
        int roundNumA = 50;
        int roundNumB = 45;
        int roundNum = curPatternCount % 2 == 0 ? roundNumA : roundNumB;
        for(int index = 0; index < roundNum; index++)
        {
            GameObject bullet = objectManager.MakeObj("BulletEnemyB");
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.identity;

            Rigidbody2D rigidB = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = new Vector2(Mathf.Sin(Mathf.PI * 2 * index / roundNum)
                                        ,Mathf.Cos(Mathf.PI * 2 * index / roundNum));
            rigidB.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);

            Vector3 rotVec = Vector3.forward * 360 * index / roundNum + Vector3.forward * 90;
            bullet.transform.Rotate(rotVec);
        }
        

        curPatternCount++;

        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("Boss1_FireAround", 0.7f);
        else
            Invoke("Boss1_Think", 2);
    }



    //Stage 2 Boss Pattern

    void Boss2_FireFoward()
    {
        if (health <= 0)
            return;
        //전방 발사

        for (int i = 0; i < 4; i++)
        {
            GameObject bossBulletL = objectManager.MakeObj("BulletBossE");
            bossBulletL.transform.position = transform.position + Vector3.left * 1.9f + Vector3.down * 1.9f;
            Rigidbody2D rigidL = bossBulletL.GetComponent<Rigidbody2D>();
            Vector3 dirVec = player.transform.position - (transform.position + Vector3.left * 1.9f);
            rigidL.AddForce(dirVec.normalized * 6, ForceMode2D.Impulse);
            float angle = Mathf.Atan2(dirVec.y, dirVec.x) * Mathf.Rad2Deg;
            bossBulletL.transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            StartCoroutine(WaitForIt());
        }

        curPatternCount++;

        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("Boss2_FireFoward", 0.7f);
        else
            Invoke("Boss2_Think", 0.5f);
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(0.2f);
    }

    void Boss2_FireShot()
    {
        if (health <= 0)
            return;
      
        for (int index = 0; index < 10; index++)
        {
            GameObject bulletL = objectManager.MakeObj("BulletEnemyB");
            bulletL.transform.position = transform.position + Vector3.right * 1.8f + Vector3.down * 1.5f;
            Rigidbody2D rigidBL = bulletL.GetComponent<Rigidbody2D>();
            Vector2 dirVec = player.transform.position - transform.position;
            Vector2 ranVec = new Vector2(Random.Range(-4f, 1f), 0);
            dirVec += ranVec;
            rigidBL.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);
            Vector3 dirVecE = player.transform.position - transform.position;
            rigidBL.AddForce(dirVecE.normalized * 1, ForceMode2D.Impulse);
        }
        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("Boss2_FireShot", 0.7f);
        else
            Invoke("Boss2_Think", 0.7f);
    }

    void Boss2_FireLaser()
    {
        if (health <= 0)
            return;
        GameObject bossBullet = objectManager.MakeObj("BulletBossF");
        bossBullet.transform.position = transform.position;
        Rigidbody2D rigid = bossBullet.GetComponent<Rigidbody2D>();
        Vector3 dirVec = player.transform.position - transform.position + Vector3.down * 0.1f;

        rigid.AddForce(dirVec.normalized * 9, ForceMode2D.Impulse);

        float angle = Mathf.Atan2(dirVec.y, dirVec.x) * Mathf.Rad2Deg;
        bossBullet.transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);

        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("Boss2_FireLaser", 0.5f);
        else
            Invoke("Boss2_Think", 0.5f);
    }

    void Boss2_FireSpin()
    {
        if (health <= 0)
            return;
        int roundNum = 71;
        GameObject bullet = objectManager.MakeObj("BulletBossD");
        bullet.transform.position = transform.position;
        bullet.transform.rotation = Quaternion.identity;

        Rigidbody2D rigidB = bullet.GetComponent<Rigidbody2D>();
        Vector2 dirVec = new Vector2(Mathf.Sin(Mathf.PI * 2 * curPatternCount / roundNum),
                                     Mathf.Cos(Mathf.PI * 2 * curPatternCount / roundNum));
        rigidB.AddForce(dirVec.normalized * 7, ForceMode2D.Impulse);

        curPatternCount++;

        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("Boss2_FireSpin", 0.025f);
        else
            Invoke("Boss2_Think", 1);
    }


    


    void Update()
    {
        if (enemyName == "Boss1" || enemyName == "Boss2")
            return;
        Fire();
        Reload();
    }

    void Fire()
    {
        if (curShotDelay < maxShotDelay)
            return;

        if(enemyName == "S")
        {
            GameObject bulletAL = objectManager.MakeObj("BulletEnemyA");
            bulletAL.transform.position = transform.position + Vector3.left * 0.3f;
            GameObject bulletAR = objectManager.MakeObj("BulletEnemyA");
            bulletAR.transform.position = transform.position + Vector3.right * 0.3f;

            Rigidbody2D rigidAL = bulletAL.GetComponent<Rigidbody2D>();
            Rigidbody2D rigidAR = bulletAR.GetComponent<Rigidbody2D>();

            Vector3 dirVecL = player.transform.position - (transform.position + Vector3.right * 0.3f);
            Vector3 dirVecR = player.transform.position - (transform.position + Vector3.left * 0.3f);

            rigidAL.AddForce(dirVecL.normalized * 2, ForceMode2D.Impulse);
            rigidAR.AddForce(dirVecR.normalized * 2, ForceMode2D.Impulse);
        }
        else if(enemyName == "L")
        {
            GameObject bulletB = objectManager.MakeObj("BulletEnemyB");
            bulletB.transform.position = transform.position;
            Rigidbody2D rigidB = bulletB.GetComponent<Rigidbody2D>();
            Vector3 dirVec = player.transform.position - transform.position;
            rigidB.AddForce(dirVec.normalized * 4, ForceMode2D.Impulse);
        }
        else if (enemyName == "SS")
        {
            GameObject bulletAL = objectManager.MakeObj("BulletEnemyC");
            bulletAL.transform.position = transform.position + Vector3.left * 0.2f;
            
            GameObject bulletAR = objectManager.MakeObj("BulletEnemyC");
            bulletAR.transform.position = transform.position + Vector3.right * 0.2f;
          
            Rigidbody2D rigidAL = bulletAL.GetComponent<Rigidbody2D>();
            Rigidbody2D rigidAR = bulletAR.GetComponent<Rigidbody2D>();
            

            Vector3 dirVecL = player.transform.position - (transform.position + Vector3.right * 0.3f);
            Vector3 dirVecR = player.transform.position - (transform.position + Vector3.left * 0.3f);

            float angleL = Mathf.Atan2(dirVecL.y, dirVecL.x) * Mathf.Rad2Deg;
            bulletAL.transform.rotation = Quaternion.AngleAxis(angleL + 90, Vector3.forward);
            float angleR = Mathf.Atan2(dirVecR.y, dirVecR.x) * Mathf.Rad2Deg;
            bulletAR.transform.rotation = Quaternion.AngleAxis(angleR + 90, Vector3.forward);

            rigidAL.AddForce(dirVecL.normalized * 3, ForceMode2D.Impulse);
            rigidAR.AddForce(dirVecR.normalized * 3, ForceMode2D.Impulse);
        }
        else if (enemyName == "MM")
        {
            GameObject bulletAL = objectManager.MakeObj("BulletEnemyA");
            bulletAL.transform.position = transform.position + Vector3.left * 0.2f;
            GameObject bulletA = objectManager.MakeObj("BulletEnemyD");
            bulletA.transform.position = transform.position;
            GameObject bulletAR = objectManager.MakeObj("BulletEnemyA");
            bulletAR.transform.position = transform.position + Vector3.right * 0.2f;

            Rigidbody2D rigidAL = bulletAL.GetComponent<Rigidbody2D>();
            Rigidbody2D rigidA = bulletA.GetComponent<Rigidbody2D>();
            Rigidbody2D rigidAR = bulletAR.GetComponent<Rigidbody2D>();


            Vector3 dirVecL = player.transform.position - (transform.position + Vector3.right * 0.3f);
            Vector3 dirVec = player.transform.position - transform.position;
            Vector3 dirVecR = player.transform.position - (transform.position + Vector3.left * 0.3f);

            rigidAL.AddForce(dirVecL.normalized * 3, ForceMode2D.Impulse);
            rigidA.AddForce(Vector3.down * 5, ForceMode2D.Impulse);
            rigidAR.AddForce(dirVecR.normalized * 3, ForceMode2D.Impulse);
        }
        else if (enemyName == "LL")
        {
            GameObject bulletAL = objectManager.MakeObj("BulletEnemyE");
            bulletAL.transform.position = transform.position + Vector3.left * 0.2f;

            GameObject bulletAR = objectManager.MakeObj("BulletEnemyE");
            bulletAR.transform.position = transform.position + Vector3.right * 0.2f;

            Rigidbody2D rigidAL = bulletAL.GetComponent<Rigidbody2D>();
            Rigidbody2D rigidAR = bulletAR.GetComponent<Rigidbody2D>();


            Vector3 dirVecL = player.transform.position - (transform.position + Vector3.right * 0.3f);
            Vector3 dirVecR = player.transform.position - (transform.position + Vector3.left * 0.3f);

            float angleL = Mathf.Atan2(dirVecL.y, dirVecL.x) * Mathf.Rad2Deg;
            bulletAL.transform.rotation = Quaternion.AngleAxis(angleL + 90, Vector3.forward);
            float angleR = Mathf.Atan2(dirVecR.y, dirVecR.x) * Mathf.Rad2Deg;
            bulletAR.transform.rotation = Quaternion.AngleAxis(angleR + 90, Vector3.forward);

            rigidAL.AddForce(dirVecL.normalized * 3, ForceMode2D.Impulse);
            rigidAR.AddForce(dirVecR.normalized * 3, ForceMode2D.Impulse);
        }

        curShotDelay = 0;
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }

    public void Onhit(int dmg)
    {

        if (health <= 0)
        {
            return;
        }

        health -= dmg;

        if(health <= 0)
        {
            PlayerMove playerLogic = player.GetComponent<PlayerMove>();
            playerLogic.score += enemyScore;

            //Random Item Drop
            int ran = (enemyName == "Boss1" || enemyName == "Boss2") ? 0 : Random.Range(0, 100);
            
            if (ran < 70)
            {

            }
            else if (ran < 90)
            {
                GameObject itemScore = objectManager.MakeObj("ItemScore");
                itemScore.transform.position = transform.position;
            }
            else if (ran < 98)
            {
                GameObject itemPower = objectManager.MakeObj("ItemPower");
                itemPower.transform.position = transform.position;
            }
            else if (ran < 100)
            {
                GameObject itemBoom = objectManager.MakeObj("ItemBoom");
                itemBoom.transform.position = transform.position;
            }
            objectManager.DeleteAllObj("Boss1");
            objectManager.DeleteAllObj("Boss2");

            gameObject.SetActive(false);
            transform.rotation = Quaternion.identity;
            gameManager.CallExplosion(transform.position, enemyName);
            

            //Boss Kill
            if (enemyName == "Boss1" || enemyName == "Boss2")
                gameManager.StageEnd();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderBullet" && enemyName != "Boss1" && enemyName != "Boss2")
        {
            gameObject.SetActive(false);
            transform.rotation = Quaternion.identity;
        }
        else if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            Onhit(bullet.dmg);
            collision.gameObject.SetActive(false);
        }
    }
}

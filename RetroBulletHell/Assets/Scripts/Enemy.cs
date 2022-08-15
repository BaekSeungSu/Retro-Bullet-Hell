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
    public GameObject itemScore;
    public GameObject itemPower;
    public GameObject itemBoom;
    public GameObject player;
    public ObjectManager objectManager;

    SpriteRenderer spriteRenderer;

    public int patternIndex;
    public int curPatternCount;
    public int[] maxPatternCount;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        switch (enemyName)
        {
            case "Boss":
                health = 1000;
                Invoke("Stop",2);
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
        }
    }

    void Stop()
    {
        if (!gameObject.activeSelf)
            return;

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.zero;

        Invoke("Think", 2);

    }

    void Think()
    {
        patternIndex = patternIndex == 3 ? 0 : patternIndex + 1;
        curPatternCount = 0;

        switch (patternIndex)
        {
            case 0:
                FireFoward();
                break;
            case 1:
                FireShot();
                break;
            case 2:
                FireArc();
                break;
            case 3:
                FireAround();
                break;
        }
    }

    void FireFoward()
    {
        curPatternCount++;

        if(curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireFoward", 2);
        else
            Invoke("Think", 3);
    }

    void FireShot()
    {
        curPatternCount++;

        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireShot", 3.5f);
        else
            Invoke("Think", 3);
    }

    void FireArc()
    {
        curPatternCount++;

        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireArc", 0.15f);
        else
            Invoke("Think", 3);
    }

    void FireAround()
    {
        curPatternCount++;

        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireAround", 0.7f);
        else
            Invoke("Think", 3);
    }

    void Update()
    {
        if (enemyName == "Boss")
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

            rigidAL.AddForce(dirVecL.normalized * 3, ForceMode2D.Impulse);
            rigidAR.AddForce(dirVecR.normalized * 3, ForceMode2D.Impulse);
        }
        else if(enemyName == "L")
        {
            GameObject bulletB = objectManager.MakeObj("BulletEnemyB");
            bulletB.transform.position = transform.position;
            Rigidbody2D rigidB = bulletB.GetComponent<Rigidbody2D>();
            Vector3 dirVec = player.transform.position - transform.position;
            rigidB.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);
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
            return;

        health -= dmg;

        if(health <= 0)
        {
            PlayerMove playerLogic = player.GetComponent<PlayerMove>();
            playerLogic.score += enemyScore;

            //Random Item Drop
            int ran = enemyName == "Boss" ? 0 : Random.Range(0, 10);
            if (ran < 6)
            {

            }
            else if (ran < 8) //20%
            {
                GameObject itemScore = objectManager.MakeObj("ItemScore");
                itemScore.transform.position = transform.position;
            }
            else if (ran < 9) //10%
            {
                GameObject itemPower = objectManager.MakeObj("ItemPower");
                itemPower.transform.position = transform.position;
            }
            else if (ran < 9.1) //1%
            {
                GameObject itemBoom = objectManager.MakeObj("ItemBoom");
                itemBoom.transform.position = transform.position;
            }
            gameObject.SetActive(false);
            transform.rotation = Quaternion.identity;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderBullet" && enemyName != "Boss")
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

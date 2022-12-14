using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public int stage;
    public Animator stageAnim;
    public Animator clearAnim;
    public Animator fadeAnim;
    public Transform playerPos;

    public string[] enemyObjs;
    public Transform[] spawnPoints;

    public float nextSpawnDelay;
    public float curSpawnDelay;

    public GameObject player;
    public Text scoreText;
    public Image[] lifeImage ;
    public Image[] boomImage;
    public GameObject gameOverSet;
    public ObjectManager objectManager;

    public List<Spawn> spawnList;
    public int spawnIndex;
    public bool spawnEnd;


    void Awake()
    {
        spawnList = new List<Spawn>();
        enemyObjs = new string[] { "EnemyS", "EnemyM", "EnemyL", "EnemySS", "EnemyMM", "EnemyLL", "Boss1", "Boss2" };
        StageStart();
    }


    public void StageStart()
    {
        //Stage UI Load
        stageAnim.SetTrigger("On");
        stageAnim.GetComponent<Text>().text = "STAGE " + stage + "\nStart";
        clearAnim.GetComponent<Text>().text = "STAGE " + stage + "\nClear";
        //Enemy Spawn File Read
        ReadSpawnFile();

        //Fade In
        fadeAnim.SetTrigger("In");
    }

    public void StageEnd()
    {
        //Clear UI Load
        clearAnim.SetTrigger("On");

        //Fade Out
        fadeAnim.SetTrigger("Out");

        //Player Position Reset
        player.transform.position = playerPos.position;

        //Stage Increment
        stage++;

        if (stage == 3)
        {
            
            PlayerMove playerLogic = player.GetComponent<PlayerMove>();
            PlayerPrefs.SetInt("Score", playerLogic.score);
            Invoke("ClearScene", 3);
        }
        else
        {
            Invoke("NextScene",4);
            Invoke("StageStart", 5);
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Stage " + stage);
    }

    public void ClearScene()
    {
        SceneManager.LoadScene("GameClear");
    }


    void ReadSpawnFile()
    {
        //???? ??????
        spawnList.Clear();
        spawnIndex = 0;
        spawnEnd = false;

        //?????? ???? ????
        TextAsset textFile = Resources.Load("Stage " + stage) as TextAsset;
        StringReader stringReader = new StringReader(textFile.text);

        while(stringReader != null)
        {
            string line = stringReader.ReadLine();
            if (line == null)
                break;

            //?????? ?????? ????
            Spawn spawnData = new Spawn();
            spawnData.delay = float.Parse(line.Split(',')[0]);
            spawnData.type = line.Split(',')[1];
            spawnData.point = int.Parse(line.Split(',')[2]);
            spawnList.Add(spawnData);
        }

        //?????? ???? ????
        stringReader.Close();

        //?????? ???? ?????? ????
        nextSpawnDelay = spawnList[0].delay;

       
    }

    void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if(curSpawnDelay > nextSpawnDelay && !spawnEnd)
        {
            SpawnEnemy(); 
            curSpawnDelay = 0;
        }

        //UI Score Update
        PlayerMove playerLogic = player.GetComponent<PlayerMove>();
        scoreText.text = string.Format("{0:n0}", playerLogic.score);

    }

   

    void SpawnEnemy()
    {
        int enemyIndex = 0;
        switch (spawnList[spawnIndex].type)
        {
            case "S":
                enemyIndex = 0;
                break;
            case "M":
                enemyIndex = 1;
                break;
            case "L":
                enemyIndex = 2;
                break;
            case "SS":
                enemyIndex = 3;
                break;
            case "MM":
                enemyIndex = 4;
                break;
            case "LL":
                enemyIndex = 5;
                break;
            case "Boss1":
                enemyIndex = 6;
                break;
            case "Boss2":
                enemyIndex = 7;
                break;
        }
        int enemyPoint = spawnList[spawnIndex].point;
        GameObject enemy = objectManager.MakeObj(enemyObjs[enemyIndex]);
        enemy.transform.position = spawnPoints[enemyPoint].position;

        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        Enemy enemyLogic = enemy.GetComponent<Enemy>();
        enemyLogic.player = player;
        enemyLogic.gameManager = this;
        enemyLogic.objectManager = objectManager;

        if (enemyPoint == 5 || enemyPoint == 6) //Right Spawns
        {
            if (enemyIndex == 1 || enemyIndex == 2)
                enemy.transform.Rotate(Vector3.forward * 135);
            else
                enemy.transform.Rotate(Vector3.back * 45);
            rigid.velocity = new Vector2(enemyLogic.speed * (-1), -1);
        }
        else if (enemyPoint == 7 || enemyPoint == 8) //Left Spawn
        {
            if (enemyIndex == 1 || enemyIndex == 2)
                enemy.transform.Rotate(Vector3.forward * 225);
            else
                enemy.transform.Rotate(Vector3.forward * 45);
            rigid.velocity = new Vector2(enemyLogic.speed, -1);
        }
        else // Front Spawn
        {
            if(enemyIndex == 1 || enemyIndex == 2)
                enemy.transform.Rotate(Vector3.forward * 180);
            else
                enemy.transform.Rotate(Vector3.forward);
            rigid.velocity = new Vector2(0, enemyLogic.speed * (-1));
        }

        //?????? ?????? ????
        spawnIndex++;
        if(spawnIndex == spawnList.Count)
        {
            spawnEnd = true;
            return;
        }

        //???? ?????? ?????? ????
        nextSpawnDelay = spawnList[spawnIndex].delay;
    }

    public void UpdateLifeIcon(int life)
    {
        //UI Life Init Disable
        for (int index = 0; index < 3; index++)
        {
            lifeImage[index].color = new Color(1, 1, 1, 0);
        }

        //UI Life Actvie
        for (int index = 0; index < life; index++)
        {
            lifeImage[index].color = new Color(1, 1, 1, 1);
        }
    }

    public void UpdateBoomIcon(int boom)
    {
        //UI Life Init Disable
        for (int index = 0; index < 2; index++)
        {
            boomImage[index].color = new Color(1, 1, 1, 0);
        }

        //UI Life Actvie
        for (int index = 0; index < boom; index++)
        {
            boomImage[index].color = new Color(1, 1, 1, 1);
        }
    }

    public void RespawnPlayer()
    {
        Invoke("RespawnPlayerExe", 2f);
    }

    void RespawnPlayerExe()
    {
        player.transform.position = Vector3.down * 3.5f;
        player.SetActive(true);
        PlayerMove playerLogic = player.GetComponent<PlayerMove>();
        playerLogic.isHit = false;
    }

    public void CallExplosion(Vector3 pos, string type)
    {
        GameObject explosion = objectManager.MakeObj("Explosion");
        Explosion explosionLogic = explosion.GetComponent<Explosion>();

        explosion.transform.position = pos;
        explosionLogic.startExplosion(type);
    }

    public void GameOver()
    {
        gameOverSet.SetActive(true);
    }

    public void GameRetry()
    {
        SceneManager.LoadScene("Stage " + stage);
    }
}

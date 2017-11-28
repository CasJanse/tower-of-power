using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseController : MonoBehaviour {

    public bool fightingPhase;
    public bool upgradePhase;
    public GameObject enemies;
    public bool upgradePickedUp;
    public bool spawning;
    public int amountOfEnemiesToSpawn;
    public int enemiesSpawned;
    public GameObject spawnPoints;
    private Transform[] spawnPointsList;
    public GameObject goblin;
    private GameObject enemyInstance;
    private Random rnd;
    private int index;
    private int randomNr;
    public Canvas canvas;
    public GameObject player;
    public GameObject panel;
    public Text roundText;
    public int roundCounter;
    private int difficultyScore;
    private int currentScoreSpawned;
    private int difficultyScoreLeft;
    public GameObject goblinEnemy, goblinSpearEnemy, orcEnemy;
    private GameObject enemyToSpawn;
    public GameObject[] upgradeList;
    public GameObject upgrades;
    public GameObject upgradeSpawnPoints;
    private Transform[] upgradeSpawnPointsList;
    public bool upgradesPlaced;
    public GameObject[] upgradeText;
    private bool orcSpawned;
    public Canvas gameOverCanvas;
    public Canvas winCanvas;
    public bool winScreen;
    private bool won;
    public Canvas introCanvas;
    private bool intro;

    // Use this for initialization
    void Start () {
        roundCounter = 0;
        spawnPointsList = new Transform[4];
        upgradeSpawnPointsList = new Transform[3];
        index = 0;
        upgradePhase = false;
        fightingPhase = true;
        amountOfEnemiesToSpawn = 2;
        rnd = new Random();
        difficultyScore = 10;
        intro = true;

        foreach (Transform spawnPoint in spawnPoints.GetComponentInChildren<Transform>())
        {
            spawnPointsList[index] = spawnPoint;
            index++;
        }

        //foreach (Transform upgrade in upgrades.GetComponentInChildren<Transform>())
        //{
        //    upgradeList[index] = upgrade;
        //    index++;
        //}
        index = 0;
        foreach (Transform spawnPoint in upgradeSpawnPoints.GetComponentInChildren<Transform>())
        {
            upgradeSpawnPointsList[index] = spawnPoint;
            index++;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (fightingPhase && enemies.transform.childCount <= 0)
        {
            fightingPhase = false;
            roundCounter++;
            upgradePhase = true;
        }

        if (roundCounter == 20 && !won)
        {
            won = true;
            upgradePhase = false;
            winCanvas.gameObject.SetActive(true);
            winScreen = true;
        }

        if (upgradePhase && upgradePickedUp)
        {
            upgradePhase = false;
            fightingPhase = true;
            upgradePickedUp = false;
            spawning = true;
            upgradesPlaced = false;
            amountOfEnemiesToSpawn++;
            //panel.SetActive(false);
            
            difficultyScore += 10;
            currentScoreSpawned = 0;
            upgradeSpawnPointsList[0].Find("Canvas").gameObject.SetActive(false);
            upgradeSpawnPointsList[1].Find("Canvas").gameObject.SetActive(false);
            upgradeSpawnPointsList[2].Find("Canvas").gameObject.SetActive(false);
        }

        //Controls the starting phase.
        if (intro)
        {
            upgradePhase = false;
            fightingPhase = false;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                intro = false;
                introCanvas.gameObject.SetActive(false);
                spawning = true;
                fightingPhase = true;
            }
            
        }

        //Checks and determines what upgrades can and should be spawned in the current upgrade phase. 
        if (upgradePhase && !upgradesPlaced)
        {
            GameObject upgrade1 = Instantiate(upgradeList[(int)Random.Range(0,4.999f)].gameObject, transform);
            while (upgrade1.GetComponent<Description>().description == "HP +1" && player.GetComponent<Stats>().HP == 5)
            {
                Destroy(upgrade1);
                upgrade1 = Instantiate(upgradeList[(int)Random.Range(0, 4.999f)].gameObject, transform);
            }
            upgrade1.transform.Translate(upgradeSpawnPointsList[0].transform.position);
            upgradeText[0].GetComponent<Text>().text = upgrade1.GetComponent<Description>().description;
            upgradeSpawnPointsList[0].Find("Canvas").gameObject.SetActive(true);
            upgrade1.transform.SetParent(null);

            GameObject upgrade2 = Instantiate(upgradeList[(int)Random.Range(0, 4.999f)].gameObject, transform);
            while (upgrade2.GetComponent<Description>().description == "HP +1" && player.GetComponent<Stats>().HP == 5)
            {
                Destroy(upgrade2);
                upgrade2 = Instantiate(upgradeList[(int)Random.Range(0, 4.999f)].gameObject, transform);
            }
            upgrade2.transform.Translate(upgradeSpawnPointsList[1].transform.position);
            upgradeText[1].GetComponent<Text>().text = upgrade2.GetComponent<Description>().description;
            upgradeSpawnPointsList[1].Find("Canvas").gameObject.SetActive(true);
            upgradeText[1].SetActive(true);
            upgrade2.transform.SetParent(null);

            GameObject upgrade3 = Instantiate(upgradeList[(int)Random.Range(0, 4.999f)].gameObject, transform);
            while (upgrade3.GetComponent<Description>().description == "HP +1" && player.GetComponent<Stats>().HP == 5)
            {
                Destroy(upgrade3);
                upgrade3 = Instantiate(upgradeList[(int)Random.Range(0, 4.999f)].gameObject, transform);
            }
            upgrade3.transform.Translate(upgradeSpawnPointsList[2].transform.position);
            upgradeText[2].GetComponent<Text>().text = upgrade3.GetComponent<Description>().description;
            upgradeSpawnPointsList[2].Find("Canvas").gameObject.SetActive(true);
            upgradeText[2].SetActive(true);
            upgrade3.transform.SetParent(null);
            upgradesPlaced = true;
        }

        roundText.text = "Round: " + roundCounter;

        if (spawning)
        {
            while (currentScoreSpawned < difficultyScore)
            {
                
                Debug.Log(roundCounter);
                if (roundCounter <= 2)
                {
                    enemyToSpawn = goblinEnemy;
                    
                }
                else if (roundCounter == 3)
                {
                    enemyToSpawn = goblinSpearEnemy;
                    currentScoreSpawned = difficultyScore;
                }
                else if (roundCounter < 6)
                {
                    int randomNumber = (int)Random.Range(0, 1.999f);
                    Debug.Log(randomNumber);
                    if (randomNumber == 0)
                    {
                        enemyToSpawn = goblinEnemy;
                    }
                    else if (randomNumber == 1)
                    {
                        enemyToSpawn = goblinSpearEnemy;
                    }
                }
                else if (roundCounter == 6)
                {
                    if (orcSpawned)
                    {
                        enemyToSpawn = goblinEnemy;
                    }
                    else
                    {
                        enemyToSpawn = orcEnemy;
                        orcSpawned = true;
                    }
                }
                else if (roundCounter > 6)
                {
                    int randomNumber = (int)Random.Range(0, 2.999f);
                    Debug.Log(randomNumber);
                    if (randomNumber == 0)
                    {
                        enemyToSpawn = goblinEnemy;
                    }
                    else if (randomNumber == 1)
                    {
                        enemyToSpawn = goblinSpearEnemy;
                    }
                    else if (randomNumber == 2)
                    {
                        enemyToSpawn = orcEnemy;
                    }
                }
                currentScoreSpawned += enemyToSpawn.GetComponent<Stats>().difficultyScore;
                enemyInstance = Instantiate(enemyToSpawn, transform);
                enemyInstance.transform.SetParent(enemies.transform);
                randomNr = (int)Random.Range(0,3.999f);
                enemyInstance.transform.Translate(spawnPointsList[randomNr].position);
                enemyInstance.GetComponent<EnemyChasing>().player = enemies.GetComponent<EnemyController>().player;
                enemyInstance.GetComponent<EnemyController>().player = enemies.GetComponent<EnemyController>().player;
                enemiesSpawned++;
            }
            spawning = false;
            enemiesSpawned = 0;
        }

        

        if (player.GetComponent<Stats>().HP <= 0)
        {
            gameOverCanvas.gameObject.SetActive(true);
        }

        if (winScreen)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                upgradePhase = true;
                winScreen = false;
                winCanvas.gameObject.SetActive(false);
            }
        }
	}
}

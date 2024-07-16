using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityUtils;


public class EnemySpawner : MonoBehaviour
{

    [SerializeField, Range(0, 40)] private float minRadius, maxRadius;
    [SerializeField, Range(0, 80)] public int nrEnemy;
    [SerializeField, Range(0, 80)] private int preLoadedEnemies;

    private List<EnemyGroup> enemyTypes = new List<EnemyGroup>();

    private GameObject enemyList;
    private GameObject player;


    //Load a predetermined number of enemies
    void preLoadEnemies()
    {
        for (int i = 0; i < preLoadedEnemies; i++)
        {
            foreach (EnemyGroup enemyType in enemyTypes)
            {
                GameObject enemy = Instantiate(enemyType.enemyPrefab);
                enemy.name = enemyType.name;                            //Set name of the spawned enemy the same as the prefabs
                enemy.transform.parent = enemyList.transform;           //Add enemy to {enemyList}
                enemy.AddComponent<EnemyBehaviour>();                   //Add enemy Behaviour
                enemy.gameObject.GetComponent<EnemyBehaviour>().setEnemyID(enemyType.enemyID);      //Set ID to enemy
                enemy.SetActive(false);                                 //Disable enemy
            }
        }
    }

    public void spawnEnemy(int amount, int enemyID)
    {
        int enemySpawned = 0;
        foreach (Transform enemyTransform in enemyList.transform)
        {
            //Don't spawn more than {amount} of enemies
            if (enemySpawned >= amount)
            {
                return;
            }

            if (enemyID != enemyTransform.gameObject.GetComponent<EnemyBehaviour>().getEnemyID()){
                continue;
            }            

            //Spawn only disabled enemies
            GameObject enemy = enemyTransform.gameObject;
            if (enemy.activeSelf)
            {
                continue;
            }

            //Get and set spawning location around the player
            Vector3 spawnPos = player.transform.position.RandomPointInAnnulus(minRadius, maxRadius);
            enemy.transform.position = spawnPos;

            //Assign enemyStats based on enemyType
            EnemyBehaviour enemyStats = enemyTransform.GetComponent<EnemyBehaviour>();
            enemyStats.setEnemyHP(enemyTypes[enemyID].enemyHP);
            enemyStats.setEnemySpeed(enemyTypes[enemyID].enemySpeed);               

            enemy.SetActive(true);
            enemySpawned++;

        }
    }

    void GetEnemiesFromFolder()
    {
        string[] enemyGroup = AssetDatabase.FindAssets("", new[] { "Assets/Enemies" });
        enemyTypes.Clear();

        foreach (string SOName in enemyGroup)
        {
            var SOpath = AssetDatabase.GUIDToAssetPath(SOName);
            var enemy = AssetDatabase.LoadAssetAtPath<EnemyGroup>(SOpath);
            enemyTypes.Add(enemy);
        }

    }

    void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyList = GameObject.Find("Enemy List");

        GetEnemiesFromFolder();
        preLoadEnemies();        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, minRadius);

        Gizmos.color = Color.red;
        Vector3 pos = ((Vector3)transform.position).RandomPointInAnnulus(minRadius, maxRadius);

        Gizmos.DrawSphere(pos, 0.2f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, maxRadius);
    }

}

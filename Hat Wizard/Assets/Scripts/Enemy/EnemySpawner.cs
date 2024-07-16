using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;
using UnityUtils;


public class EnemySpawner : MonoBehaviour
{

    [SerializeField, Range(0,40)] private float minRadius, maxRadius;
    [SerializeField, Range(0, 80)] private int nrEnemy;
    [SerializeField, Range(0,80)] private int preLoadedEnemies;
    
    private GameObject enemyList;
    [SerializeField] private GameObject enemyPrefab;
    
    
   // public GameObject enemyPrefab;
   private GameObject player;

    //Load a predetermined number of enemies
    void preLoadEnmies(){
        for (int i = 0; i < preLoadedEnemies; i++){
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.parent = enemyList.transform;
            enemy.AddComponent<EnemyBehaviour>();
            enemy.SetActive(false);
        }
    }

    public void spawnEnemy(int amount){
        
       /* for (int i = 0; i < amount; i++){
       
        Vector3 spawnPos = player.transform.position.RandomPointInAnnulus(minRadius, maxRadius);
        GameObject enemyTest = Instantiate(enemyPrefab, spawnPos, Quaternion.Euler(0,0,0));
        enemyTest.transform.parent = enemyList.transform;
        }*/
       
        int enemySpawned = 0;
        foreach(Transform enemyTransform in enemyList.transform){
           
           if(enemySpawned >= amount){
            return;
           }

            GameObject enemy = enemyTransform.gameObject;
            if (enemy.activeSelf){
                continue;
            }

            Vector3 spawnPos = player.transform.position.RandomPointInAnnulus(minRadius, maxRadius);
            enemy.transform.position = spawnPos;
            enemy.SetActive(true);
           
            enemySpawned++;
            
        }
    }


    void Awake(){
        enemyList = GameObject.Find("Enemy List");
        preLoadEnmies();
    }
    // Start is called before the first frame update
    void Start()
    {   
        player = GameObject.Find("Player");
        spawnEnemy(nrEnemy);
    }

    // Update is called once per frame
    void Update()
    {   
       /* var step = enemySpeed * Time.deltaTime;
        foreach (Transform enemy in enemyList.transform){
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player.transform.position, step);
        }*/
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,minRadius);

        Gizmos.color = Color.red;
        Vector3 pos = ((Vector3) transform.position).RandomPointInAnnulus(minRadius, maxRadius);

        Gizmos.DrawSphere(pos, 0.2f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,maxRadius);
    }

}

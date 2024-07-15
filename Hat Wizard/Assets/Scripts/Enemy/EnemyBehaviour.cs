using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
     public GameObject enemyPrefab;
    public int preLoadedEnemies = 4;
    public float enemySpeed = 2f;
    private GameObject enemyList;
    private GameObject player;



    void preLoadEnmies(){
        for (int i = 0; i < preLoadedEnemies; i++){
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.parent = enemyList.transform;
            enemy.SetActive(false);
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
        
    }

    // Update is called once per frame
    void Update()
    {
        var step = enemySpeed * Time.deltaTime;
        foreach (Transform enemy in enemyList.transform){
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player.transform.position, step);
        }
    }
}

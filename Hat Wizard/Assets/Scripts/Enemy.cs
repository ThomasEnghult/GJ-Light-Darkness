using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject SpawnArea;
    Vector3 SpawnAreaSize, SpawnAreaPosition;

    int Hp;
    Vector3 Position;


    void create(int enemyAmount){

       for (int i = 0; i < enemyAmount ; i++){
        float x = Random.Range(SpawnAreaPosition.x - SpawnAreaSize.x/2, SpawnAreaPosition.x + SpawnAreaSize.x/2);
        //float y = Random.Range(-SpawnAreaSize.y/2, SpawnAreaSize.y/2);
        float y = 1;
        float z = Random.Range(SpawnAreaPosition.x - SpawnAreaSize.z/2, SpawnAreaPosition.x + SpawnAreaSize.z/2);

        Vector3 spawnLocation = new Vector3(x,y,z);
        print(spawnLocation);
        Instantiate(EnemyPrefab, spawnLocation, SpawnArea.transform.rotation);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState((int)DateTime.Now.Ticks);
        SpawnAreaSize = SpawnArea.transform.localScale;
        SpawnAreaPosition = SpawnArea.transform.position;
        print(UnityEngine.Random.Range(0,10));
        print(UnityEngine.Random.Range(0,10));
        print(UnityEngine.Random.Range(0,10));

        create(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

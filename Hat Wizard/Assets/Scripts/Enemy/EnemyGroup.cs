using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyName", menuName = "ScriptableObjects/CreateEnemy", order = 1)]
public class EnemyGroup : ScriptableObject
{
    public int enemyID;
    public int enemyHP;
    public int enemySpeed;
    public GameObject enemyPrefab;
}

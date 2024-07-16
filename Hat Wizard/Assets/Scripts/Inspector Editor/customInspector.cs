using UnityEngine;
using UnityEditor;
using System.Runtime.CompilerServices;

[CustomEditor(typeof(EnemySpawner))]

 public class customInspector : Editor
 { 
    
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();       

        EnemySpawner enemySpawner = (EnemySpawner) target;

        if(GUILayout.Button("Spawn Enemies Type 1"))
        {
            enemySpawner.spawnEnemy(enemySpawner.nrEnemy, enemySpawner.enemyPrefab1.name);
        }

        if(GUILayout.Button("Spawn Enemies Type 2"))
        {
            enemySpawner.spawnEnemy(enemySpawner.nrEnemy, enemySpawner.enemyPrefab2.name);
        }

        
    }
}
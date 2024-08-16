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

        if(GUILayout.Button("Spawn Enemies Type 0"))
        {
            enemySpawner.spawnEnemy(enemySpawner.nrEnemy, 0);
        }

        if(GUILayout.Button("Spawn Enemies Type 1"))
        {
            enemySpawner.spawnEnemy(enemySpawner.nrEnemy, 1);
        }

        
    }
}
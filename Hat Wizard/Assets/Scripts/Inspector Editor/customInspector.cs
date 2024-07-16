using UnityEngine;
using UnityEditor;

 [CustomEditor(typeof(EnemySpawner))]

 public class customInspector : Editor
 {
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EnemySpawner enemySpawner = (EnemySpawner) target;

        if(GUILayout.Button("Spawn Enemies"))
        {
            enemySpawner.spawnEnemy(10);
        }
    }


}
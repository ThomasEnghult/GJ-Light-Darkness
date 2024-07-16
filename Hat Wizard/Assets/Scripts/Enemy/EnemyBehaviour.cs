using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{    
    [SerializeField, Range(0,6)] private float enemySpeed = 3f;
    [SerializeField, Range(1,50)] private int enemyHP = 3;

    private GameObject player;    

    //Move enemies on the screen towards the player at {enemySpeed}
    void moveToPlayer(){
       
       var step = enemySpeed * Time.deltaTime;
       transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
       
    }

    public void damageEnemy(int dmg){
        enemyHP -= dmg;
        Debug.Log($"Enemy Damaged {enemyHP} HP Left!");
        if(enemyHP <= 0){
            transform.gameObject.SetActive(false);
            Debug.Log("Enemy Killed");
        }
    }

    //Awake is called when an enabled script instance is being loaded.
    void Awake(){
        
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        moveToPlayer();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{    
    private float enemySpeed = 3f;
    private int enemyHP = 3;

    private GameObject player;    

    public int getEnemyHP(){
        return enemyHP;
    }
    
    public float getEnemySpeed(){
        return enemySpeed;
    }


    public void setEnemyHP(int enemyHP){
        this.enemyHP = enemyHP;
    }
    
    public void setEnemySpeed(float enemySpeed){
        this.enemySpeed = enemySpeed;
    }

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

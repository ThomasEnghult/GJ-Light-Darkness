using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    void OnCollisionEnter(Collision collision){
        
        //Debug.Log(collision.transform.name);
        collision.transform.GetComponent<EnemyBehaviour>().damageEnemy(1);

    }


    //Awake is called when an enabled script instance is being loaded.
    void Awake(){
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

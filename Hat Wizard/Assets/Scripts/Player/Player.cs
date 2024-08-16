using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    float hpDeductTime = 0.5f;
    float nextHPDeductTime;
    void OnCollisionStay(Collision collision){
        
        float currentTime = Time.time;
        if(currentTime > nextHPDeductTime)
        {
            collision.transform.GetComponent<EnemyBehaviour>().damageEnemy(1);
            nextHPDeductTime = currentTime + hpDeductTime;
        }
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

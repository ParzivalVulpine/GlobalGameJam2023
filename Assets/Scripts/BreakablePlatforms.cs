using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatforms : MonoBehaviour
{
    int hitCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(hitCounter >= 3)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            hitCounter++;
            
        }
    }
}

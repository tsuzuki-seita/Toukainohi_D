using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallmovescript : MonoBehaviour
{
    float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,10);
    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.forward * speed * Time.deltaTime;
        
    }
}

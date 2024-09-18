using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallmovescript : MonoBehaviour
{
    float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,15);
    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.forward * speed * Time.deltaTime;
        
    }
}

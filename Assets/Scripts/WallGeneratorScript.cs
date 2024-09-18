using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGeneratorScript : MonoBehaviour
{
    public GameObject wall;
    float timer = 0.0f;
    int interval = 12;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= interval){
            Instantiate(wall, transform.position, transform.rotation);
            timer = 0;
        }
    }
}

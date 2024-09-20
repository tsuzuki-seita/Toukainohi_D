using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallGeneratorScript : MonoBehaviour
{
    public GameObject wall;

    public Button StartButton;

    float timer = 0.0f;
    int interval = 12;
    int button = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(button == 1){
            if(timer >= interval){
            Instantiate(wall, transform.position, transform.rotation);
            timer = 0;
            }
        }
        
    }

    public void OnClick(){
        button = 1;
        Instantiate(wall, transform.position, transform.rotation);
        timer = 0;
        StartButton.gameObject.SetActive(false);
    }
}

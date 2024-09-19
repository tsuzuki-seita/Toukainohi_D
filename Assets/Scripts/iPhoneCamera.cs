using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class iPhoneCamera : MonoBehaviour
{
    public RawImage rawImage;
    WebCamTexture webCamTexture;
    WebCamDevice[] webCamDevice; 
    int selectCamera = 0; 
    // Start is called before the first frame update
    void Start()
    {
        webCamTexture = new WebCamTexture();
        webCamDevice = WebCamTexture.devices;
        rawImage.texture = webCamTexture;
        webCamTexture.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChangeCamera();
        }
    }
    public void ChangeCamera() /* 追加４ */
    {
        int cameras = webCamDevice.Length; //カメラの個数
        if ( cameras < 1) return; // カメラが1台しかなかったら実行せず終了

        selectCamera++;
        if (selectCamera >= cameras) selectCamera = 0;

        webCamTexture.Stop(); // カメラを停止
        webCamTexture = new WebCamTexture(webCamDevice[selectCamera].name); //カメラを変更
        rawImage.texture = webCamTexture; 
        webCamTexture.Play(); // 別カメラを開始
    }


}

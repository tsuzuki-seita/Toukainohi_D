using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // シーン遷移のため

public class PlayerController : MonoBehaviour
{
    public int maxLife = 3;  // 最大ライフ
    private int currentLife;

    public Image[] hearts;   // ハートの画像UI
    public GameObject gameOverScreen;  // ゲームオーバー画面への参照
    public Text scoreText;   // スコア表示用テキスト

    static public int score = 0;

    void Start()
    {
        currentLife = maxLife;
        UpdateHearts();
        UpdateScore();
    }

    void Update()
    {
        // プレイヤーの移動処理などをここに追加できます
    }

    void OnTriggerEnter(Collider other)
    {
        // 壁（穴以外）に当たった場合
        if (other.CompareTag("Wall"))
        {
            LoseLife();
        }
    }

    void OnTriggerExit(Collider other)
    {
        // プレイヤーが壁を通り抜けたらスコア加算
        if (other.CompareTag("Hole"))
        {
            AddScore();
        }
    }

    void LoseLife()
    {
        currentLife--;

        UpdateHearts();

        if (currentLife <= 0)
        {
            GameOver();
        }
    }

    void AddScore()
    {
        score++;
        UpdateScore();
    }

    void UpdateHearts()
    {
        // ライフの残数に応じてハートUIを表示/非表示にする
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentLife)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void GameOver()
    {
        // ゲームオーバー画面を有効化
        gameOverScreen.SetActive(true);
        // ゲームのロジックを停止するなどの処理をここで行う
        Time.timeScale = 0f;  // ゲームを一時停止
    }
}

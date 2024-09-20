using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int maxLife = 3;  // 最大ライフ
    private int currentLife;

    public  RawImage[] hearts;   // ハートの画像UI
    public Text scoreText;   // スコア表示用テキスト

    public static int score = 0;

    private float lastScoreTime = -1f;  // スコア加算のタイミングを記録
    private float lastLifeTime = -1f;   // ライフ減少のタイミングを記録
    public float cooldownTime = 1f;     // 1秒間クールダウン

    void Start()
    {
        currentLife = maxLife;
        UpdateHearts();
        UpdateScore();
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
        // 1秒以内に再びライフを減らさない
        if (Time.time - lastLifeTime >= cooldownTime)
        {
            currentLife--;
            lastLifeTime = Time.time;  // 現在の時間を記録

            UpdateHearts();

            if (currentLife <= 0)
            {
                GameOver();
            }
        }
    }

    void AddScore()
    {
        // 1秒以内に再びスコアを加算しない
        if (Time.time - lastScoreTime >= cooldownTime)
        {
            score++;
            lastScoreTime = Time.time;  // 現在の時間を記録

            UpdateScore();
        }
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
        SceneManager.LoadScene("Ranking");
    }
}

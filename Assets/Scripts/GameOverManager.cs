using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void RestartGame()
    {
        // 現在のシーンをリロードしてゲームを再スタート
        Time.timeScale = 1f;  // 一時停止を解除
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        // ゲームを終了
        Application.Quit();
    }
}

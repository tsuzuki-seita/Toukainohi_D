using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{
    // InputFieldの参照
    public InputField inputField;
    // ランキングマネージャーへの参照
    public RankingManager rankingManager;
    // 入力された名前を保存する変数
    private string playerName;

    // InputFieldに名前が入力されたときに呼ばれる関数
    public void OnNameEntered()
    {
        // InputFieldからテキストを取得
        playerName = inputField.text;

        // 名前を表示または保存（ここではログに表示）
        Debug.Log("プレイヤー名: " + playerName);

        // PlayerPrefsを使って名前を保存する（任意）
        PlayerPrefs.SetString("PlayerName", playerName);

        // RankingManagerにプレイヤー名を渡す
        rankingManager.SetPlayerName(playerName);
    }
    void Start()
    {
        PlayerPrefs.DeleteAll();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    int Currerntpoint; // 現在のスコア
    string playerName;  // 現在のプレイヤーの名前

    public GameObject Ranking;
    public GameObject Name;

    string[] ranking = { "ランキング1位", "ランキング2位", "ランキング3位", "ランキング4位", "ランキング5位" };
    string[] rankingNames = { "名前1位", "名前2位", "名前3位", "名前4位", "名前5位" }; // プレイヤー名を保存するキー
    int[] rankingValue = new int[5]; // 各プレイヤーのスコア
    string[] playerNames = new string[5]; // 各プレイヤーの名前

    [SerializeField, Header("表示させるテキスト")]
    Text[] rankingText = new Text[5];

    void Start()
    {
        PlayerPrefs.DeleteAll(); // データをリセットしないようにコメントアウト
        Currerntpoint = PlayerController.score; // デバッグ用のスコア、実際のゲームでは変動する
        
        GetRanking(); // 現在のランキングを取得

        // UIにスコアと名前を表示
        UpdateRankingUI();
    }

    // プレイヤー名を設定し、スコアを更新してランキングに反映する関数
    public void SetPlayerName(string _playerName)
    {
        playerName = _playerName;
        Debug.Log("プレイヤー名確定: " + playerName);

        // プレイヤー名が確定したらスコアを設定
        SetRanking(Currerntpoint);

        // UIを更新
        UpdateRankingUI();
        Name.SetActive(false);
        Ranking.SetActive(true);
    }

    // ランキング呼び出し
    void GetRanking()
    {
        // スコアとプレイヤー名を呼び出し
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(ranking[i], 0); // デフォルトは0
            playerNames[i] = PlayerPrefs.GetString(rankingNames[i], "---"); // 名前がなければ"---"と表示
        }
    }

    // ランキング書き込み
    void SetRanking(int _value)
    {
        // スコアと名前の入れ替え処理
        for (int i = 0; i < ranking.Length; i++)
        {
            if (_value > rankingValue[i])
            {
                var tempScore = rankingValue[i];
                var tempName = playerNames[i];

                rankingValue[i] = _value;
                playerNames[i] = playerName;

                _value = tempScore;
                playerName = tempName;
            }
        }

        // スコアと名前を保存
        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetInt(ranking[i], rankingValue[i]);
            PlayerPrefs.SetString(rankingNames[i], playerNames[i]);
        }

        // 保存を即座に適用
        PlayerPrefs.Save();
    }

    // ランキングをUIに表示する関数
    void UpdateRankingUI()
    {
        for (int i = 0; i < rankingText.Length; i++)
        {
            rankingText[i].text = ranking[i] + " : " + playerNames[i] +" "+ rankingValue[i].ToString()+"pt" ;
        }
    }
}
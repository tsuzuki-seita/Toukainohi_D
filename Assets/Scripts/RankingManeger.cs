using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingManeger : MonoBehaviour {
    int Currerntpoint;//これは現在のスコアになっています！！

    string[] ranking = { "ランキング1位", "ランキング2位", "ランキング3位", "ランキング4位", "ランキング5位" };
    int[] rankingValue = new int[5];//ここで5人に制御しています！！

    [SerializeField, Header("表示させるテキスト")]
    Text[] rankingText=new Text[5];

    // Use this for initialization
    void Start ()
    {
        PlayerPrefs.DeleteAll();//ここで今までのデータが消せます！！
        Currerntpoint = 2;//ここに代入しています！！
        GetRanking();

        SetRanking(Currerntpoint);

        for (int i = 0; i < rankingText.Length; i++)
        {
            rankingText[i].text = ranking[i] + ":" + rankingValue[i].ToString();
        }
    }

    
    /// ランキング呼び出し
    void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i]=PlayerPrefs.GetInt(ranking[i]);
        }
    }

    /// ランキング書き込み
    void SetRanking(int _value)
    {
        //書き込み用
        for (int i = 0; i < ranking.Length; i++)
        {
                //取得した値とRankingの値を比較して入れ替え
                if (_value>rankingValue[i])
                {
                    var change = rankingValue[i];
                    rankingValue[i] = _value;
                    _value = change;
                }
        }

        //入れ替えた値を保存
        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetInt(ranking[i],rankingValue[i]);
        }
    }
}


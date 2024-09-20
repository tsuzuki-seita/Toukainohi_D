using UnityEngine;
using UnityEngine.UI; // ボタン操作用にUIを追加

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectToSpawn;     // 生成するオブジェクト
    public Transform spawnPoint;           // 生成位置として使用するTransform
    public float spawnInterval = 5f;       // 生成間隔（秒）
    public Button startButton;             // スタートボタン

    private float timer;
    private bool isSpawning = false;       // オブジェクトを生成中かどうかのフラグ

    void Start()
    {
        timer = spawnInterval;             // 最初の生成間隔をリセット
        startButton.onClick.AddListener(StartSpawning);  // ボタンが押されたらスタート
    }

    void Update()
    {
        // 生成中のみタイマーをカウントダウン
        if (isSpawning)
        {
            timer -= Time.deltaTime;

            // タイマーが0になったらオブジェクトを生成
            if (timer <= 0f)
            {
                SpawnObject();
                timer = spawnInterval;  // タイマーをリセット
            }
        }
    }

    // スポーン処理を開始するメソッド
    void StartSpawning()
    {
        isSpawning = true;           // オブジェクト生成を開始
        startButton.gameObject.SetActive(false);  // ボタンを非表示にする
    }

    // オブジェクトを生成するメソッド
    void SpawnObject()
    {
        int randomIndex = Random.Range(0, objectToSpawn.Length);
        Instantiate(objectToSpawn[randomIndex], spawnPoint.position, spawnPoint.rotation);
    }
}

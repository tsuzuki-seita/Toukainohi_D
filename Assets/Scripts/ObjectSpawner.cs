using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectToSpawn;     // 生成するオブジェクト
    public Transform spawnPoint;      // 生成位置として使用するTransformオブジェクトの配列
    public float spawnInterval = 5f;     // 生成間隔（秒）

    private float timer;

    void Start()
    {
        timer = 0;  // 最初の生成までの時間を設定
    }

    void Update()
    {
        // タイマーをカウントダウン
        timer -= Time.deltaTime;

        // タイマーが0になったらオブジェクトを生成
        if (timer <= 0f)
        {
            SpawnObject();
            timer = spawnInterval;  // タイマーをリセット
        }
    }

    void SpawnObject()
    {
        // ランダムに生成位置を選択
        int randomIndex = Random.Range(0, objectToSpawn.Length);

        // 選ばれた生成位置にオブジェクトを生成
        Instantiate(objectToSpawn[randomIndex], spawnPoint.position, spawnPoint.rotation);
    }
}

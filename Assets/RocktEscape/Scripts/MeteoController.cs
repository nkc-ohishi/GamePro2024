using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoController : MonoBehaviour
{
    public AudioClip se;
    Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        // カメラオブジェクトのトランスフォームコンポーネントを取得
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 5;            // 移動速度を保存する変数
        Vector3 dir = Vector3.left;  // 移動方向を保存する変数

        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    // 当たり判定処理
    void OnTriggerEnter2D(Collider2D other)
    {
        // 制限時間を１０秒減らす
        GameDirectorRocket.lastTime -= 10;

        // 効果音を鳴らす（オーディオリスナー＝カメラの位置で再生）
        AudioSource.PlayClipAtPoint(se, cam.position);

        // 隕石に何かのオブジェクトが重なったら、隕石を削除
        Destroy(gameObject);
    }

}

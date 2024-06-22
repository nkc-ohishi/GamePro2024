//------------------------------------------------------------------------------
// 科目：ゲームプログラミング
// 内容：６章 RigidBoxy2Dコンポーネントとアニメーション
// 担当：Ken.D.Ohishi 2024.06.27
// 備考：重力１０に設定
//------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chapter06Controller : MonoBehaviour
{
    Rigidbody2D rb2d;        // リジッドボディ２Ⅾコンポーネント保存用
    public float speed;      // 左右の移動速度（UnityEditorで設定 5）
    public float jumpPower;  // ジャンプの強さ（UnityEditorで設定 1500）
    Vector3 startPos;        // プレーヤーの初期位置

    Animator anim;           // アニメーターコンポーネント保存用

    float inputLR;           // 左右キーの入力情報
    bool inputJump = false;  // ジャンプキーフラグ
    bool input4 = false;     // 4キーが押されたら

    int cnt = 0;

    void Start()
    {
        startPos = Vector3.zero;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        inputJump = false;
        input4 = false;
    }

    void Update()
    {
        //リスタートボタン
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
        }

        // 即死ボタン「４」
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            input4 = true;
        }

        // やられアニメーション
        if(input4)
        { 
            anim.Play("PlayerDie");
            return;
        }

        // 左右入力
        inputLR = Input.GetAxisRaw("Horizontal");

        // スプライトの反転（Xのスケールサイズをマイナスにすることにより画像を反転させる）
        if (inputLR != 0)
        {
            Vector3 scale = transform.localScale;   // スケールサイズを取得
            scale.x = Mathf.Abs(scale.x) * inputLR; // 右キー: +scale , 左キー： -scale
            transform.localScale = scale;           // 左右キーの入力に合わせてスケールをセット
            anim.Play("PlayerRun");
        }
        else
        {
            anim.Play("PlayerNeutral");
        }

        // ジャンプ
        if (Input.GetKeyDown(KeyCode.Z))
        {
            inputJump = true;
        }

        // 落下したら初期位置に出現
        if (transform.position.y < -5)
        {
            transform.position = startPos;
        }
    }

    // RigidBody2D関係の処理は FixedUpdate メソッドで行う
    void FixedUpdate()
    {
        // 左右移動
        // rb2d.velocity.x = speed * inputLR; これができないのでいったん変数に保存してセットし直す
        Vector2 vel = rb2d.velocity; // 現在の左右の速度を保存
        vel.x = speed * inputLR;     // 移動方向に合わせてX軸方向の速度をセット
        rb2d.velocity = vel;         // リジッドボディコンポーネントの速度に反映

        if (inputJump)
        {
            rb2d.AddForce(Vector2.up * jumpPower);
            inputJump = false;
        }
    }
}

// メモ
// FixedUpdate・・・１回に実行される時間が決まっているメソッド。デフォルトっでは0.2秒
// FixedUpdateでは反応しない時が出てくるため、Input関係の処理は必ずUpdateメソッドで行う

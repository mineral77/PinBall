using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;
    //スコア
    private int score = 0;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;
    //現在のスコアを表示するテキスト
    private GameObject ScoreText;


    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        this.ScoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    //衝突時に呼ばれる関数
    private void OnCollisionEnter(Collision collision)
    {
        // タグによってスコアを変える
        if (collision.gameObject.tag == "SmallStarTag")
        {
            this.score += 10;
        }
        else if (collision.gameObject.tag == "LargeStarTag")
        {
            this.score += 20;
        }
        else if (collision.gameObject.tag == "SmallCloudTag" || collision.gameObject.tag == "LargeCloudTag")
        {
            this.score -= 5;
        }

        //ScoreTextにscoreを表示
        this.ScoreText.GetComponent<Text>().text = "SCORE:" + score.ToString();

    }
}

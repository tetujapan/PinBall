using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	


	// 角度
	private int degree = 0;

	// スコアの初期値
	private int score = 0;
	//加算用変数
	private int addScore = 0;
	// スコア表示用の文字列
	private string scoreString;
	//スコアの加算設定（大きい星）
	private int scoreLargeStar = 40;
	//スコアの加算設定（小さい星）
	private int scoreSmallStar = 30;
	//スコアの加算設定（大きい雲）
	private int scoreLargeCloud = 20;
	//スコアの加算設定（小さい雲）
	private int scoreSmallCloud = 10;

	//スコアを表示するテキスト
	private GameObject scoreText;


	// Use this for initialization
	void Start () {

		if (Input.touchSupported) {
			print("タッチ入力に対応している");
		}

		//シーン中のScoreTextオブジェクトを取得
		this.scoreText = GameObject.Find("ScoreText");
	}
	
	// Update is called once per frame
	void Update () {

	}

	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other) {

		// 衝突相手 (other) の情報を console に出力する
		Debug.Log("Ball hit " + other.gameObject.name + " tagged: " + other.gameObject.tag);    

		if (other.gameObject.tag == "SmallStarTag") {
			this.addScore = scoreSmallStar;
			Debug.Log ("小さい星");

		} else if (other.gameObject.tag == "LargeStarTag") {
			this.addScore = scoreLargeStar;
			Debug.Log ("大きい星");

		} else if (other.gameObject.tag == "SmallCloudTag") {
			this.addScore = scoreSmallCloud;
			Debug.Log ("小さい雲");

		} else if (other.gameObject.tag == "LargeCloudTag") {
			this.addScore = scoreLargeCloud;
			Debug.Log ("大きい雲");
		}

		//スコアに加算
		score += addScore;

		//int型を文字列に変換
		scoreString = score.ToString();

		//GameoverTextにゲームオーバを表示
		this.scoreText.GetComponent<Text> ().text = scoreString;

		// 変数を表示する　
		Debug.Log (score);

		//加算用変数を0に戻す
		addScore = 0;


	}
}

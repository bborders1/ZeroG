﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

	public Text textField;
	public Text score;
	public Image black;
	private bool p1Win;
	private bool p2Win;
	private bool p3Win;
	private bool p4Win;
	public float endTime;
	public string nextLevel;
	private float levelTimer = 6f;
	private bool nextGame;
	private bool endGame;
    public GameOptions DragScoreSystemHere;
	// Use this for initialization
	void Start () {
		nextGame = false;
		endGame = false;
		textField.text = "";
		score.text = "";
		black.enabled = false;
        DragScoreSystemHere = FindObjectOfType<GameOptions>();
	}

	void OnTriggerEnter(Collider col){
		nextGame = true;
		if (endGame == false) {
			
			if (col.gameObject.tag == "Player1") {
				p1Win = true;
				endGame = true;
				ScoreSystem.Instance.player1Score += 3;
				textField.text = "Green Wins!!!";
				//score.text = "Player 1: "+ScoreSystem.Instance.player1Score+" point(s)\nPlayer 2: "+ScoreSystem.Instance.player2Score+" point(s)\nPlayer 3: "+ScoreSystem.Instance.player3Score+" point(s)\nPlayer 4: "+ScoreSystem.Instance.player4Score+" point(s)";
			}

			if (col.gameObject.tag == "Player2") {
				p2Win = true;
				endGame = true;
				ScoreSystem.Instance.player2Score += 3;
				textField.text = "Red Wins!!!";
				//score.text = "Player 1: "+ScoreSystem.Instance.player1Score+" point(s)\nPlayer 2: "+ScoreSystem.Instance.player2Score+" point(s)\nPlayer 3: "+ScoreSystem.Instance.player3Score+" point(s)\nPlayer 4: "+ScoreSystem.Instance.player4Score+" point(s)";
			}

			if (col.gameObject.tag == "Player3") {
				p3Win = true;
				endGame = true;
				ScoreSystem.Instance.player3Score += 3;
				textField.text = "Purple Wins!!!";
				//score.text = "Player 1: "+ScoreSystem.Instance.player1Score+" point(s)\nPlayer 2: "+ScoreSystem.Instance.player2Score+" point(s)\nPlayer 3: "+ScoreSystem.Instance.player3Score+" point(s)\nPlayer 4: "+ScoreSystem.Instance.player4Score+" point(s)";
			}

			if (col.gameObject.tag == "Player4") {
				p4Win = true;
				endGame = true;
				ScoreSystem.Instance.player4Score += 3;
				textField.text = "Blue Wins!!!";
				//score.text = "Player 1: "+ScoreSystem.Instance.player1Score+" point(s)\nPlayer 2: "+ScoreSystem.Instance.player2Score+" point(s)\nPlayer 3: "+ScoreSystem.Instance.player3Score+" point(s)\nPlayer 4: "+ScoreSystem.Instance.player4Score+" point(s)";
			}
		}

		if (endGame == true) {

			if (col.gameObject.tag == "Player1" && p1Win == false) {
				p1Win = true;
				ScoreSystem.Instance.player1Score += 1;
			}

			if (col.gameObject.tag == "Player2" && p2Win == false) {
				p2Win = true;
				ScoreSystem.Instance.player2Score += 1;
			}

			if (col.gameObject.tag == "Player3" && p3Win == false) {
				p3Win = true;
				ScoreSystem.Instance.player3Score += 1;
			}

			if (col.gameObject.tag == "Player4" && p4Win == false) {
				p4Win = true;
				ScoreSystem.Instance.player4Score += 1;
			}
		}
	}

	void Update(){
		if(endGame){
			endTime -= Time.deltaTime;
			if (endTime < 0) {
				levelTimer -= Time.deltaTime;
				black.enabled = true;
				score.text = "Green: "+ScoreSystem.Instance.player1Score+" point(s)\nRed: "+ScoreSystem.Instance.player2Score+" point(s)\nPurple: "+ScoreSystem.Instance.player3Score+" point(s)\nBlue: "+ScoreSystem.Instance.player4Score+" point(s)";
			}
			if (levelTimer <= 5) {
				textField.text = "5";
			}if (levelTimer <= 4) {
				textField.text = "4";
			}if (levelTimer <= 3) {
				textField.text = "3";
			}if (levelTimer <= 2) {
				textField.text = "2";
			}if (levelTimer <= 1) {
				textField.text = "1";
			}
			if(levelTimer < 0){
                DragScoreSystemHere.LoadLevel();
			}
		}
		
	}
}

﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Game manager. ゲーム全体を管理するクラス
/// ゲームの設定やユーザのデータを取得する
/// </summary>
public class GameManager : SingletonMonoBehaviour<GameManager>
{
		private float timer;							// コンボ用のタイマー
		private float commboFinishTime = 2;				// コンボ終了時間
	
		void Update ()
		{
				// コンボ中
				if (_StateManager.IsCommboChain ()) {
						timer += Time.deltaTime;
			
						// 連鎖終了
						if (timer > commboFinishTime) {
								_StateManager.SetState ((int)SceneState.NORMAL);
								_ScoreManager.SetCommboCount (1);
								InitCommboTimer ();
						}
				}
				ApplicationFinish ();
		}
	
		private void GameFinish ()
		{
				SaveManager.SaveScore (_ScoreManager.GetScore ().ToString ());
				CloneManager.CloneGameOver ();
		}
	
		private void CreateRegisterPanel ()
		{
				BlockUI ();
				CloneManager.CloneRegisterPanel ();
		}
	
		private void InitCommboTimer ()
		{
				this.timer = 0;
		}
	
		private void ApplicationFinish ()
		{
				#if UNITY_ANDROID
				if (Application.platform == RuntimePlatform.Android) {
						#endif
						if (Input.GetKey (KeyCode.Home) || Input.GetKey (KeyCode.Escape) || Input.GetKey (KeyCode.Menu)) {
								Application.Quit ();
								return;
						}
				}
		}
}
using UnityEngine;
using System.Collections;

/// <summary>
/// Game manager. ゲーム全体を管理するクラス
/// </summary>
public class GameManager : BaseMonoBehaviour
{
		private float timer;							// コンボ用のタイマー
		private float commboFinishTime = 2;				// コンボ終了時間
		
		void Update ()
		{
				// コンボ中
				if (StateManager.Instance.IsCommboChain ()) {
						timer += Time.deltaTime;
						
						// 連鎖終了
						if (timer > commboFinishTime && !StateManager.Instance.IsFeverMode ()) {
								StateManager.Instance.SetState ((int)Enum.State.NORMAL);
								ScoreManager.Instance.SetCommboCount (1);
								InitCommboTimer ();
						}
				}
				
				// ゲームスタート
				if (StateManager.Instance.IsStartMode ()) {
				
						Destroy (CloneManager.ParentFrontPanel ());
						
						CloneManager.CloneMainPanel (gameObject);
						if (GameObject.Find ("Panel")) {
								StateManager.Instance.SetState ((int)Enum.State.NORMAL);
						}
				}
				
				ApplicationFinish ();
		}
		
		/// <summary>
		/// Games the finish.
		/// </summary>
		private void GameFinish ()
		{
				// スコアの保存
				SaveManager.SaveScore (ScoreManager.Instance.GetScore ().ToString ());
				CloneManager.CloneGameOver (transform);
		}
		
		private void CreateRegisterPanel ()
		{
				CloneManager.CloneRegisterPanel (transform);
		}
		
		// ゲームをリトライ
		private void ReStart ()
		{
				StartCoroutine (WaitReStart ());
		}
	
		IEnumerator WaitReStart ()
		{
				yield return new WaitForSeconds (0.5f);
				StateManager.Instance.SetState ((int)Enum.State.START);
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


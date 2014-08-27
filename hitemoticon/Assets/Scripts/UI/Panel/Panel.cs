using UnityEngine;
using System.Collections;

public class Panel : BaseMonoBehaviour
{
		void Start ()
		{
				GameInitialize ();

				CloneManager.ClonePlayer (gameObject);
				CloneManager.CloneFireButton (gameObject);
				CloneManager.CloneScore (gameObject);
				CloneManager.CloneEmitter (gameObject);
				CloneManager.CloneLifeBar (gameObject);
				CloneManager.CloneGameoverFlag (gameObject);
				CloneManager.CloneFallingItem (gameObject);
		}
		
		// ゲーム初期化
		private void GameInitialize ()
		{
				charaControll.InitPlayer ();
				_ScoreManager.InitScore ();
				_StateManager.SetState ((int)Enum.State.NORMAL);
		}
}
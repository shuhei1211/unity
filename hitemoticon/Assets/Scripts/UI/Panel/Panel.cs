using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Panel : BaseMonoBehaviour
{
		void Start ()
		{
				GameInitialize ();

				CloneManager.CloneObject (CloneManager.Player, gameObject, "Player");
				CloneManager.CloneObject (CloneManager.FireButton, gameObject, "FireButton");
				CloneManager.CloneObject (CloneManager.Score, gameObject, "Score");
				CloneManager.CloneObject (CloneManager.Emitter, gameObject, "Emitter");
				CloneManager.CloneObject (CloneManager.LifeBar, gameObject, "LifeBar");
				CloneManager.CloneObject (CloneManager.FlagObject, CloneManager.ParentCorePanel, "FlagObject");
				CloneManager.CloneObject (CloneManager.FallingItem, gameObject, "FallingItem");
		}
		
		// ゲーム初期化
		private void GameInitialize ()
		{
				charaControll.InitPlayer ();
				_ScoreManager.InitScore ();
				_ScoreManager.SetCommboCount (0);
				_StateManager.SetState ((int)SceneState.NORMAL);
		}
}
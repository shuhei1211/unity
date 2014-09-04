using UnityEngine;
using System.Collections;

/// <summary>
/// Game state. ゲーム全体の状態を管理するクラス
/// </summary>
public class StateManager : SingletonMonoBehaviour<StateManager>
{
		// ゲームの状態
		private int state;
		[HideInInspector]
		public SceneState
				sceneState = SceneState.NONE;
		[HideInInspector]
		public GameObject
				controllerObject;

		void Start ()
		{
				sceneState = SceneState.TITLE;
				StartCoroutine (TitleScene ());
		}
	
		IEnumerator TitleScene ()
		{
				controllerObject = new GameObject ("Title");
				controllerObject.AddComponent<TitleController> ();
				yield return null;
		}

		private bool isFeverMode = false;
		public bool IsFeverMode {
				get { return isFeverMode;}
				set { isFeverMode = value;}
		}
	
		public bool IsCommboChain ()
		{
				return (GetState == (int)SceneState.COMMBO);
		}
	
		public bool IsNormalMode ()
		{
				return (GetState == (int)SceneState.NORMAL);
		}
	
		public bool IsStartMode ()
		{
				return (GetState == (int)SceneState.START);
		}
	
		public int GetState {
				get{ return state;}
		}
	
		public void SetState (int newState)
		{
				if (newState == state)
						return;
				int oldState = state;
				state = newState;
		}
	
		public bool IsConnctNetwork ()
		{
				return Application.internetReachability == NetworkReachability.NotReachable ? false : true;
		}
}
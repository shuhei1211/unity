using UnityEngine;
using System.Collections;

/// <summary>
/// Base mono behaviour.
/// 基底クラス
/// </summary>
public abstract class BaseMonoBehaviour : MonoBehaviour
{
		protected GameObject Find (GameObject obj, string name)
		{
				if (!obj) {
						return GameObject.Find (name);
				} else {
						return null;
				}
		}

		// Get Controller
		//_____________________________________________________________________________
		
		protected CharacterControll charaControll {
				get { return _DataManager.GetController<CharacterControll> ();}
		}

		// Common 
		//_____________________________________________________________________________
		protected GameObject _ParentGameObject {
				get{ return gameObject.transform.parent.gameObject;}
		}

		protected void BlockUI ()
		{
				CloneManager.CloneObject (CloneManager.BlockUI, CloneManager.ParentUiRoot (), "BlockingUI");
		}

		protected void DestroyBlockUI ()
		{
				Destroy (GameObject.Find ("BlockingUI"));
		}
		
		// Get Manager
		//_____________________________________________________________________________
		
		protected GameManager _GameManager {
				get { return GameManager.Instance;}
		}
		
		protected StateManager _StateManager {
				get{ return StateManager.Instance;}
		}
	
		protected ScoreManager _ScoreManager {
				get{ return ScoreManager.Instance;}
		}
		
		protected Notificator _Notificator {
				get { return Notificator.Instance;}
		}
		
		protected DataManager _DataManager {
				get { return DataManager.Instance;}
		}
		
		protected SoundManager _SoundManager {
				get { return SoundManager.Instance;}
		}


		// Get Component 
		//_____________________________________________________________________________
	
		protected UISprite _UISprite {
				get { return GetComponent<UISprite> ();}
		}
	
		protected UIButton _UIButton {
				get { return GetComponent<UIButton> ();}
		}
	
		protected UIPlaySound _UIPlaySound {
				get { return GetComponent<UIPlaySound> ();}
		}
	
		protected UIButtonScale _UIButtonScale {
				get { return GetComponent<UIButtonScale> ();}
		}

		protected UIWidget _UIWidget {
				get { return GetComponent<UIWidget> ();}
		}
	
		protected BoxCollider2D _BoxCollider2D {
				get { return boxcollider2D;}
		}

		protected Rigidbody2D _Rigidbody2D {
				get { return rigidbody2D;}
		}

		
		// GetComponentを複数回呼び出さない
		//_____________________________________________________________________________
		
		private Transform _transform;
		private Rigidbody _rigidbody;
		private Rigidbody2D _rigidbody2D;
		private BoxCollider2D _boxcollider2D;
	
		protected new Transform transform {
				get {
						if (_transform == null) {
								_transform = GetComponent<Transform> ();
						}
						return _transform;
				}
		}
	
		protected new Rigidbody rigidbody {
				get {
						if (_rigidbody == null) {
								_rigidbody = GetComponent<Rigidbody> ();
						}
						return _rigidbody;
				}
		}
	
		protected new Rigidbody2D rigidbody2D {
				get {
						if (_rigidbody2D == null) {
								_rigidbody2D = GetComponent<Rigidbody2D> ();
						}
						return _rigidbody2D;
				}
		}
		
		protected new BoxCollider2D boxcollider2D {
				get {
						if (_boxcollider2D == null) {
								_boxcollider2D = GetComponent<BoxCollider2D> ();
						}
						return _boxcollider2D;
				}
		}
}

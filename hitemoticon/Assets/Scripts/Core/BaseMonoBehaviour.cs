using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	
		private UISprite uisprite;
		private UIButton uibutton;
		private UIButtonScale uibuttonscale;
		private UIWidget uiwidget;

		protected UISprite _UISprite {
				get { 
						if (uisprite == null) {
								uisprite = GetComponent<UISprite> ();
						}
						return uisprite;
				}
		}
	
		protected UIButton _UIButton {
				get { 
						if (uibutton == null) {
								uibutton = GetComponent<UIButton> ();
						}
						return uibutton;
				}
		}
	
		protected UIButtonScale _UIButtonScale {
				get { 
						if (uibuttonscale == null) {
								uibuttonscale = GetComponent<UIButtonScale> ();
						}
						return uibuttonscale;
				}
		}

		protected UIWidget _UIWidget {
				get { 
						if (uiwidget == null) {
								uiwidget = GetComponent<UIWidget> ();
						}
						return uiwidget;
				}
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

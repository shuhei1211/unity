using UnityEngine;
using System.Collections;

/// <summary>
/// Base button.
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(UIButton))]
[RequireComponent(typeof(UIButtonScale))]
public abstract class BaseButton : BaseMonoBehaviour
{
		void Start ()
		{
				_UISprite.ResizeCollider ();
				_BoxCollider2D.isTrigger = true;
				_UIButtonScale.hover = Vector3.one;
				_UIButton.onClick.Add (new EventDelegate (OnClickPlaySound));
		}
		
		void Update ()
		{
				EnenabledButton ();
		}
		
		protected void OnClickPlaySound ()
		{
				_SoundManager.PlaySE ((int)SE.CLICK);
		}
		
		/// <summary>
		/// ボタンの無効化
		/// </summary>
		protected void EnenabledButton ()
		{
				if (GameObject.Find ("BlockingUI")) {
						_BoxCollider2D.enabled = false;
						return;
				}
				_BoxCollider2D.enabled = true;
		}
}
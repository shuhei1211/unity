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
		public enum ClickEvent {
			
		}

		void Start ()
		{
				_UISprite.ResizeCollider ();
				boxcollider2D.isTrigger = true;
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
						boxcollider2D.enabled = false;
						return;
				}
				boxcollider2D.enabled = true;
		}
}
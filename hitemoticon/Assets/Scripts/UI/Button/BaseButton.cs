using UnityEngine;
using System.Collections;

/// <summary>
/// Base button.
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(UIPlaySound))]
[RequireComponent(typeof(UIButton))]
[RequireComponent(typeof(UIButtonScale))]
public class BaseButton : BaseMonoBehaviour
{
		void Start ()
		{
				_UISprite.ResizeCollider ();
				_BoxCollider2D.isTrigger = true;
				_UIButtonScale.hover = Vector3.one;
		}
		
		void Update ()
		{
				EnenabledButton ();
		}
		
		
		/// <summary>
		/// ボタンの無効化
		/// </summary>
		protected void EnenabledButton ()
		{
				if (GameObject.Find ("BlockingUI")) {
						_BoxCollider2D.enabled = false;
				} else {
						_BoxCollider2D.enabled = true;
				}
		}
		
}

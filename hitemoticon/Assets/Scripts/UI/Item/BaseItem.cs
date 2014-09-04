using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(TweenScale))]
public abstract class BaseItem : BaseMonoBehaviour
{
		private float startPositionX;
		private delegate void OnTriggerCallback ();
		private OnTriggerCallback triggerCallback;
		
		protected abstract void EffectedItem ();
		
		void Start ()
		{
				SetTweenScale();
				startPositionX = transform.position.x;
				triggerCallback = EffectedItem;
				Destroy (gameObject, Config.DESTROY_TIME_ITEM);
		}
		
		void Update ()
		{
				transform.SetPositionX (startPositionX);
		}

		void OnTriggerEnter2D (Collider2D col)
		{
				if (col.tag == "Player") {
						_SoundManager.PlaySE ((int)SE.PICK_UP);
						triggerCallback ();
						Destroy (gameObject);
				}
		}
		
		private void SetTweenScale ()
		{
				GetComponent<TweenScale> ().from = Vector2.one;
				GetComponent<TweenScale> ().to = Vector2.one * 1.3f;
				GetComponent<TweenScale> ().style = UITweener.Style.PingPong;
				GetComponent<TweenScale> ().duration = 0.2f;
		}
}
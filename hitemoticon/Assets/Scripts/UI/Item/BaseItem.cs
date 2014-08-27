using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BaseItem : BaseMonoBehaviour
{
		public AudioClip audioClipPickup;
		private float startPositionX;
	
		void Start ()
		{
				startPositionX = transform.position.x;		
				Destroy (gameObject, Config.DESTROY_TIME_ITEM);
		}
		
		void Update ()
		{
				transform.SetPositionX (startPositionX);
		}
}

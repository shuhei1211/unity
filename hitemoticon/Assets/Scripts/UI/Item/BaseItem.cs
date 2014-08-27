using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BaseItem : BaseMonoBehaviour
{
		public AudioClip audioClipPickup;

		void Start ()
		{
				Destroy (gameObject, Config.DESTROY_TIME_ITEM);
		}

}

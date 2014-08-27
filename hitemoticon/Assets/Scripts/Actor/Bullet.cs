using UnityEngine;
using System.Collections;

/// <summary>
/// Bullet. 弾クラス
/// </summary>
public class Bullet : BaseMonoBehaviour
{
		private float speed = 1.0f;
		private float startPositionX;

		void Start ()
		{
				startPositionX = transform.position.x;
				rigidbody2D.velocity = transform.up.normalized * speed;
				Destroy (gameObject, 3);
		}

		void Update ()
		{
				transform.SetPositionX (startPositionX);
		}
}

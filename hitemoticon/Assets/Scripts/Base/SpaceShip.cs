using UnityEngine;
using System.Collections;

/// <summary>
/// SpaceShipの親クラス
/// </summary>
public abstract class SpaceShip : BaseMonoBehaviour
{
		public AudioClip audioClipExplode;
		public GameObject particle;		// パーティクルプレハブ
		private float lifetime = 0.3f;			// 爆発の生存時間
		
		/// <summary>
		/// SpaceShipの移動
		/// </summary>
		protected abstract void Move ();
		
		/// <summary>
		/// Creates the particle. パーティクルの生成
		/// </summary>
		protected void createParticle ()
		{
				GameObject clone = Instantiate (particle, transform.position, Quaternion.identity) as GameObject;
				clone.name = "Particle";
				Destroy (gameObject);
				Destroy (clone, lifetime);
		}
}
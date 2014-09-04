using UnityEngine;
using System.Collections;

/// <summary>
/// SpaceShipの親クラス
/// </summary>
public abstract class SpaceShip : BaseMonoBehaviour
{
		public GameObject particle;		// パーティクルプレハブ
		private float lifetime = 0.3f;			// 爆発の生存時間
		
		/// <summary>
		/// Creates the particle. パーティクルの生成
		/// </summary>
		protected void createParticle ()
		{
				_SoundManager.PlaySE ((int)SE.EXPLODE_ONE);
				GameObject clone = Instantiate (particle, transform.position, Quaternion.identity) as GameObject;
				clone.transform.parent = gameObject.transform.parent;
				clone.name = "Particle";
				Destroy (gameObject);
				Destroy (clone, lifetime);
		}
}
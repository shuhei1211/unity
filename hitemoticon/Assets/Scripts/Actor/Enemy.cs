using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy. 敵クラス
/// </summary>
public class Enemy : SpaceShip
{
		private float moveSpeed = 1.0f;
		UISprite sprite;

		void Awake ()
		{
				sprite = GetComponent<UISprite> ();
		}
		
		void Start ()
		{
				Move ();
		}
	
		void Update ()
		{
				if (gameObject.transform.localPosition.y < Screen.height - sprite.height) {
//						Debug.Log ("aaaa");
				}
		}
		
		protected override void Move ()
		{
				float range = Random.Range (-1.8f, 1.8f);
				float v = ((range <= 0.5f && range >= -0.5f)) ? 1.0f : range;
				rigidbody2D.velocity = moveSpeed * transform.right.normalized * v;
		}
		
		// 衝突
		void OnTriggerEnter2D (Collider2D col)
		{
		
				// 壁と衝突
				if (col.tag == "Wall") {
						rigidbody2D.velocity = new Vector2 (-rigidbody2D.velocity.x, rigidbody2D.velocity.y);
				}
				
				if (col.tag == "WallBottom") {
						rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, -rigidbody2D.velocity.y);
				}
				
				// 弾丸と衝突
				if (col.tag == "Bullet") {
						NGUITools.PlaySound (audioClipExplode);
						
						// コンボ状態へ変更
						if (_StateManager.GetState () != (int)Enum.State.COMMBO) {
								_StateManager.SetState ((int)Enum.State.COMMBO);
						}
						
						// 弾丸削除
						Destroy (col.gameObject);
						createParticle ();
						_ScoreManager.AddScore ();
				}
				
				// パーティクルと衝突
				if (col.tag == "Particle") {
						NGUITools.PlaySound (audioClipExplode);
						createParticle ();
						
						// コンボタイマーを初期化
						NGUITools.Broadcast ("InitCommboTimer");					
						
						// コンボ状態へ変更
						if (_StateManager.GetState () != (int)Enum.State.COMMBO) {
								_StateManager.SetState ((int)Enum.State.COMMBO);
						}
						
						// コンボ中ならコンボスコアを加算
						if (_StateManager.IsCommboChain ()) {
								_ScoreManager.CommboScore ();
						}
				}
		}
}
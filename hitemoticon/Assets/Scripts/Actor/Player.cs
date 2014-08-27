using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

/// <summary>
/// Player. プレイヤークラス
/// </summary>
public class Player : SpaceShip
{
		private float moveSpeed;		// プレイヤーの移動速度
		private bool isMove;			// プレイヤーの移動可能フラグ
		private float width; 			// プレイヤーの幅
		private bool isShotRequest;		// プレイヤーが弾を発射
		private bool isShotDelay;		// 弾の発射を遅らせるフラグ
		private float delayTime;		// 弾の発射間隔
		private float directionX;		// 移動の向き
	
		public GameObject bullet;		// 弾丸プレハブ
	
		public AudioClip audioClipDamage;
		private Camera camera;
		private Vector3 pointZero;
		private Vector3 pointOne;
	
		// 初期化
		private void Init ()
		{
				moveSpeed = 1.5f;
				isMove = true;
				isShotDelay = true;
				delayTime = 0.3f;
		}
	
		void Start ()
		{
				Init ();
		
				camera = GameObject.Find ("Camera").GetComponent<Camera> ();
				pointZero = camera.ViewportToWorldPoint (new Vector2 (0, 0));	// 左下の座標
				pointOne = camera.ViewportToWorldPoint (new Vector2 (1, 1));	// 右上の座標
				width = gameObject.GetComponent<UISprite> ().width;	// プレイヤーの幅を取得
				
				Debug.Log ("width : " + Screen.width); 
				Debug.Log ("height : " + Screen.height); 
				Debug.Log ("cameraZero : " + pointZero.x);
				Debug.Log ("cameraZero y : " + pointZero.y);
				Debug.Log ("cameraOne : " + pointOne.x);
				Debug.Log ("ookisa : " + width);
				Debug.Log ("localy : " + transform.localPosition.y);
				Debug.Log ("worldy : " + transform.position.y);
		
		}
	
		void Update ()
		{
				#if UNITY_EDITOR
				// スペースボタンを押す
				if (Input.GetKeyDown (KeyCode.Space)) {
						isShotRequest = true;
				} else if (Input.GetKeyUp (KeyCode.Space)) {
						isShotRequest = false;
				}
				#endif
				Move ();
		}
	
		void FixedUpdate ()
		{
				// 弾が発射可能か
				if (isShotRequest && isMove) {
						// 弾の発射間隔
						if (isShotDelay) {
				
								NGUITools.AddChild (gameObject, bullet, "Bullet");
								isShotDelay = false;
								StartCoroutine (ShotDelay ());
						}
				}
		}
	
		void OnTriggerEnter2D (Collider2D col)
		{
				// 敵もしくは敵の爆発と衝突
				if (isMove && col.tag == "Enemy" || col.tag == "Particle") {
						NGUITools.PlaySound (audioClipDamage);
						isMove = false;
						GetComponent<TweenAlpha> ().enabled = true;
						transform.SetEulerAnglesZ (-45);
						charaControll.DoDamage ();
						StartCoroutine (OnWait ());
				}
		
				// HPが０以下で爆発
				if (charaControll.PlayerHP <= 0) {
						NGUITools.PlaySound (audioClipExplode);
			
						// コンボ状態へ変更
						if (_StateManager.GetState () != (int)Enum.State.COMMBO) {
								_StateManager.SetState ((int)Enum.State.COMMBO);
						}
						createParticle ();
				}
		}
	
		// 敵や爆発と衝突したときに静止
		private IEnumerator OnWait ()
		{
				yield return new WaitForSeconds (2.0f);
				isMove = true;
				directionX = 0;
				transform.SetEulerAnglesZ (0);
				GetComponent<TweenAlpha> ().enabled = false;
				GetComponent<UISprite> ().alpha = 1.0f;
		}
	
		// 発射間隔を遅らせる
		private IEnumerator ShotDelay ()
		{
				yield return new WaitForSeconds (delayTime);
				isShotDelay = true;
		}
	
		// プレイヤーの移動
		protected override void Move ()
		{
				if (!isMove) {
						return;
				}
				if (Input.touchCount > 0) {
						Touch touch = Input.GetTouch (0);
			
						switch (Input.GetTouch (0).phase) {
						case TouchPhase.Moved:
						case TouchPhase.Stationary:
								if (touch.deltaPosition.x > 0) {
										directionX = 1;
//										transform.Translate (Vector3.right * directionX * moveSpeed * Time.deltaTime);
								} else if (touch.deltaPosition.x < 0) {
										directionX = -1;
//										transform.Translate (Vector3.right * directionX * moveSpeed * Time.deltaTime);
								}
								break;
						case TouchPhase.Ended:
								directionX = 0;
								break;
						}
				}
#if UNITY_EDITOR
				directionX = Input.GetAxis ("Horizontal");
#endif
				transform.Translate (Vector3.right * directionX * moveSpeed * Time.deltaTime);
		
				Vector2 currentPosition = transform.position;
				currentPosition.x = Mathf.Clamp (currentPosition.x, pointZero.x + (width / Screen.width) / 2, pointOne.x - (width / Screen.width) / 2);
				currentPosition.y = Mathf.Clamp (currentPosition.y, pointZero.y, pointOne.y);
		
				transform.position = currentPosition;
		}
	
		// 弾丸発射
		public void FireBullet ()
		{
				if (!gameObject)
						return;
				isShotRequest = true;
		}
	
		// 弾丸発射ストップ
		public void StopBullet ()
		{
				if (!gameObject)
						return;
				isShotRequest = false;
		}
}
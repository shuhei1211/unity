using UnityEngine;
using System.Collections;

/// <summary>
/// Base mono behaviour.
/// 基底クラス
/// </summary>
public abstract class BaseMonoBehaviour : MonoBehaviour
{
		protected GameObject gameManager;
		protected CharacterControll charaControll;
		protected Camera camera;			// nguiのカメラ
		protected Vector2 pointZero;			// 左下の座標
		protected Vector2 pointOne;			// 右上の座標
	
		void Awake ()
		{	
				gameManager = Find (gameManager, "GameManager");
				charaControll = gameManager.GetComponent<CharacterControll> ();
				
				camera = GameObject.Find ("Camera").GetComponent<Camera> ();
				pointZero = camera.ViewportToWorldPoint (new Vector2 (0, 0));	// 左下の座標
				pointOne = camera.ViewportToWorldPoint (new Vector2 (1, 1));	// 右上の座標
		}

		/// <summary>
		/// Find the specified obj and name. GameObjectを走査する
		/// </summary>
		/// <param name="obj">Object.</param>
		/// <param name="name">Name.</param>
		protected GameObject Find (GameObject obj, string name)
		{
				if (!obj) {
						return GameObject.Find (name);
				} else {
						return null;
				}
		}

		void Start ()
		{
				// 初回のUpdate前に呼ばれる
		}
		
		void Update ()
		{
				// 毎フレーム呼ばれる
				// フラグ管理等を行いFixedUpdateで物理処理を行う
		}
		
		void FixedUpdate ()
		{
				// 物理専用の特殊なUpdate関数
				// フレームの概念とは関係なく一定時間ごとに(default 0.01sec)実行される
		}
		
		void LateUpdate ()
		{
				// すべてのupdate関数の終了時に呼ばれる
				// そのためカメラの追跡等に向いている
		}
		
		void OnDestroy ()
		{
		    
		}
}

using UnityEngine;
using System.Collections;

public class Emitter : BaseMonoBehaviour
{
		private float interval;	// 敵の出現間隔
		private bool isAcceratorState = false;
		private float timer;
		private float waitTime = 8f;
		
		IEnumerator Start ()
		{
				interval = 0.8f;
				
				while (true) {
						//	 GameOver画面があれば終了する
						if (GameObject.Find ("GameOver")) {
								yield break;
						}
						
						if (isAcceratorState) {
								float acceratorInterval = 0.1f;
								CloneManager.CloneEnemy (gameObject);
								timer = timer + 0.1f;
								if (timer > waitTime) {
										isAcceratorState = false;
										StateManager.Instance.SetState ((int)Enum.State.NORMAL);
										timer = 0f;
								}
								yield return new WaitForSeconds (acceratorInterval);
						} else {
								CloneManager.CloneEnemy (gameObject);
								if (interval >= 0.2f) {
										interval = interval - 0.01f;
								}
								yield return new WaitForSeconds (interval);
						}
				}
		}
		
		private void OnSpeedSpwan ()
		{
				isAcceratorState = true;
		}
}
using UnityEngine;
using System.Collections;

public class DelegateMain : MonoBehaviour
{
		void Start ()
		{
				DelegateTest.GameStart (GameStart);
				DelegateTest.GameStop (GameStop);
				DelegateTest.GameFinish (GameFinish);
		}

		void GameStart ()
		{
				Debug.Log ("GameStart");
		}

		void GameStop ()
		{
				Debug.Log ("GameStop");
		}

		void GameFinish (string msg)
		{
				Debug.Log ("GameFinish" + msg);
		}
}

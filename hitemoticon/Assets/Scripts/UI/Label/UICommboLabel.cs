using UnityEngine;
using System.Collections;

/// <summary>
/// Commbo label. コンボラベルクラス
/// </summary>
public class UICommboLabel : BaseMonoBehaviour
{
		private UILabel commboCount;
		
		void Awake ()
		{
				if (!commboCount) {
						commboCount = GetComponent<UILabel> ();
				}
		}
		
		void Start ()
		{
				commboCount.enabled = false;
		}
	
		void Update ()
		{
				if (_StateManager.IsCommboChain ()) {
						commboCount.enabled = true;
						commboCount.text = _ScoreManager.GetCurrentCommboCount () + " Commbo";
				} else {
						commboCount.enabled = false;
				}
		}
}

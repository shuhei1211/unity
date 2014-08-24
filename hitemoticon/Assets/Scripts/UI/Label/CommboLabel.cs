using UnityEngine;
using System.Collections;

/// <summary>
/// Commbo label. コンボラベルクラス
/// </summary>
public class CommboLabel : BaseMonoBehaviour
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
				if (StateManager.Instance.IsCommboChain ()) {
						commboCount.enabled = true;
						commboCount.text = ScoreManager.Instance.GetCurrentCommboCount () + " Commbo";
				} else {
						commboCount.enabled = false;
				}
		}
}

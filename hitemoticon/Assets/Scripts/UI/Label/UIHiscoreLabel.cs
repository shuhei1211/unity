using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

/// <summary>
/// Hiscore label. ハイスコアラベル
/// </summary>
public class UIHiscoreLabel : BaseMonoBehaviour
{
		private UILabel hiscore;
		
		void Start ()
		{
				hiscore = GetComponent<UILabel> ();
				string score = SaveManager.LoadScore ().ToString ();
				if (score == null) {
						byte[] b = Encoding.UTF8.GetBytes ("0");
						NGUITools.Save ("score.txt", b);
						score = "0";
				}
				hiscore.text = "SCORE : " + score;
		}
}

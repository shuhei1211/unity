using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class RankingGrid : BaseMonoBehaviour
{
		private UIGrid grid;
		// Use this for initialization
		void Awake ()
		{
			grid = GetComponent<UIGrid> ();
		}
	
		private void CreateRankingItem (WWW www)
		{
				int rankNumber = 1;
				string json = www.text;
				
				Dictionary<string, object> dic = new Dictionary<string, object> ();
				dic = Json.Deserialize (json) as Dictionary<string, object>;
				
				IList rankingList = (IList)Json.Deserialize (json);
				foreach (IDictionary list in rankingList) {
			
						GameObject go = NGUITools.AddChild (gameObject, (GameObject)Resources.Load ("Prefabs/UI/Label/RankItem"), "RankItem");
			
						UILabel childRankNumber = go.transform.FindChild ("RankNumber").gameObject.GetComponent<UILabel> ();
						UILabel childRankName = go.transform.FindChild ("RankName").gameObject.GetComponent<UILabel> ();
						UILabel childRankScore = go.transform.FindChild ("RankScore").gameObject.GetComponent<UILabel> ();
			
						childRankNumber.text = "" + rankNumber;
						childRankName.text = (string)list [Config.API_FIELD_NAME];
						childRankScore.text = (string)list [Config.API_FIELD_SCORE];
			
						rankNumber++;
				}
				grid.Reposition ();
		}
		
		private void DestroyRankItem ()
		{
				foreach (Transform child in transform) {
						if (child) {
								Destroy (child.gameObject);
						}
				}
		}
}
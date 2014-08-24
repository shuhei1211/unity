using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RegisterButton : BaseMonoBehaviour
{
		private void OnClick ()
		{
				UIInput input = GameObject.Find ("InputField").GetComponent <UIInput> ();
				string score = SaveManager.LoadScore ();
				Dictionary<string, string> dict = new Dictionary<string, string> ();
				dict.Add (Config.API_FIELD_SENDMODE, Config.API_FIELD_SENDMODE_POST);
				dict.Add (Config.API_FIELD_NAME, input.value);
				dict.Add (Config.API_FIELD_SCORE, score);
				ApiManager.Instance.POST (Config.API_POST_URL, dict);
				Destroy (transform.parent.gameObject);
		}
}

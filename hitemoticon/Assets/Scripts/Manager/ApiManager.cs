using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using MiniJSON;

/// API manager. API接続クラス
/// </summary>
public class ApiManager : SingletonMonoBehaviour<ApiManager>
{
		public WWW GET (string url)
		{
				return NGUITools.OpenURL (url);
		}
		
		public WWW POST (string url, Dictionary<string, string> post)
		{
				WWWForm form = new WWWForm ();
				foreach (KeyValuePair<String, String> post_arg in post) {
						form.AddField (post_arg.Key, post_arg.Value);
				}
				return NGUITools.OpenURL (url, form);
		}
		
		public WWW DATA_DELETE ()
		{
				WWWForm form = new WWWForm ();
				form.AddField (Config.API_FIELD_SENDMODE, Config.API_FIELD_SENDMODE_DELETE);
				return NGUITools.OpenURL (Config.API_POST_URL, form);
		}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

/// <summary>
/// プレハブのパスを定数で管理するクラスを作成するスクリプト
/// </summary>
public static class PrefabPathCreator
{
	// 無効な文字を管理する配列
	private static readonly string[] INVALUD_CHARS =
	{
		" ", "!", "\"", "#", "$",
		"%", "&", "\'", "(", ")",
		"-", "=", "^",  "~", "\\",
		"|", "[", "{",  "@", "`",
		"]", "}", ":",  "*", ";",
		"+", "/", "?",  ".", ">",
		",", "<"
	};
	
	private const string ITEM_NAME  = "Tools/Create Prefab Path";           // コマンド
	private const string PATH       = "Assets/Game/Common/PrefabPath.cs";   // ファイルパス
	
	private static readonly string FILENAME                     = Path.GetFileName(PATH);                   // ファイル名(拡張子あり)
	private static readonly string FILENAME_WITHOUT_EXTENSION   = Path.GetFileNameWithoutExtension(PATH);   // ファイル名(拡張子なし)
	
	/// <summary>
	/// プレハブのパスを定数で管理するクラスを作成します
	/// </summary>
	[MenuItem(ITEM_NAME)]
	public static void Create()
	{
		if (!CanCreate())
		{
			return;
		}
		
		CreateScript();
		
		EditorUtility.DisplayDialog(FILENAME, "作成が完了しました", "OK");
	}
	
	/// <summary>
	/// スクリプトを作成します
	/// </summary>
	public static void CreateScript()
	{
		var builder = new StringBuilder();
		
		builder.AppendLine("/// <summary>");
		builder.AppendLine("/// プレハブのパスを定数で管理するクラス");
		builder.AppendLine("/// </summary>");
		builder.AppendLine("public static class PrefabPath");
		builder.AppendLine("{");
		
		foreach (var prefabPath in GetPrefabPaths().Select(c => GetFilenameFromResourcesWithoutExtension(c)))
		{
			builder.Append("\t").AppendFormat(@"public const string {0} = ""{1}"";", RemoveInvalidChars(prefabPath.Replace("/", "_")), prefabPath).AppendLine();
		}
		
		builder.AppendLine("}");
		
		var directoryName = Path.GetDirectoryName(PATH);
		if (!Directory.Exists(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
		
		File.WriteAllText(PATH, builder.ToString(), Encoding.UTF8);
		AssetDatabase.ImportAsset(PATH);
	}
	
	/// <summary>
	/// プレハブのパスを定数で管理するクラスを作成できるかどうかを取得します
	/// </summary>
	[MenuItem(ITEM_NAME, true)]
	public static bool CanCreate()
	{
		return !EditorApplication.isPlaying && !Application.isPlaying && !EditorApplication.isCompiling;
	}
	
	/// <summary>
	/// 無効な文字を削除します
	/// </summary>
	public static string RemoveInvalidChars(string str)
	{
		Array.ForEach(INVALUD_CHARS, c => str = str.Replace(c, string.Empty));
		return str;
	}
	
	/// <summary>
	/// 指定されたパス文字列の Resources フォルダからのファイル名を拡張子を付けずに返します
	/// </summary>
	public static string GetFilenameFromResourcesWithoutExtension(string path)
	{
		path = Regex.Replace(path, @"^.*Resources/", "");
		path = Regex.Replace(path, @"\..*$", "");
		return path;
	}
	
	/// <summary>
	/// Assets フォルダに存在するすべてのプレハブのパスを返します
	/// </summary>
	public static IEnumerable<string> GetPrefabPaths()
	{
		foreach (var resourcesDirectory in Directory.GetDirectories("Assets", "Resources", SearchOption.AllDirectories).Select(c => c.Replace("\\", "/")))
		{
			foreach (var prefabFile in Directory.GetFiles(resourcesDirectory, "*.prefab", SearchOption.AllDirectories).Select(c => c.Replace("\\", "/")))
			{
				yield return prefabFile;
			}
		}
	}
}

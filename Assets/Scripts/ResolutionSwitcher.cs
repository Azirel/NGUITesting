using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[ExecuteInEditMode]
public class ResolutionSwitcher : MonoBehaviour
{
	public KeyCode SwitchResolutionKey = KeyCode.M;
	public UIRoot UIRoot;

	[ContextMenu("SwitchResolutions")]
	public void SwapWidthWithHeight()
	{
		var temp = UIRoot.manualWidth;
		UIRoot.manualWidth = UIRoot.manualHeight;
		UIRoot.manualHeight = temp;
		SetSize(UIRoot.manualWidth == 1080 ? 8 : 7);
	}

	public static void SetSize(int index)
	{
		var gvWndType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.GameView");
		var selectedSizeIndexProp = gvWndType.GetProperty("selectedSizeIndex",
				BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		var gvWnd = UnityEditor.EditorWindow.GetWindow(gvWndType);
		selectedSizeIndexProp.SetValue(gvWnd, index, null);
	}
}

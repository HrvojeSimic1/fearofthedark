using UnityEngine;

public class CustomMouse : MonoBehaviour
{
	[SerializeField] Texture2D texture2D;
	[SerializeField] Vector2 hotspot;
	[SerializeField] CursorMode cursorMode;

	private void Update()
	{
		if (texture2D != null)
		{
			Cursor.SetCursor(texture2D, hotspot, cursorMode);
		}
		else
		{
			Cursor.visible = false;
		}
	}	
}
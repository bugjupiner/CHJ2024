using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class GuiDisplayBox : GuiScript<GuiDisplayBox>
{


	IEnumerator OnAnyClick( IGuiControl control )
	{

		yield return E.Break;
	}

	void OnShow()
	{
	}

	void Update()
	{
	}
}
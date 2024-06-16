using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryInversionScroll : InventoryScript<InventoryInversionScroll>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		Audio.Play("scroll_pickup");
		yield return C.Shapes.Say("Hm, interesting!");
		yield return E.WaitSkip();
		yield return E.WaitSkip();
		yield return C.Shapes.Say(" I don't understand a word!");
		yield return E.Break;
	}

	IEnumerator OnInteractInventory( IInventory thisItem )
	{
		yield return C.Shapes.Say("Hm, interesting!");
		yield return E.WaitSkip();
		yield return E.WaitSkip();
		yield return C.Shapes.Say(" I don't understand a word!");
		yield return E.Break;
	}
}
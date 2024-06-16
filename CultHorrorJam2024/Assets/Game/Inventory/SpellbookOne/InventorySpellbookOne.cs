using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventorySpellbookOne : InventoryScript<InventorySpellbookOne>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		Audio.Play("spellbook_pickup_01");
		yield return C.Shapes.Say("What language is this?");
		yield return C.Shapes.Say("I don't think I can read it.");
		yield return E.Break;
	}
}
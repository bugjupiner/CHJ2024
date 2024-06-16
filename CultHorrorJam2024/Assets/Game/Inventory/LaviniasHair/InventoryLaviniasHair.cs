using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryLaviniasHair : InventoryScript<InventoryLaviniasHair>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		Audio.Play("lavina_hair_cut");
		yield return C.Shapes.Say("For the ritual.");
		yield return E.Break;
	}
}
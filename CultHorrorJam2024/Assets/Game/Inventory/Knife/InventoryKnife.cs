using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryKnife : InventoryScript<InventoryKnife>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		Audio.Play("glass_pickup_01");
		yield return C.Shapes.Say("Sharp!");
		yield return E.Break;
	}
}
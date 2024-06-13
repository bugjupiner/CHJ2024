using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class CharacterOmen : CharacterScript<CharacterOmen>
{


	IEnumerator OnInteract()
	{
		yield return C.WalkToClicked();
		yield return C.Player.FaceRight();
		
		if(!Globals.fireglassActive)
		{
			yield return C.Omen.Say("I SEE IT!");
			yield return E.WaitSkip();
			yield return C.Omen.Say("MY CITY!");
			yield return E.WaitSkip();
			yield return C.Omen.Say(" MY HOME!");
		}
		else
		{
			yield return C.Omen.Say("Vesta... hear me...");
			yield return E.WaitSkip();
			yield return C.Omen.Say("My name is Lavinia, and my people need you.");
			yield return E.WaitSkip();
			yield return C.Omen.Say("The hearths of our city are lit afire each night in your name.");
			yield return E.WaitSkip();
			yield return C.Omen.Say("In hopes that you find our home.");
		}
		
		
		yield return E.Break;
	}

	IEnumerator OnUseInv( IInventory item )
	{
		if(item == I.Knife && !I.LaviniasHair.EverCollected)
		{
			yield return C.WalkToClicked();
			yield return C.Shapes.FaceRight();
		
			if(!Globals.fireglassActive)
			{
				yield return C.Shapes.Say("Way too hot!");
			}
			else
			{
				C.Shapes.AddInventory("LaviniasHair");
				yield return C.Display("Got Lavinia's Hair");
		
				C.Omen.Clickable = false;
			}
		
		}
		yield return E.Break;
	}
}
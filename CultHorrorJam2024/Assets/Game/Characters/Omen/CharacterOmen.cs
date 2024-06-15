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
			Camera.Shake(1f, 3f);
			yield return C.Omen.Say("I SEE IT!");
			yield return E.WaitSkip();
			Camera.Shake(1f, 3f);
			yield return C.Omen.Say("MY CITY!");
			yield return E.WaitSkip();
			Camera.Shake(1f, 3f);
			yield return C.Omen.Say(" MY HOME!");
		}
		else
		{
			if(!Globals.secondFace)
			{
				yield return C.Omen.Say("Vesta... hear me...");
				yield return E.WaitSkip();
				yield return C.Omen.Say("My name is Lavinia, and my people need you.");
				yield return E.WaitSkip();
				yield return C.Omen.Say("The hearths of our city are lit afire each night in your name.");
				yield return E.WaitSkip();
				yield return C.Omen.Say("In hopes that you find our home.");
			}
			else
			{
				yield return C.Omen.Say("You... you will not fool me...");
				yield return E.WaitSkip();
				yield return C.Omen.Say("I know that I am myself...");
				yield return E.WaitSkip();
				yield return C.Omen.Say("Only I can do this...");
				yield return E.WaitSkip();
				yield return C.Omen.Say("Go away...");
			}
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
				Audio.Play("lavina_hair_cut");
				C.Shapes.AddInventory("LaviniasHair");
				yield return C.Display("Got Lavinia's Hair");
			}
		}
		if(item == I.Conception)
		{
			if(Globals.conceptionSense == senses.Hear)
			{
				C.Omen.AnimTalk ="Idle";
				yield return C.Omen.Say("BRING GLORY");
				yield return C.Omen.Say("AND BRING WAR");
				C.Omen.AnimTalk ="Talk";
			}
		}
		yield return E.Break;
	}

	IEnumerator OnLookAt()
	{
		yield return C.Shapes.Say("That woman's on fire!");
		yield return E.Break;
	}
}
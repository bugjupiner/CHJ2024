using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class CharacterShapes : CharacterScript<CharacterShapes>
{
	IEnumerator OnInteract()
	{
		if(Globals.secondFace)
		{
			Globals.SetSecondFace(false);
			yield return E.ConsumeEvent;
			yield break;
		}
		
		if(Globals.jumbled == true)
		{
			Globals.jumbled = false;
			C.Shapes.AnimIdle = "Idle";
			C.Shapes.AnimWalk = "Walk";
			Audio.Stop("player_jumble_01");
			}
		else
		{
			if(Globals.jumbled == false)
			{
				Globals.jumbled = true;
				C.Shapes.AnimIdle = "Jumble";
				C.Shapes.AnimWalk = "Jumble";
				Audio.Play("player_jumble_01");
			}
		}
		
		R.Cells.GetRegion("Bars").Walkable = Globals.jumbled;
		R.Basement.GetRegion("Bars").Walkable = Globals.jumbled;
		yield return E.Break;
	}

	IEnumerator OnLookAt()
	{

		yield return E.Break;
	}

	IEnumerator OnUseInv( IInventory item )
	{
		if (item == I.Conception)
		{
			I.Conception.Active = false;
			if(!G.Conception.Visible) G.Conception.Show();
			else G.Conception.Hide();
			yield return E.ConsumeEvent;
		}
		else if (item == I.SecondFace)
		{
			Audio.Play("second_face_equip");
			Globals.SetSecondFace(true);
			yield return E.ConsumeEvent;
		}
		else if(item == I.Blanket)
		{
			yield return C.Shapes.Say("This belongs to someone else.");
		}
		else if (item == I.DormantSoul)
		{
			yield return C.Shapes.Say("It wants nothing to do with me.");
		}
		else if (item == I.Knife)
		{
			yield return C.Shapes.Say("No blood...");
		}
		else if (item == I.SpellbookOne)
		{
			yield return C.Shapes.Say("What language is this?");
			yield return C.Shapes.Say("I don't think I can read it.");
		}
		else if (item == I.SpellbookTwo)
		{
			yield return C.Shapes.Say("This is written in a REALLY strange language.");
			yield return C.Shapes.Say("I definitely can't read this.");
		}
		else if (item == I.Pamphlet)
		{
			yield return C.Shapes.Say("An invitation to something called The Circle of Vesta.");
			yield return C.Shapes.Say("Looks like this Vesta is some pagan goddess of house fires.");
			yield return C.Shapes.Say("No, wait, they're actually called 'hearths'.");
		}
		else if (item == I.Rubble)
		{
			yield return C.Shapes.Say("Hm...");
			yield return E.WaitSkip();
			yield return C.Shapes.Say("Tastes like rock.");
		}
		else if (item == I.Glass)
		{
			yield return C.Shapes.Say("Why did I get this?");
		}
		else if(item == I.MirrorScroll)
		{
			yield return C.Shapes.Say("The full title is 'Mirrors: Sanctuary for the Soul'");
			yield return C.Shapes.Say("It's describing some resurrection technique where, uh...");
			yield return C.Shapes.Say(" 'A lower-order form trades places with its higher-order reflection.'");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return C.Shapes.Say("Whatever that means.");
		}
		
		yield return E.Break;
	}
}
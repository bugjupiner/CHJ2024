using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class CharacterWorm : CharacterScript<CharacterWorm>
{


	IEnumerator OnInteract()
	{
		yield return C.WalkToClicked();
		if(!C.Shapes.HasInventory("Conception")) // Default
		{
			yield return C.Shapes.Say("Um...");
			yield return C.Worm.Say("Family...");
			yield return E.WaitSkip();
			C.Worm.AnimTalk = "Excited";
			yield return C.Worm.Say("Happy Family!");
			yield return E.WaitSkip();
			C.Worm.AnimTalk = "Talk";
			yield return E.WaitSkip();
			yield return C.Worm.Say(" Not even... a single smile?");
		}
		else // Steps
		{
			if(!C.Shapes.HasInventory("SecondFace") && !Globals.recruitHasSecondFace) // Step One
			{
				C.Worm.AnimTalk = "Excited";
				yield return C.Worm.Say("ONE SMILE! ONE SMILE!");
				yield return C.Worm.Say("Ohhhhhh....");
				yield return E.WaitSkip();
				C.Worm.AnimTalk = "Talk";
				yield return C.Worm.Say("How happy you've made me, Shapes.");
				yield return E.WaitSkip();
				yield return C.Worm.Say("Bring me ..");
				C.Worm.AnimTalk = "Excited";
				yield return C.Worm.Say("Mooooooore");
			}
			else
			{
				if(!Globals.recruitHasSecondFace) // Step Two
				{
					C.Worm.AnimTalk = "Talk";
					yield return C.Worm.Say("CLOSER...");
					yield return E.WaitSkip();
					yield return C.Worm.Say("I SAID....");
					C.Shapes.MoveToBG(Point("Closer"));
					C.Worm.AnimTalk = "Excited";
					yield return C.Worm.Say("YES...");
					yield return E.WaitSkip();
					yield return C.Worm.Say(" YOU'VE MADE ME...");
					yield return E.WaitSkip();
					C.Worm.AnimTalk = "Talk";
					yield return C.Worm.Say("BUT NOT ENOUGH");
					yield return C.Worm.Say("IT'S...");
					yield return E.WaitSkip();
					yield return C.Worm.Say(" IT'S NOT ENOUGH!");
				}
				else // Step Three
				{
					C.Worm.AnimTalk = "Excited";
					yield return C.Worm.Say(" WE !! WE..");
					yield return C.Worm.Say(" FAMILY ... WE'RE..");
		
					 C.Worm.PlayAnimationBG("Die", true);
					yield return C.Worm.Say("WE'RE A ...");
					yield return E.WaitSkip();
					C.Worm.Disable();
		
					Region("WormHole").Walkable = true;
					Prop("DollHead").Clickable = true;
				}
		
			}
		
		}
		yield return E.Break;
	}
}
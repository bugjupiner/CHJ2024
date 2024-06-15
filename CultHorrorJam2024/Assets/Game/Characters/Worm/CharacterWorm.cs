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
		
			Camera.Shake(0.5f, 2f);
			Audio.Play("worm_groan_01");
			yield return C.Worm.Say("Family...");
			yield return E.WaitSkip();
			Camera.Shake(1f, 4f);
			C.Worm.AnimTalk = "Excited";
			Audio.Play("worm_rumble");
			yield return C.Worm.Say("Happy Family!");
			yield return E.WaitSkip();
			C.Worm.AnimTalk = "Talk";
			yield return E.WaitSkip();
			Audio.Play("worm_groan_02");
			yield return C.Worm.Say(" Not even... a single smile?");
		}
		else if(Globals.secondFace)
		{
			Camera.Shake(1f,2f);
			Audio.Play("worm_groan_02");
			yield return C.Worm.Say("Wiiitch...");
			yield return C.Worm.Say("Mooother.....");
			yield return E.WaitSkip();
			Camera.Shake(1f,4f);
			Audio.Play("worm_groan_01");
			yield return C.Worm.Say("Faamily....");
		}
		else // Steps
		{
			if(!C.Shapes.HasInventory("SecondFace") && !Globals.recruitHasSecondFace) // Step One
			{
				Camera.Shake(1f, 4f);
				C.Worm.AnimTalk = "Excited";
				Audio.Play("worm_groan_02");
				yield return C.Worm.Say("ONE SMILE! ONE SMILE!");
				yield return E.WaitSkip();
				C.Worm.AnimTalk = "Talk";
				yield return C.Worm.Say("How happy you've made me, Shapes.");
				yield return E.WaitSkip();
				yield return C.Worm.Say("Bring me ..");
				C.Worm.AnimTalk = "Excited";
				Audio.Play("worm_groan_03");
				Camera.Shake(1f, 4f);
				yield return C.Worm.Say("Mooooooore");
			}
			else
			{
				if(!Globals.recruitHasSecondFace) // Step Two
				{
					C.Worm.AnimTalk = "Talk";
					Audio.Play("worm_groan_02");
					Camera.Shake(0.5f, 2f);
					yield return C.Worm.Say("CLOSER...");
					yield return E.WaitSkip();
					yield return C.Worm.Say("I SAID....");
					Camera.Shake(1f, 1f);
					C.Shapes.MoveToBG(Point("Closer"));
					C.Worm.AnimTalk = "Excited";
					Audio.Play("worm_groan_03");
					yield return C.Worm.Say("YES...");
					yield return E.WaitSkip();
					yield return C.Worm.Say(" YOU'VE MADE SOME SMILES...");
					yield return E.WaitSkip();
					C.Worm.AnimTalk = "Talk";
					yield return C.Worm.Say("BUT NOT ENOUGH");
					yield return C.Worm.Say("IT'S...");
					yield return E.WaitSkip();
					Camera.Shake(1f, 4f);
					Audio.Play("worm_groan_01");
					Audio.Play("worm_rumble");
					C.Worm.AnimTalk = "Excited";
					yield return C.Worm.Say(" IT'S NOT ENOUGH HAPPY!");
				}
				else // Step Three
				{
					Camera.Shake(1.5f, 8f);
					C.Worm.AnimTalk = "Excited";
					Audio.Play("worm_groan_01");
					yield return C.Worm.Say(" WE !! WE..");
					yield return C.Worm.Say(" FAMILY ... WE'RE..");
		
					 C.Worm.PlayAnimationBG("Die", true);
					 Audio.Play("worm_groan_02");
					yield return C.Worm.Say("WE'RE A ...");
					Audio.Play("worm_rumble");
					yield return E.WaitSkip();
					C.Worm.Disable();
		
					Region("WormHole").Walkable = true;
					Prop("DollHead").Clickable = true;
				}
		
			}
		
		}
		yield return E.Break;
	}

	IEnumerator OnUseInv( IInventory item )
	{
		if(item == I.Blanket)
		{
			Camera.Shake(1f, 4f);
			Audio.Play("worm_groan_03");
			yield return C.Worm.Say("Buh Blanket?");
			yield return E.WaitSkip();
			yield return C.Worm.Say("This should...");
			Camera.Shake(0.5f, 2f);
			Audio.Play("worm_groan_01");
			yield return C.Worm.Say("...create a smiiile!");
		}
		if(item == I.SecondFace)
		{
			Camera.Shake(1f, 4f);
			Audio.Play("worm_groan_01");
			yield return C.Worm.Say("Smiiile... I liike a smiiile...");
		}
		if(item == I.Conception)
		{
			if(Globals.conceptionSense == senses.Hear)
			{
				yield return C.Worm.Say("Mother... I feeeel it...");
				yield return C.Worm.Say("I feeel family....");
				yield return C.Worm.Say("They're..... broken... they ...");
				yield return C.Worm.Say("They ...");
				Camera.Shake(1f, 4f);
				yield return C.Worm.Say("ooooughhh.....");
			}
		}
		yield return E.Break;
	}

	IEnumerator OnLookAt()
	{
		yield return C.Shapes.Say("I... don't know what that is...");
		yield return E.Break;
	}
}
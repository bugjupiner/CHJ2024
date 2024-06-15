using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class CharacterRecruit : CharacterScript<CharacterRecruit>
{


	IEnumerator OnInteract()
	{
		yield return C.WalkToClicked();
		yield return C.Player.FaceLeft();
		
		if(Globals.recruitHasSecondFace) // Get Second Face Back
		{
			yield return C.Shapes.Say("Yoink!");
			Globals.recruitHasSecondFace = false;
			C.Shapes.AddInventory("SecondFace");
			yield return C.Display("Got Second Face");
		
			if(Globals.recruitHasKnife)
			{
				C.Recruit.AnimIdle = "Idle";
				C.Recruit.AnimTalk = "Talk";
			}
			else
			{
				C.Recruit.AnimIdle = "AltIdle";
				C.Recruit.AnimTalk = "AltTalk";
			}
		
			Audio.Play("recruit_talk");
			yield return C.Recruit.Say("Huh? Wuh?");
			yield return E.WaitSkip();
			yield return C.Recruit.Say("What happened?");
			yield break;
		}
		
		if(!Globals.secondFace) // Default
		{
			Audio.Play("recruit_talk");
			yield return C.Recruit.Say("GET AWAY FROM ME!!!");
			if(Globals.recruitHasKnife)
			{
				//C.Shapes.AnimIdle = "IdleR";
				C.Recruit.PlayAnimationBG("StabR");
				yield return C.Shapes.MoveTo(Point("BackAway"));
			}
		}
		
		else // Wearing Second Face
		{
			if(Globals.recruitHasKnife) // Before Giving Knife Away
			{
				Audio.Play("recruit_talk");
				yield return C.Recruit.Say("H-h-high witch ...");
				yield return E.WaitSkip();
				yield return C.Recruit.Say(" M-m-my warmth and p-purity...");
				yield return C.Recruit.Say("How — happy I am youre' back.");
				yield return E.WaitSkip();
				Audio.Play("recruit_talk");
				yield return C.Recruit.Say("Oh, um, you must want this back.");
		
				C.Shapes.AddInventory("Knife");
				yield return C.Display("Got Knife");
		
				Globals.recruitHasKnife = false;
				C.Recruit.AnimIdle = "AltIdle";
				C.Recruit.AnimTalk = "AltTalk";
		
				Audio.Play("recruit_talk");
				yield return C.Recruit.Say("I was protecting myself from the others.");
				yield return C.Recruit.Say("They're, uh, different now.");
			}
			else // After Giving Knife Away
			{
				Audio.Play("recruit_talk");
				yield return C.Recruit.Say("High Witch, I'm sorry about —");
				yield return C.Recruit.Say("Well, you know.");
				yield return E.WaitSkip();
				yield return C.Recruit.Say("Maybe if... if I was closer to you all...");
				yield return E.WaitSkip();
				Audio.Play("recruit_talk");
				yield return C.Recruit.Say("No... no.");
			}
		
		
		}
		
		yield return E.Break;
	}

	IEnumerator OnUseInv( IInventory item )
	{
		if(item == I.Pamphlet)
		{
			yield return C.WalkToClicked();
			yield return C.Shapes.FaceLeft();
		
			Audio.Play("recruit_talk");
			if(Globals.recruitHasKnife) C.Recruit.AnimTalk = "Stab";
			yield return C.Recruit.Say("Please no more—");
			C.Recruit.AnimTalk = "Talk";
			yield return C.Recruit.Say("Oh, what fresh hell is this?");
			yield return E.WaitSkip();
			yield return C.Recruit.Say("You… you must be here to chastise me.");
			yield return E.WaitSkip();
			Audio.Play("recruit_talk");
			yield return C.Recruit.Say("I swear I didn't know!");
			yield return C.Recruit.Say("Nobody knew!");
			if(Globals.recruitHasKnife) C.Recruit.PlayAnimation("Stab");
			Audio.Play("recruit_talk");
			yield return C.Recruit.Say("Punish the WITCH, not me!");
		}
		else if (item == I.SecondFace)
		{
			yield return C.WalkToClicked();
			yield return C.Shapes.FaceLeft();
		
			I.SecondFace.Active = false;
			C.Shapes.RemoveInventory("SecondFace");
		
			C.Recruit.AnimIdle = "SecondFace";
			C.Recruit.AnimTalk = "SecondFace";
			yield return C.Display("Lost Second Face");
			yield return E.WaitSkip();
			yield return C.Shapes.Say("Happy now?");
			yield return C.Recruit.Say("...");
		
			Globals.recruitHasSecondFace = true;
		}
		else if (item == I.Knife)
		{
			if(!Globals.recruitHasSecondFace)
			{
				if(Globals.secondFace)
				{
					Audio.Play("recruit_ow");
					yield return C.Recruit.Say("Ah!");
					yield return E.WaitSkip();
					yield return C.Recruit.Say("Thank you, I pray my blood is worthy.");
				}
				else
				{
					Audio.Play("recruit_ow");
					yield return C.Recruit.Say("Ow!");
				}
			}
		
			if(!I.VirginsBlood.EverCollected)
			{
				yield return C.Display("Got Virgin's Blood");
				C.Shapes.AddInventory("VirginsBlood");
			}
		}
		if(item == I.Blanket)
		{
			Audio.Play("recruit_talk");
			yield return C.Recruit.Say("Uh... I shouldn't take this...");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return C.Recruit.Say("It, um, belongs to someone else.");
		}
		if(item == I.Conception)
		{
			if(Globals.conceptionSense == senses.Hear)
			{
				if(Globals.recruitHasKnife) C.Recruit.AnimTalk = "Idle";
				else C.Recruit.AnimTalk = "AltIdle";
		
				yield return C.Recruit.Say("How did it go so wrong... HOW?");
				yield return C.Recruit.Say("She's supposed— supposed to know it all...");
				yield return E.WaitSkip();
				yield return C.Recruit.Say("D-did she know the others would...");
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				yield return C.Recruit.Say("Did she think I would—NO");
				yield return C.Recruit.Say("NO! I haven't I won't!");
		
				yield return C.Recruit.PlayAnimation("Stab");
				yield return C.Recruit.Say("I WON'T");
		
				if(Globals.recruitHasKnife) C.Recruit.AnimTalk = "Talk";
				else C.Recruit.AnimTalk = "AltTalk";
			}
		}
		if(item == I.Rubble)
		{
			Audio.Play("recruit_talk");
			yield return C.Recruit.Say("HEY! BACK OFF!");
			if(Globals.recruitHasKnife) C.Recruit.PlayAnimationBG("Stab");
			yield return C.Recruit.Say("You can't be swinging heavy stuff around like that!");
			yield return E.WaitSkip();
			yield return C.Recruit.Say("You could break something!");
			Audio.Play("recruit_talk");
			if(Globals.recruitHasKnife) C.Recruit.PlayAnimationBG("Stab");
			yield return C.Recruit.Say("T-this place is SACRED!");
		
		}
		if(item == I.DormantSoul || item == I.FacelessSoul)
		{
			Audio.Play("recruit_talk");
			yield return C.Recruit.Say("No... it can't be... that's..");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return C.Recruit.Say("I can't look —");
			Audio.Play("recruit_talk");
			yield return C.Recruit.Say("GO AWAY!");
			if(Globals.recruitHasKnife) C.Recruit.PlayAnimationBG("Stab");
		}
		if(item == I.DollHead || item == I.DollBody || item == I.Doll)
		{
			yield return C.Recruit.Say("The High Witch's doll...");
			yield return E.WaitSkip();
			yield return C.Recruit.Say("Are... are you planning...");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return C.Recruit.Say("...On starting a fire?");
		}
		yield return E.Break;
	}

	IEnumerator OnLookAt()
	{
		yield return C.Shapes.Say("Weird lookin' fella");
		yield return E.Break;
	}
}
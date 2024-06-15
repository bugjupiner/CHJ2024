using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomRitualSite : RoomScript<RoomRitualSite>
{
	AudioHandle smallFireHandle;
	AudioHandle bigFireHandle;

	void OnEnterRoom()
	{
		if(R.Previous == R.Pathway)
		{
			C.Player.Position = R.Current.GetHotspot("Pathway").WalkToPoint;
		}
		
		if(Globals.hearthSummoned)  bigFireHandle = Audio.Play("big_fire_loop");
		else smallFireHandle = Audio.Play("small_fire_loop");
		
	}

	IEnumerator OnInteractHotspotPathway( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.Pathway;
		yield return E.Break;
	}

	IEnumerator OnUseInvPropSmallFire( IProp prop, IInventory item )
	{
		yield return C.WalkToClicked();
		yield return C.Shapes.FaceRight();
		
		if(item == I.Doll)
		{
			Audio.Play("fire_burn_item");
			E.FadeColor = Color.red;
			yield return E.FadeOut(0.1f);
			E.FadeColor = Color.red;
			yield return E.FadeIn(0.3f);
		
			I.Doll.Active = false;
			C.Shapes.RemoveInventory("Doll");
		
			yield return C.Display("Doll Sacrificed");
			Globals.dollSacrificed = true;
		}
		if(item == I.VirginsBlood)
		{
			Audio.Play("fire_burn_item");
			E.FadeColor = Color.red;
			yield return E.FadeOut(0.1f);
			E.FadeColor = Color.red;
			yield return E.FadeIn(0.3f);
		
			I.VirginsBlood.Active = false;
			C.Shapes.RemoveInventory("VirginsBlood");
		
			yield return C.Display("Virgin's Blood Sacrificed");
			Globals.virginBloodSacrificed = true;
		}
		if(Globals.dollSacrificed && Globals.virginBloodSacrificed && !Globals.hearthSummoned)
		{
			Audio.Stop(smallFireHandle);
			Audio.Play("fire_whoosh");
			bigFireHandle = Audio.Play("big_fire_loop");
		
			Globals.hearthSummoned = true;
		
			Prop("SmallFire").Disable();
			Prop("Fire").Enable();
			yield return C.Shapes.Say("Whoa!");
		}
		yield return E.Break;
	}

	IEnumerator OnInteractPropSmallFire( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return C.Shapes.Say("It's a little fire.");
		yield return E.Break;
	}

	IEnumerator OnLookAtPropSmallFire( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return C.Shapes.Say("It's a little fire.");
		yield return E.Break;
	}

	IEnumerator OnLookAtPropFire( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return C.Shapes.Say("Hot!");
		yield return E.Break;
	}

	IEnumerator OnInteractPropFire( IProp prop )
	{
		if(Globals.angelBloodSacrificed && (Globals.laviniasHairSacrificed || Globals.godBileSacrificed)) // Endings
		{
			//Globals.SwitchMirrorState();
			yield return C.Shapes.WalkTo(Point("FinalPoint"));
			yield return C.Shapes.Say("I'm...");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return C.Shapes.Say("I'm so cold");
			C.Shapes.PlayAnimationBG("Jumble");
			yield return C.Shapes.Say("What's happening?");
			yield return E.WaitSkip();
			yield return C.Shapes.Say("I'm... uhh...");
			yield return E.WaitSkip();
			E.FadeColor = Color.white;
			E.FadeOutBG(4.5f);
			yield return C.Shapes.PlayAnimation("Transform");
			yield return E.WaitSkip();
			E.FadeColor = Color.white;
			E.FadeInBG(4.5f);
		
			if(Globals.laviniasHairSacrificed)
			{
				if(!Globals.mirrored) // Hearth Ritual
				{
					C.Vesta.Visible = true;
					C.Vesta.Clickable = true;
		
					yield return C.Vesta.Say("OH, CASINA.");
					yield return C.Vesta.Say("HOW FAR YOU'VE FALLEN.");
					yield return E.WaitSkip();
					yield return C.Shapes.Say("Huh?");
					yield return C.Shapes.Say("Excuse me, are you Vesta?");
					yield return E.WaitSkip();
					yield return C.Vesta.Say("YOU DO NOT KNOW ME?");
					yield return E.WaitSkip();
					yield return C.Vesta.Say("WHAT CRUEL IRONY.");
					yield return E.WaitSkip();
					yield return C.Shapes.Say("Well, I was wondering if you could help.");
					yield return C.Shapes.Say("I... I think I'm lost. I need to go home.");
					yield return E.WaitSkip();
					yield return C.Vesta.Say("THIS IS YOUR HOME.");
					yield return C.Vesta.Say("THIS HEARTH, IT BELONGS TO YOU.");
					yield return E.WaitSkip();
					yield return C.Vesta.Say("IN A DIFFERENT FORM, YOU TRIED TO TAKE ME.");
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return C.Vesta.Say("INSTEAD, YOU LOST EVERYTHING.");
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return C.Shapes.Say("I... I don't understand.");
					yield return C.Vesta.Say("YOU NEVER WILL. YOU'VE CHANGED.");
					yield return C.Vesta.Say("YOU'VE BEEN REDUCED TO BASIC FORMS.");
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return C.Vesta.Say("IT'S... FUNNY.");
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return C.Shapes.Say("Funny?");
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return C.Shapes.Say("Watch this.");
					C.Shapes.PlayAnimationBG("Jumble");
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return C.Vesta.Say("HAHAHA");
					yield return E.FadeOut(3f);
					E.Pause();
				}
				else // Mirrored Hearth Ritual
				{
					Globals.SwitchMirrorState();
					C.Vesta.Visible = true;
					C.Vesta.Clickable = true;
		
					C.Shapes.AnimIdle = "CasinaIdle";
					C.Shapes.AnimTalk = "CasinaTalk";
		
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return C.Shapes.Say("Interesting.");
					yield return E.WaitSkip();
					yield return C.Shapes.Say("Not what I expected.");
					yield return C.Vesta.Say("FOOL. WHAT WERE YOU EXPECTING.");
					yield return E.WaitSkip();
					yield return C.Shapes.Say("Hello Vesta.");
					yield return E.WaitSkip();
					yield return C.Vesta.Say("CASINA.");
					yield return C.Vesta.Say("YOU WILL PAY YOUR OVERDUE RESPECT,");
					yield return C.Vesta.Say("AND LOOK AT ME WHILE YOU BURN.");
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return C.Shapes.Say("No. I don't think I will.");
					yield return C.Vesta.Say("WHAT?");
					yield return E.WaitSkip();
					yield return C.Shapes.Say("I've learned a lot about myself today.");
					yield return E.WaitSkip();
					yield return C.Shapes.Say("Namely, that at my very essence...");
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return C.Shapes.Say("I don't want your power.");
					yield return E.WaitSkip();
					yield return C.Shapes.Say("And I don't want you dead.");
					yield return E.WaitSkip();
					yield return C.Vesta.Say("SO WHAT DO YOU WANT?");
					yield return C.Vesta.Say("WHAT WAS THE POINT OF ALL THIS MADNESS.");
					E.FadeOutBG(5f);
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return C.Shapes.Say("Got any Marshmallows?");
					E.Pause();
				}
			}
		
			if(Globals.godBileSacrificed)
			{
				if(!Globals.mirrored) // Inverted Ritual
				{
					C.Vesta.Visible = true;
					C.Vesta.Clickable = true;
		
					C.Shapes.AnimIdle = "HouseIdle";
					C.Shapes.AnimTalk = "HouseIdle";
		
					yield return C.Vesta.Say("OH, CASINA.");
					yield return C.Vesta.Say("HOW FAR YOU'VE FALLEN.");
					yield return E.WaitSkip();
					yield return C.Shapes.Say("What? What's going on?");
					yield return E.WaitSkip();
					yield return C.Shapes.Say("I can't see...");
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return C.Vesta.Say("ARE YOU CLUELESS?");
					yield return E.WaitSkip();
					yield return C.Vesta.Say("OF COURSE YOU ARE. YOU FOOL.");
					yield return E.WaitSkip();
					yield return C.Shapes.Say("Don't....");
					yield return C.Shapes.Say("Don't be so mean—");
					yield return C.Vesta.Say("MEAN? COMING FROM THE TORTURER?");
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return C.Shapes.Say("Torturer?");
					yield return C.Vesta.Say("YES, CASINA, YOU WERE A CRUEL CREATURE.");
					yield return E.WaitSkip();
					yield return C.Vesta.Say("BUT NOW YOUR EVIL NATURE WILL REMAIN EVISCERATED.");
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return C.Shapes.Say("Can you just tell me what's going on?");
					yield return C.Shapes.Say("Why am I a house?");
					yield return C.Shapes.Say("Change me back!");
					yield return E.WaitSkip();
					yield return C.Vesta.Say("I ALMOST FEEL SORRY FOR YOU");
					yield return C.Vesta.Say("MY DEVOUT FOLLOWER, I DID NOT CHANGE YOU");
					yield return E.WaitSkip();
					yield return C.Vesta.Say("YOU CHANGED YOURSELF.");
					yield return E.WaitSkip();
					yield return C.Vesta.Say("FIRST, INTO THOSE SHAPES. AND NOW, INTO...");
					yield return E.WaitSkip();
					yield return C.Vesta.Say("THIS.");
					yield return C.Shapes.Say("How? What?");
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return C.Shapes.Say("Please, just change me back!!!");
					yield return E.WaitSkip();
					yield return C.Vesta.Say("TWICE NOW YOU HAVE MADE THE EFFORT TO BE MY HOME.");
					yield return C.Vesta.Say("BE CAREFUL WHAT YOU WISH FOR.");
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					E.FadeOutBG(5f);
					yield return C.Shapes.Say("No...");
					yield return E.WaitSkip();
					yield return C.Shapes.Say("No... change me back...");
					yield return C.Shapes.Say("CHANGE ME BACK!");
					E.Pause();
				}
				else // Mirrored Inverted Ritual
				{
					Globals.SwitchMirrorState();
					C.Shapes.AnimIdle = "CasinaIdle";
					C.Shapes.AnimTalk = "CasinaTalk";
		
					C.Shapes.Position = Point("CasinaRise");
		
					Prop("Fire").Disable();
					C.Shapes.Instance.GetComponentInChildren<ParticleSystem>().Play();
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return C.Shapes.Say("Hehehe...");
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return C.Shapes.Say("HAHAHAHA....");
					yield return E.WaitSkip();
					yield return C.Shapes.Say("I feel her... Vesta...");
					yield return C.Shapes.Say("Her power is mine!");
					yield return E.WaitSkip();
					yield return C.Shapes.Say("Goddess of Hearth and Home,");
					yield return E.WaitSkip();
					yield return C.Shapes.Say("My warmth and purity,");
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return C.Shapes.Say("Mine.");
					yield return E.WaitSkip();
					yield return C.Shapes.Say("HAHAHAHA");
					yield return C.Shapes.Say("NOT EVEN TOTAL DESTRUCTION COULD STOP ME");
					yield return C.Shapes.Say("MY WILL IS THAT OF THE UNIVERSE");
					yield return C.Shapes.Say("THE POWER OF A GOD WAS NEVER HER'S");
					yield return E.WaitSkip(1.0f);
					yield return C.Shapes.Say("IT WAS MINE!!");
					E.FadeOutBG(4.5f);
					yield return E.WaitSkip();
					yield return C.Shapes.Say("AHA, HAHAHA");
					yield return E.WaitSkip();
					yield return E.WaitSkip();
					yield return C.Shapes.Say("MINE!");
					E.Pause();
				}
			}
		
		
		}
		else // Default
		{
			yield return C.WalkToClicked();
			yield return C.FaceClicked();
			yield return C.Shapes.Say("Hot!");
		}
		yield return E.Break;
	}

	IEnumerator OnLookAtPropInversionScroll( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		if(!Globals.fireglassActive)
		{
			yield return C.Shapes.Say("Completely Burnt.");
		}
		else
		{
			yield return C.Shapes.Say("It's some kind of scroll!");
		}
		
		yield return E.Break;
	}

	IEnumerator OnInteractPropInversionScroll( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		if(!Globals.fireglassActive)
		{
			yield return C.Shapes.Say("Completely Burnt.");
		}
		else
		{
			Audio.Play("scroll_pickup");
			yield return C.Display("Got Inversion Scroll");
			C.Shapes.AddInventory("InversionScroll");
		
			Prop("BurntScroll").Disable();
			Prop("InversionScroll").Disable();
		}
		yield return E.Break;
	}

	IEnumerator OnUseInvPropFire( IProp prop, IInventory item )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		if(item == I.Glass) // Get Fireglass
		{
			Audio.Play("fire_burn_item");
			I.Glass.Active = false;
			C.Shapes.RemoveInventory("Glass");
			yield return C.Display("Lost Glass");
		
			E.FadeColor = Color.white;
			yield return E.FadeOut(0.1f);
			E.FadeColor = Color.white;
			yield return E.FadeIn(0.3f);
		
			C.Shapes.AddInventory("Fireglass");
			yield return C.Display("Got Fireglass");
		
		}
		if(item == I.AngelsBlood) // Start Final Ritual
		{
			Audio.Play("fire_burn_item");
			E.FadeColor = Color.yellow;
			yield return E.FadeOut(0.1f);
			E.FadeColor = Color.yellow;
			yield return E.FadeIn(0.3f);
		
			I.AngelsBlood.Active = false;
			C.Shapes.RemoveInventory("AngelsBlood");
			yield return C.Display("Sacrificed Angel's Blood");
		
			Globals.angelBloodSacrificed = true;
		}
		
		if(item == I.LaviniasHair) // Initiate Hearth Ritual
		{
			if(Globals.godBileSacrificed && !Globals.ritualWarning)
			{
				yield return C.Display("Warning: Sacrifcing this will change the ritual you already started.");
				Globals.ritualWarning = true;
			}
			else
			{
				Audio.Play("fire_burn_item");
				E.FadeColor = Color.red;
				yield return E.FadeOut(0.1f);
				E.FadeColor = Color.red;
				yield return E.FadeIn(0.3f);
		
				I.LaviniasHair.Active = false;
				C.Shapes.RemoveInventory("LaviniasHair");
				yield return C.Display("Sacrificed Lavinia's Hair");
		
				if(Globals.godBileSacrificed) Globals.godBileSacrificed = false;
				Globals.laviniasHairSacrificed = true;
			}
		}
		
		if(item == I.GodBile) // Initiate Inverted Ritual
		{
			if(Globals.laviniasHairSacrificed && !Globals.ritualWarning)
			{
				yield return C.Display("Warning: Sacrifcing this will change the ritual you already started.");
				Globals.ritualWarning = true;
			}
			else
			{
				Audio.Play("fire_burn_item");
				E.FadeColor = Color.green;
				yield return E.FadeOut(0.1f);
				E.FadeColor = Color.green;
				yield return E.FadeIn(0.3f);
		
				I.GodBile.Active = false;
				C.Shapes.RemoveInventory("GodBile");
				yield return C.Display("Sacrificed God Bile");
		
				if(Globals.laviniasHairSacrificed) Globals.laviniasHairSacrificed = false;
				Globals.godBileSacrificed = true;
			}
		}
		
		if(Globals.angelBloodSacrificed && (Globals.laviniasHairSacrificed || Globals.godBileSacrificed)) // Hint
		{
			Audio.Play("fire_whoosh");
			yield return E.WaitSkip();
			yield return C.Shapes.Say("The fire... something is happening!");
		}
		
		
		yield return E.Break;
	}

	IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{
		if(Globals.hearthSummoned)  Audio.Stop(bigFireHandle);
		else Audio.Stop(smallFireHandle);
		yield return E.Break;
	}
}
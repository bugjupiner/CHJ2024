using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomPathway : RoomScript<RoomPathway>
{


	void OnEnterRoom()
	{
		if(R.Previous == R.CloisterStart)
		{
			C.Player.Position = R.Current.GetHotspot("CloisterStart").WalkToPoint;
		}
		else if(R.Previous == R.RitualSite)
		{
			C.Player.Position = R.Current.GetHotspot("RitualSite").WalkToPoint;
		}
		
		if(Globals.wizardSpellBroken && Prop("SpellBubble").Visible)
		{
			Prop("SpellBubble").Visible = true;
			Prop("SpellBubble").Disable();
			Region("SpellBlocker").Walkable = true;
		
			Prop("SpellbookTwo").Clickable = true;
		}
		
		if(Globals.hearthSummoned && !I.Glass.EverCollected)
		{
			Prop("FireParticles").Instance.transform.GetChild(0).gameObject.SetActive(true);
		}
	}

	IEnumerator OnInteractHotspotRitualSite( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		if(C.Player.TargetPosition == Hotspot("RitualSite").WalkToPoint) C.Player.Room = R.RitualSite;
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotCloisterStart( IHotspot hotspot )
	{
		yield return C.WalkToClicked();
		C.Player.Room = R.CloisterStart;
		yield return E.Break;
	}

	IEnumerator OnInteractPropSpellbookTwo( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		Audio.Play("spellbook_pickup_01");
		yield return C.Display("Got Spellbook Volume Two");
		C.Shapes.AddInventory("SpellbookTwo");
		Prop("SpellbookTwo").Disable();
		yield return E.Break;
	}

	IEnumerator OnInteractPropSpellBubble( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.Shapes.Say("Magic!");
		yield return E.Break;
	}

	IEnumerator OnLookAtPropSpellbookTwo( IProp prop )
	{
		yield return C.Shapes.Say("This book seems different than the other.");
		yield return E.Break;
	}

	IEnumerator OnLookAtPropSpellBubble( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.Shapes.Say("Magic!");
		yield return E.Break;
	}

	IEnumerator OnEnterRegionSpellBlocker( IRegion region, ICharacter character )
	{

		yield return E.Break;
	}

	IEnumerator OnUseInvPropSpellbookTwo( IProp prop, IInventory item )
	{

		yield return E.Break;
	}

	IEnumerator OnUseInvPropSpellBubble( IProp prop, IInventory item )
	{

		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotCloisterStart( IHotspot hotspot )
	{
		yield return C.Shapes.Say("Maybe I should go.");
		yield return E.Break;
	}

	IEnumerator OnLookAtHotspotRitualSite( IHotspot hotspot )
	{
		yield return C.Shapes.Say("I think I see the hearth...");
		yield return E.Break;
	}
}
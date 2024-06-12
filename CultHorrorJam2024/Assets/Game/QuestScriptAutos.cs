using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PowerTools.Quest;

namespace PowerScript
{	
	// Shortcut access to SystemAudio.Get
	public class Audio : SystemAudio
	{
	}

	public static partial class C
	{
		// Access to specific characters (Auto-generated)
		public static ICharacter Shapes         { get { return PowerQuest.Get.GetCharacter("Shapes"); } }
		public static ICharacter Angel          { get { return PowerQuest.Get.GetCharacter("Angel"); } }
		public static ICharacter Recruit        { get { return PowerQuest.Get.GetCharacter("Recruit"); } }
		public static ICharacter Worm           { get { return PowerQuest.Get.GetCharacter("Worm"); } }
		public static ICharacter Finger         { get { return PowerQuest.Get.GetCharacter("Finger"); } }
		public static ICharacter Wizard         { get { return PowerQuest.Get.GetCharacter("Wizard"); } }
		public static ICharacter Omen           { get { return PowerQuest.Get.GetCharacter("Omen"); } }
		public static ICharacter Shadow         { get { return PowerQuest.Get.GetCharacter("Shadow"); } }
		// #CHARS# - Do not edit this line, it's used by the system to insert characters
	}

	public static partial class I
	{		
		// Access to specific Inventory (Auto-generated)
		public static IInventory Pamphlet         { get { return PowerQuest.Get.GetInventory("Pamphlet"); } }
		public static IInventory SpellbookOne   { get { return PowerQuest.Get.GetInventory("SpellbookOne"); } }
		public static IInventory DormantSoul    { get { return PowerQuest.Get.GetInventory("DormantSoul"); } }
		public static IInventory Blanket        { get { return PowerQuest.Get.GetInventory("Blanket"); } }
		public static IInventory Conception     { get { return PowerQuest.Get.GetInventory("Conception"); } }
		public static IInventory Knife          { get { return PowerQuest.Get.GetInventory("Knife"); } }
		public static IInventory Fireglass      { get { return PowerQuest.Get.GetInventory("Fireglass"); } }
		public static IInventory SpellbookTwo   { get { return PowerQuest.Get.GetInventory("SpellbookTwo"); } }
		public static IInventory Rubble         { get { return PowerQuest.Get.GetInventory("Rubble"); } }
		public static IInventory Glass          { get { return PowerQuest.Get.GetInventory("Glass"); } }
		// #INVENTORY# - Do not edit this line, it's used by the system to insert rooms for easy access
	}

	public static partial class G
	{
		// Access to specific gui (Auto-generated)
		public static IGui DialogTree     { get { return PowerQuest.Get.GetGui("DialogTree"); } }
		public static IGui SpeechBox      { get { return PowerQuest.Get.GetGui("SpeechBox"); } }
		public static IGui HoverText  { get { return PowerQuest.Get.GetGui("HoverText"); } }
		public static IGui DisplayBox    { get { return PowerQuest.Get.GetGui("DisplayBox"); } }
		public static IGui Prompt         { get { return PowerQuest.Get.GetGui("Prompt"); } }
		public static IGui Toolbar          { get { return PowerQuest.Get.GetGui("Toolbar"); } }
		public static IGui InventoryBar   { get { return PowerQuest.Get.GetGui("InventoryBar"); } }
		public static IGui Options        { get { return PowerQuest.Get.GetGui("Options"); } }
		public static IGui Save           { get { return PowerQuest.Get.GetGui("Save"); } }
		public static IGui Conception     { get { return PowerQuest.Get.GetGui("Conception"); } }
		// #GUI# - Do not edit this line, it's used by the system to insert rooms for easy access
	}

	public static partial class R
	{
		// Access to specific room (Auto-generated)
		public static IRoom Title          { get { return PowerQuest.Get.GetRoom("Title"); } }
		public static IRoom Forest         { get { return PowerQuest.Get.GetRoom("Forest"); } }
		public static IRoom Cells          { get { return PowerQuest.Get.GetRoom("Cells"); } }
		public static IRoom Basement       { get { return PowerQuest.Get.GetRoom("Basement"); } }
		public static IRoom Fork           { get { return PowerQuest.Get.GetRoom("Fork"); } }
		public static IRoom Storeroom      { get { return PowerQuest.Get.GetRoom("Storeroom"); } }
		public static IRoom Cliff          { get { return PowerQuest.Get.GetRoom("Cliff"); } }
		public static IRoom Ladder         { get { return PowerQuest.Get.GetRoom("Ladder"); } }
		public static IRoom Yard           { get { return PowerQuest.Get.GetRoom("Yard"); } }
		public static IRoom Kitchen        { get { return PowerQuest.Get.GetRoom("Kitchen"); } }
		public static IRoom Dorm           { get { return PowerQuest.Get.GetRoom("Dorm"); } }
		public static IRoom Front          { get { return PowerQuest.Get.GetRoom("Front"); } }
		public static IRoom Landing        { get { return PowerQuest.Get.GetRoom("Landing"); } }
		public static IRoom Entryway       { get { return PowerQuest.Get.GetRoom("Entryway"); } }
		public static IRoom CloisterStart  { get { return PowerQuest.Get.GetRoom("CloisterStart"); } }
		public static IRoom Cloister       { get { return PowerQuest.Get.GetRoom("Cloister"); } }
		public static IRoom CloisterEnd    { get { return PowerQuest.Get.GetRoom("CloisterEnd"); } }
		public static IRoom Stairwell      { get { return PowerQuest.Get.GetRoom("Stairwell"); } }
		public static IRoom Pathway        { get { return PowerQuest.Get.GetRoom("Pathway"); } }
		public static IRoom RitualSite     { get { return PowerQuest.Get.GetRoom("RitualSite"); } }
		public static IRoom Bedroom        { get { return PowerQuest.Get.GetRoom("Bedroom"); } }
		public static IRoom HiddenRoom     { get { return PowerQuest.Get.GetRoom("HiddenRoom"); } }
		// #ROOM# - Do not edit this line, it's used by the system to insert rooms for easy access
	}

	// Dialog
	public static partial class D
	{
		// Access to specific dialog trees (Auto-generated)
		// #DIALOG# - Do not edit this line, it's used by the system to insert rooms for easy access	    	    
	}


}

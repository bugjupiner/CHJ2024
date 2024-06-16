using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomEndScreen : RoomScript<RoomEndScreen>
{


	void OnEnterRoom()
	{
		G.InventoryBar.Hide();
		
		if(Globals.endingIndex == 0)
		{
			Prop("EndingText").Instance.GetComponentInChildren<QuestText>().text = "JUMBLED ENDING";
		}
		else if(Globals.endingIndex == 1)
		{
			Prop("EndingText").Instance.GetComponentInChildren<QuestText>().text = "HIGH WITCH ENDING";
		}
		else if(Globals.endingIndex == 2)
		{
			Prop("EndingText").Instance.GetComponentInChildren<QuestText>().text = "HOUSE ENDING";
		}
		else if(Globals.endingIndex == 2)
		{
			Prop("EndingText").Instance.GetComponentInChildren<QuestText>().text = "GODDESS ENDING";
		}
		
	}

	IEnumerator OnEnterRoomAfterFade()
	{
		yield return E.FadeIn(2f);
		
		// Fade in fire prop
		Prop("Fire").Visible = true;
		yield return Prop("Fire").Fade(0,1,1.0f);
		
		// Wait a moment
		yield return E.Wait(0.5f);
		
		// Fade in title prop
		Prop("EndingText").Visible = true;
		yield return Prop("EndingText").Fade(0,1,1.0f);
		
		// Wait a moment
		yield return E.Wait(2.5f);
		
		// Fade in menu & credits prop
		Prop("MainMenu").Enable();
		yield return Prop("MainMenu").Fade(0,1,1.0f);
		
		Prop("Credits").Enable();
		yield return Prop("Credits").Fade(0,1,1.0f);
		
		
		yield return E.Break;
	}

	IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{

		yield return E.Break;
	}

	IEnumerator UpdateBlocking()
	{

		yield return E.Break;
	}

	IEnumerator OnInteractPropCredits( IProp prop )
	{
		if(!G.Credits.Visible)
		{
			Audio.Play("ui_click");
			G.Credits.Show();
			Prop("Credits").Clickable = false;
			Prop("MainMenu").Clickable = false;
		}
		yield return E.ConsumeEvent;
		yield return E.Break;
	}

	IEnumerator OnInteractPropMainMenu( IProp prop )
	{
		Audio.Stop("cutscene_01_loop");
		Audio.Play("wizard_spell_broken");
		
		E.ChangeRoomBG(R.Title);
		yield return E.Break;
	}
}
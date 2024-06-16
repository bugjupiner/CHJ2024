using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class GuiConception : GuiScript<GuiConception>
{ 

	IEnumerator OnClickBtnRight( IGuiControl control )
	{
		Globals.conceptionSense = Globals.GetNextConceptionSense(0);
		Globals.PlayConceptionSenseSound(Globals.conceptionSense);
		Globals.UpdateConceptionSprite();
		UpdateImage(Globals.GetCurrentSense());
		yield return E.Break;
	}

	IEnumerator OnClickBtnLeft( IGuiControl control )
	{
		Globals.conceptionSense = Globals.GetNextConceptionSense(2);
		Globals.PlayConceptionSenseSound(Globals.conceptionSense);
		Globals.UpdateConceptionSprite();
		UpdateImage(Globals.GetCurrentSense());
		yield return E.Break;
	}

	IEnumerator OnClickBtnUp( IGuiControl control )
	{
		Globals.conceptionSense = Globals.GetNextConceptionSense(3);
		Globals.PlayConceptionSenseSound(Globals.conceptionSense);
		Globals.UpdateConceptionSprite();
		UpdateImage(Globals.GetCurrentSense());
		yield return E.Break;
	}

	IEnumerator OnClickBtnDown( IGuiControl control )
	{
		Globals.conceptionSense = Globals.GetNextConceptionSense(1);
		Globals.PlayConceptionSenseSound(Globals.conceptionSense);
		Globals.UpdateConceptionSprite();
		UpdateImage(Globals.GetCurrentSense());
		yield return E.Break;
	}


	private IImage[] conceptionImages = new IImage[0];

	public void UpdateImage(int currentSense)
	{
		if(conceptionImages.Length == 0) SetImages();

		for(int i = 0; i < conceptionImages.Length; i++)
		{
			if(i == currentSense) conceptionImages[i].Show();
			else conceptionImages[i].Hide();
		}
	}

	private void SetImages()
	{
		conceptionImages = new IImage[]{Image("See"), Image("Taste"), Image("Hear"), Image("Smell"), Image("Feel"), Image("Sixth")};
	}

	void OnShow()
	{
		UpdateImage(Globals.GetCurrentSense());
		//Audio.Play("look_sound");
	}

	IEnumerator OnClickBtnBack( IGuiControl control )
	{
		G.Conception.Hide();
		Globals.PlayConceptionSenseSound(Globals.conceptionSense);
		yield return E.Break;
	}
}
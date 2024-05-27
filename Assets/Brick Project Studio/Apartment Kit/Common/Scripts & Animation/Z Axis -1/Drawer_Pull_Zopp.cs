using System.Collections;
using UnityEngine;

public class Drawer_Pull_Zopp : Openable
{
	void Start()
	{
		base.Setup(10.0f);
	}

	protected override IEnumerator OpenAnim()
	{
		base.PlayAnimation("openpullopp");
		yield return new WaitForSeconds(.5f);
	}

	protected override IEnumerator CloseAnim()
	{
		base.PlayAnimation("closepushopp");
		yield return new WaitForSeconds(.5f);
	}
}
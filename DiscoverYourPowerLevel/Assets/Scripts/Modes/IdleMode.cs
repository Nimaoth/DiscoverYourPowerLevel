using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Custom/Modes/Idle")]

public class IdleMode : Mode {

	public override void Start()
    {
        base.Start();
        ButtonUIManager.instance.SetupIdle();
    }
	public override void OnUpdate(float time)
    {
	}
}

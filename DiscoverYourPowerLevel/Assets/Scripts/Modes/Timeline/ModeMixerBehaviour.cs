using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class ModeMixerBehaviour : PlayableBehaviour
{
    public Player Player1;
    public Player Player2;
    public AudioSource AudioSource;

    private ModeBehaviour currentMode = null;

    // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if (info.evaluationType == FrameData.EvaluationType.Evaluate) {
            return;
        }

        int inputCount = playable.GetInputCount();

        float maxWeight = 0.5f;
        ModeBehaviour nextMode = null;
        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<ModeBehaviour> inputPlayable = (ScriptPlayable<ModeBehaviour>)playable.GetInput(i);
            ModeBehaviour input = inputPlayable.GetBehaviour();

            if (inputWeight > maxWeight) {
                nextMode = input;
                maxWeight = inputWeight;
            }
        }

        if (nextMode != currentMode) {
            currentMode?.OnStop(playable, info);
            nextMode?.OnStart(playable, info, Player1, Player2, AudioSource);
            currentMode = nextMode;
        }

        currentMode?.OnUpdate(playable, info);
    }
}

using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class ModeMixerBehaviour : PlayableBehaviour
{
    private ModeBehaviour currentMode = null;

    // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
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
            nextMode?.OnStart(playable, info);
            currentMode = nextMode;
        }

        currentMode?.OnUpdate(playable, info);
    }
}

using Ludiq;
using Bolt;
using UnityEngine;
using DragonBones;

public class DragonBonesChangeTimeScale : Unit
{
    [DoNotSerialize]
    public ControlInput enter;

    [DoNotSerialize]
    public ControlOutput exit;

    [DoNotSerialize]
    public ValueInput armatureComponent;

    [DoNotSerialize]
    public ValueInput animationName;

    [DoNotSerialize]
    public ValueInput fadeIn;

    [DoNotSerialize]
    public ValueInput loops;

    [DoNotSerialize]
    public ValueInput timeScale;

    [DoNotSerialize]
    public ValueOutput result;

    protected override void Definition()
    {
        enter = ControlInput("enter", (flow) =>
        {
            flow.GetValue<UnityArmatureComponent>(armatureComponent)
                .animation
                .timeScale = flow.GetValue<float>(timeScale);
            return exit;
        });
        
        exit = ControlOutput("exit");

        armatureComponent = ValueInput<UnityArmatureComponent>("ArmatureComponent");
        timeScale = ValueInput<float>("TimeScale", 1f);
        
        result = ValueOutput<UnityArmatureComponent>("ArmatureComponent", (flow) => {
            return flow.GetValue<UnityArmatureComponent>(armatureComponent);
        });
        
    }
}
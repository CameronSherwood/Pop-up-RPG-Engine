using Ludiq;
using Bolt;
using UnityEngine;
using DragonBones;

public class DragonBonesChangeAnimation : Unit
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
    public ValueOutput result;

    protected override void Definition()
    {
        enter = ControlInput("enter", (flow) =>
        { 
            flow.GetValue<UnityArmatureComponent>(armatureComponent)
                .animation
                .FadeIn(flow.GetValue<string>(animationName), 
                        flow.GetValue<float>(fadeIn), 
                        flow.GetValue<int>(loops));
            return exit;
        });
        
        exit = ControlOutput("exit");

        armatureComponent = ValueInput<UnityArmatureComponent>("ArmatureComponent");
        animationName = ValueInput<string>("AnimationName", string.Empty);
        fadeIn = ValueInput<float>("FadeIn", 0.0f);
        loops = ValueInput<int>("Loops", -1);
        
        result = ValueOutput<UnityArmatureComponent>("ArmatureComponent", (flow) => {
            return flow.GetValue<UnityArmatureComponent>(armatureComponent);
        });
        
    }
}
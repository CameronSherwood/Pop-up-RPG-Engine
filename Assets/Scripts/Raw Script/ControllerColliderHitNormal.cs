using Ludiq;
using Bolt;
using UnityEngine;

public class ControllerColliderHitNormal : Unit
{
    [DoNotSerialize]
    public ControlInput enter;

    [DoNotSerialize]
    public ControlOutput exit;
	
    [DoNotSerialize]
    public ValueInput hit;

    private Vector3 normal;

    [DoNotSerialize]
    public ValueOutput result;

    protected override void Definition()
    {
        enter = ControlInput("enter", (flow) =>
        { 
            normal = flow.GetValue<ControllerColliderHit>(hit).normal;
            return exit;
        });
        
        exit = ControlOutput("exit");

        hit = ValueInput<ControllerColliderHit>("Hit");
        result = ValueOutput<Vector3>("Normal", (flow) => {
            return normal; 
        });
    }
}
using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DetectorJugadores", story: "El agente [detecta] a un enemigo", category: "Action", id: "7bb9c9bdb6ca958efc1b682a3b5b43a5")]
public partial class DetectorJugadoresAction : Action
{
    [SerializeReference] public BlackboardVariable<DetectorDeJugadores> Detecta;
    protected override Status OnStart()
    {
        return Detecta.Value.GetComponent<DetectorDeJugadores>().estaATiro() == false ? Status.Failure : Status.Success ;
    }
}


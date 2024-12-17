using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Disparar", story: "El [agente] dispara al enemigo [detectado] a cada [segundos] con [arma]", category: "Action", id: "5c11c0b10b503968426efef36e460fae")]
public partial class DispararAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agente;
    [SerializeReference] public BlackboardVariable<DetectorDeJugadores> Detectado;
    [SerializeReference] public BlackboardVariable<int> Segundos;
    [SerializeReference] public BlackboardVariable<ParticleSystem> Arma;
    float coolDownRestante = 0;
    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(Detectado.Value.GetComponent<DetectorDeJugadores>().obtenerObjetivo() != null)
        {
            Disparar(Detectado.Value.GetComponent<DetectorDeJugadores>().obtenerObjetivo().transform);
            return Status.Success;
        }

        return Status.Failure;
    }
    void Disparar(Transform posicionADisparar)
    {
        bool fueraDeCooldown = coolDownRestante >= Segundos;
        var emmisionModule = Arma.Value.GetComponent<ParticleSystem>().emission;
        emmisionModule.enabled = fueraDeCooldown;
        if (fueraDeCooldown)
        {
            Debug.Log("Pium pium a goofy");
            Vector3 fireDirection = posicionADisparar.position - Agente.Value.transform.position;
            Quaternion apuntarAlEnemigo = Quaternion.LookRotation(fireDirection);
            Arma.Value.transform.rotation = apuntarAlEnemigo;
            if(coolDownRestante >= Segundos)
                coolDownRestante = 0;
        }
        else
        {
            Debug.Log("Me falta para disparar:" + coolDownRestante);
            coolDownRestante += 1;
        }
    }
}


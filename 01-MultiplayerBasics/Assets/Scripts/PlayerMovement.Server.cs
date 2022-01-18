using Mirror;
using UnityEngine;
using UnityEngine.AI;

public partial class PlayerMovement {
    [Command]
    void CmdMove(Vector3 position) {
        if (!NavMesh.SamplePosition(position, out var hit, 1, NavMesh.AllAreas)) {
            return;
        }

        agent.SetDestination(hit.position);
    }
}

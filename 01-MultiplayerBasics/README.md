# Notes
## Section 1
Multiplayer Basics, 11 Lectures: [1](https://www.udemy.com/course/unity-multiplayer/learn/lecture/22899360) - [11](https://www.udemy.com/course/unity-multiplayer/learn/lecture/22899414)

## What's new
- [NetworkManager](https://mirror-networking.gitbook.io/docs/components/network-manager) methods: `OnClient...` is called on the client, `OnServer...` is called on the server
- [NetworkBehaviour](https://mirror-networking.gitbook.io/docs/components/networkbehaviour) relies on `NetworkIdentity` (which is placed on the Player) and can have SyncVars
  - [SyncVars](https://mirror-networking.gitbook.io/docs/guides/synchronization/syncvars) are properties of classes that inherit from NetworkBehaviour, which are synchronized from the server to all clients automatically
  - SyncVars have [Hooks](https://mirror-networking.gitbook.io/docs/guides/synchronization/syncvar-hooks) - methods that are triggered on the client when its SyncVar is changed
  - The supported sync [Data types](https://mirror-networking.gitbook.io/docs/guides/data-types)
  - Use [OnStartAuthority](https://mirror-networking.gitbook.io/docs/components/networkbehaviour#network-callbacks) when you need to call some logic only on Client, it's the same as `Start`, but is only called on Clients for behaviours that have authority, based on context and `hasAuthority`
  - Use [ClientCallback](https://mirror-networking.gitbook.io/docs/components/networkbehaviour#server-and-client-functions) to mark, e.g., an `Update`, to be run only on Client
- [Commands](https://mirror-networking.gitbook.io/docs/guides/communications/remote-actions#commands) are sent from player objects on the client to player objects on the server. `[Command]` functions will be run on the server when they are called on the client. `Cmd` prefix is used on the function for readability
- [ClientRpc](https://mirror-networking.gitbook.io/docs/guides/communications/remote-actions#clientrpc-calls) calls are sent from objects on the server to objects on clients. They can be sent from any server object with a `NetworkIdentity` that has been spawned (from all `isServer` objects, not just `isLocalPlayer` objects). `Rpc` prefix is used on the function for readability
- [TargetRpc](https://mirror-networking.gitbook.io/docs/guides/communications/remote-actions#targetrpc-calls) functions are called by user code on the server, and then invoked on the corresponding client object on the client of the specified `NetworkConnection` (if the first parameter is of that type, otherwise it will be called on the owner of that function). `Target` prefix is used on the function for readability
- [NetworkTransform](https://mirror-networking.gitbook.io/docs/components/network-transform) synchronizes the position, rotation, and scale of networked game objects across the network. By default, Network Transform is server-authoritative unless you check the box for Client Authority.
- [NetworkStartPosition](https://mirror-networking.gitbook.io/docs/components/network-start-position) is used for Player Spawning. Spawn logic depends on [Player Spawn Method](https://mirror-networking.gitbook.io/docs/components/network-manager#spawn-management)

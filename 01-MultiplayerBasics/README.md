# Notes
## Section 1
Multiplayer Basics, 11 Lectures: [1](https://www.udemy.com/course/unity-multiplayer/learn/lecture/22899360) - [11](https://www.udemy.com/course/unity-multiplayer/learn/lecture/22899414)

## What's new
- [NetworkManager](https://mirror-networking.gitbook.io/docs/components/network-manager) methods: `OnClient...` is called on the client, `OnServer...` is called on the server
- [NetworkBehaviour](https://mirror-networking.gitbook.io/docs/components/networkbehaviour) relies on `NetworkIdentity` (which is placed on the Player) and can have SyncVars
  - [SyncVars](https://mirror-networking.gitbook.io/docs/guides/synchronization/syncvars) are properties of classes that inherit from NetworkBehaviour, which are synchronized from the server to all clients automatically
  - The supported sync [Data types](https://mirror-networking.gitbook.io/docs/guides/data-types)

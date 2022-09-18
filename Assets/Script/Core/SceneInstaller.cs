using Dythervin.AutoAttach;
using UnityEngine;
using Noir;
using Zenject;

namespace Noir_Core
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField, Attach(Attach.Scene)] private Player _player;
        [SerializeField, Attach(Attach.Scene)] private NoirActive noirActive;
        [SerializeField, Attach(Attach.Scene)] private KeyboardPlayer _keyboardPlayer;
        [SerializeField, Attach(Attach.Scene)] private StateManager _state; 

        public override void InstallBindings()
        {
            Container.Bind<Player>().FromInstance(_player).AsSingle();
            Container.Bind<NoirActive>().FromInstance(noirActive).AsSingle();
            Container.Bind<KeyboardPlayer>().FromInstance(_keyboardPlayer).AsSingle();
            Container.Bind<StateManager>().FromInstance(_state).AsSingle();
        }
     
    }
}

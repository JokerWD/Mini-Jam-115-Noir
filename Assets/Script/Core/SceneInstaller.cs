using Dythervin.AutoAttach;
using UnityEngine;
using Noir;
using Zenject;

namespace Noir_Core
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField, Attach(Attach.Scene)] private Player _player;
        [SerializeField, Attach(Attach.Scene)] private Teleport _teleport;
        [SerializeField, Attach(Attach.Scene)] private KeyboardPlayer _keyboardPlayer;

        public override void InstallBindings()
        {
            Container.Bind<Player>().FromInstance(_player).AsSingle();
            Container.Bind<Teleport>().FromInstance(_teleport).AsSingle();
            Container.Bind<KeyboardPlayer>().FromInstance(_keyboardPlayer).AsSingle();
        }
     
    }
}

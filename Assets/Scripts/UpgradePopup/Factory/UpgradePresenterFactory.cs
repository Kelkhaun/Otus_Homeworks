using Infrastructure.DI;
using UpgradePopup.Pool;
using UpgradePopup.Presenter;

namespace UpgradePopup.Factory
{
    public sealed class UpgradePresenterFactory
    {
        private Character.Character _character;
        private CharacterStatPool _characterStatPool;

        [Inject]
        private void Construct(Character.Character character, CharacterStatPool characterStatPool)
        {
            _character = character;
            _characterStatPool = characterStatPool;
        }

        public IUpgradePresenter Create()
        {
            return new CharacterUpgradePresenter(_character, _characterStatPool);
        }
    }
}
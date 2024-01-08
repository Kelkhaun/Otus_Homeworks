using Infrastructure.DI;
using UpgradePopup.Pool;
using UpgradePopup.Presenter;

namespace UpgradePopup.Factory
{
    public sealed class UpgradePresenterFactory
    {
        private CharacterScripts.Character _character;
        private CharacterStatPool _characterStatPool;

        [Inject]
        private void Construct(CharacterScripts.Character character, CharacterStatPool characterStatPool)
        {
            _character = character;
            _characterStatPool = characterStatPool;
        }

        public IUpgradePresenter Create()
        {
            var characterPresenter = new CharacterPresenter(_character, _characterStatPool);
            return characterPresenter;
        }
    }
}
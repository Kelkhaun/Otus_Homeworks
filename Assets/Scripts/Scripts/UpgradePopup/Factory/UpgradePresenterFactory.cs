using Scripts.Infrastructure.DI;
using Scripts.UpgradePopup.Pool;
using Scripts.UpgradePopup.Presenter;

namespace Scripts.UpgradePopup.Factory
{
    public class UpgradePresenterFactory
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
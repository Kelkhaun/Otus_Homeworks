using UpgradePopup.Pool;
using Character = CharacterScripts.Character;

namespace UpgradePopup.Presenter
{
    public sealed class CharacterPresenter : IUpgradePresenter
    {
        private Character _character;
        private CharacterStatPool _characterStatPool;

        public IUpgradeInfoPresenter PlayerInfoPresenter { get; private set; }
        public IUpgradeLevelInfoPresenter LevelInfoPresenter { get; private set; }

        // 2. CharacterUpgradePresenter тоже можно подразбить на CharacterInfoPM & CharacterStatsPM.
        // Можно даже сделать CharacterStatPM для каждого элемента CharacterStatView
        //
        // 3. CharacterUpgradePresenter не должен иметь зависимость на пул CharacterStatView, это логика UI

        public CharacterPresenter(Character character, CharacterStatPool characterStatPool)
        {
            _characterStatPool = characterStatPool;
            _character = character;

            PlayerInfoPresenter = new UpgradePresenterInfo(_character);
            LevelInfoPresenter = new UpgradeLevelPresenter(_character);

            Enable();
        }

        public void Enable()
        {
            PlayerInfoPresenter.Enable();
            LevelInfoPresenter.Enable();

            // _character.CharacterInfo.OnStatAdded += OnStatAdded;
            // _character.CharacterInfo.OnStatRemoved += OnStatRemoved;
        }

        public void Disable()
        {
            PlayerInfoPresenter.Disable();
            LevelInfoPresenter.Disable();

            // _character.CharacterInfo.OnStatAdded -= OnStatAdded;
            // _character.CharacterInfo.OnStatRemoved -= OnStatRemoved;
            //
            // var stats = _character.CharacterInfo.GetStats();
            //
            // foreach (var stat in stats)
            // {
            //     stat.OnValueChanged -= OnValueChanged;
            // }
        }

        // private void OnStatAdded(CharacterStat characterStat)
        // {
        //     characterStat.OnValueChanged += OnValueChanged;
        //     var statPopupView = _characterStatPool.Get();
        //     statPopupView.Setup(characterStat.Name + ": " + characterStat.Value.ToString(), characterStat);
        // }
        //
        // private void OnValueChanged(int value, CharacterStat characterStat)
        // {
        //     var view = _characterStatPool.FindView(characterStat);
        //     view.Setup(characterStat.Name + ": " + characterStat.Value.ToString(), characterStat);
        // }
        //
        // private void OnStatRemoved(CharacterStat characterStat)
        // {
        //     _characterStatPool.Release(characterStat);
        // }
    }
}
using SecretSanta.GameManagment;

namespace SecretSanta.UI
{
    public class UiXpDataTracker : UiFillIntDataTracker
    {
        protected override void Update()
        {
            _trackedData = SecretSantaGame.Instance.CurPlayerData.Experience;
            _fullAmount = SecretSantaGame.Instance.CurPlayerData.XpToNextLvl;
            base.Update();
        }

    }
}
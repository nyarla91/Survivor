using RunProgress;
using Zenject;

namespace Shop.Stat
{
    public class StatStage : ShopStage<ModifiedStat>
    {
        [Inject] private PlayerStats Stats { get; set; }
        [Inject] private PlayerLevel Level { get; set; }
        protected override ModifiedStat[] ObjPool => Stats.Stats;
        protected override int Iterations => Level.UpgradePoints;

        protected override void OnStageEnd()
        {
            base.OnStageEnd();
            Level.DiscardPoints();
        }

        protected override void ProcessChosenObj(ModifiedStat obj)
        {
            obj.Upgrade();
        }
    }
}
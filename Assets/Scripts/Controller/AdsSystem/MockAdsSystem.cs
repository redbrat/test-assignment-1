using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Controller.AdsSystem
{
    [UsedImplicitly]
    public class MockAdsSystem : IAdsSystem
    {
        public Task<bool> ShowAd()
        {
            return Task.FromResult(true);
        }
    }
}

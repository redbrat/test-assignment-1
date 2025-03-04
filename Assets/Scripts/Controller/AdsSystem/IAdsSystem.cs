using System.Threading.Tasks;

namespace Controller.AdsSystem
{
    public interface IAdsSystem
    {
        Task<bool> ShowAd();
    }
}

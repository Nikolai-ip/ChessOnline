using Infrastructure.Services;

namespace StaticData
{
    public interface IStaticDataService:IService
    {
        void LoadGameFieldData();
    }
}
namespace PortfolioUno.CharacterCreation.Data.Interfaces
{
    public interface IDataStorage
    {
        bool LoadData<T>(out T loaded);

        void SaveData<T>(T characterData);
    }
}
using PortfolioUno.CharacterCreation.Data.Interfaces;

namespace PortfolioUno.CharacterCreation
{
    public class CharacterDataHandler
    {

        private CharacterData _characterData;

        public CharacterDataHandler()
        {
            _characterData = new CharacterData();
            _characterData.PartsIndexs = new int[2];
        }

        public void LoadCharacterData()
        {
            var dataStorage = ServiceLocator.Get<IDataStorage>();
            var hasData = dataStorage.LoadData<CharacterData>(out var data);

            if (!hasData)
            {
                data.PartsIndexs = new int[2];
            }
            _characterData = data;
        }

        public void SaveData()
        {
            var dataStorage = ServiceLocator.Get<IDataStorage>();
            dataStorage.SaveData<CharacterData>(_characterData);
        }


        public void UpdateCharacterByPartType(CharacterPartType partType,int value)
        {
            _characterData.SetCurrentPartValueByPartType(partType, value);
        }


        public int GetPartIndexByPartType(CharacterPartType partType)
        {
            return _characterData.GetPartIndexByPartType(partType);
        }

        
    }
}
using PortfolioUno.CharacterCreation.Data.Interfaces;
using UnityEngine;


namespace PortfolioUno.CharacterCreation.Data.Implementations
{
    public class CharacterDataStoragePlayerPrefImplementation : IDataStorage 
    {
        private const string CHARACTERDATA_SAVE = "CharacterDataSelected";
        public bool LoadData<T>(out T dataLoaded) 
        {
            var dataString = PlayerPrefs.GetString(CHARACTERDATA_SAVE, "");
            if (string.IsNullOrEmpty(dataString))
            {
                Debug.Log("Characterd Has no data, creating a new data");

                dataLoaded = default;

                return false;
            }

            dataLoaded = JsonUtility.FromJson<T>(dataString);
            return true;
        }

        public void SaveData<T>(T characterData)
        {
            var jsonData = JsonUtility.ToJson(characterData);
            PlayerPrefs.SetString(CHARACTERDATA_SAVE, jsonData);
            PlayerPrefs.Save();
        }
    }
}
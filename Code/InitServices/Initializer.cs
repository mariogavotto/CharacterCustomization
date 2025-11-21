using PortfolioUno.CharacterCreation.Data.Implementations;
using PortfolioUno.CharacterCreation.Data.Interfaces;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void CreateBeforeInit()
    {
        var dataStorage = new CharacterDataStoragePlayerPrefImplementation();
        ServiceLocator.Register<IDataStorage>(dataStorage);

    }
}

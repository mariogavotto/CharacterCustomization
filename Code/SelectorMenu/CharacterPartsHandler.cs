using System.Collections.Generic;
using UnityEngine;


namespace PortfolioUno.CharacterCreation
{
    public class CharacterPartsHandler : MonoBehaviour
    {
        [SerializeField] private CharacterPartsColleciton[] _characterPartsCollections;
        private Dictionary<CharacterPartType, CharacterPartsColleciton> _dictionaryPartsCharacter;

        private void InitDictioanry()
        {
            _dictionaryPartsCharacter = new Dictionary<CharacterPartType, CharacterPartsColleciton>();
            foreach (var item in _characterPartsCollections)
            {
                _dictionaryPartsCharacter.Add(item.PartType, item);
            }
        }

        public void DisableAll()
        {
            foreach (var item in _dictionaryPartsCharacter.Values)
            {
                item.DisableAll();
            }
        }

        public void SetActiveValueIndexByPartType(CharacterPartType partType,int index,bool activeValue)
        {
            if (!_dictionaryPartsCharacter.ContainsKey(partType))
            {
                Debug.LogError($"{partType.ToString()} not found in dictioanry");
                return;
            }
            _dictionaryPartsCharacter[partType].SetEnablePart(index,activeValue);
        }

        public void Init()
        {
            InitDictioanry();
        }


        public int GetTotalPartsByPartType(CharacterPartType partType)
        {
            return _dictionaryPartsCharacter[partType].GetTotal();
        }
    }
}
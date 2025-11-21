using UnityEngine;


namespace PortfolioUno.CharacterCreation.UI
{
    public class SelectorCharacterPartUI : MonoBehaviour
    {
        [SerializeField] CustomizeCharacter selectPartsCharacter;
        [SerializeField] private IndividualCharacterSelector[] _selectorParts;
        
        private void Awake()
        {
            InitButtons();
        }

        private void InitButtons()
        {
            foreach (var item in _selectorParts)
            {
                var itemType = item.PartType;
                item.Nextbtn.onClick.AddListener(() => ClickNext(itemType));
                item.PreviousBtn.onClick.AddListener(()=> ClickPrevious(itemType));
            };
        }

        public void ClickNext(CharacterPartType partType)
        {
            selectPartsCharacter.ChangePartByType(partType, true);
        }

        public void ClickPrevious(CharacterPartType partType)
        {
            selectPartsCharacter.ChangePartByType(partType, false);
        }

        public void OnClickSave()
        {
            selectPartsCharacter.SaveData();
        }

        public void OnClickRandomize()
        {
            selectPartsCharacter.GenerateRandomCharacter();
        }
    }
}
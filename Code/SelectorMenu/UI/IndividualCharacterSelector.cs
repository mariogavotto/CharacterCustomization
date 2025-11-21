using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace PortfolioUno.CharacterCreation.UI
{
    public class IndividualCharacterSelector : MonoBehaviour
    {
        [SerializeField] private CharacterPartType _partType;
        [SerializeField] private TextMeshProUGUI _partText;

        [SerializeField] Button _nextbtn;
        [SerializeField] Button _previousBtn;

        private void Awake()
        {
            _partText.text = _partType.ToString();
        }

        public Button PreviousBtn  => _previousBtn;

        public Button Nextbtn  => _nextbtn;

        public CharacterPartType PartType => _partType;
    }
}
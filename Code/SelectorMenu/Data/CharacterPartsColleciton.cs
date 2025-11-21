using UnityEngine;


namespace PortfolioUno.CharacterCreation
{
    [System.Serializable]
    public struct CharacterPartsColleciton
    {
        public CharacterPartType PartType;
        [SerializeField] private GameObject[] _bodyParts;

        public int GetTotal() => _bodyParts.Length;

        public void SetEnablePart(int index, bool value)
        {
            _bodyParts[index].SetActive(value);
        }

        internal void DisableAll()
        {
            foreach (var item in _bodyParts)
            {
                item.SetActive(false);
            }
        }
    }
}
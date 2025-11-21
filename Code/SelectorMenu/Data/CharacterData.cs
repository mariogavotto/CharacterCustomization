namespace PortfolioUno.CharacterCreation
{
    [System.Serializable]
    public struct CharacterData
    {
        public int[] PartsIndexs;

        public void SetCurrentPartValueByPartType(CharacterPartType characterPart, int index)
        {
            PartsIndexs[(int)characterPart] = index;
        }

        public int GetPartIndexByPartType(CharacterPartType characterPart) {
            return PartsIndexs[(int)characterPart];
        }
    }
}
using System;
using UnityEngine;


namespace PortfolioUno.CharacterCreation
{
    public class CustomizeCharacter : MonoBehaviour
    {
        [SerializeField] private CharacterPartsHandler _characterPartsHandler;
        [SerializeField] private CharacterDataHandler _dataHandler;


        private CharacterPartType _currentPartType;
       
        private void Awake()
        {
            _dataHandler = new CharacterDataHandler();
            InitModels();
            LoadCharacterData();
           
        }

        private void LoadCharacterData()
        {
            _dataHandler.LoadCharacterData();
        }

        private void InitModels()
        {
            _characterPartsHandler.Init();
        }

        private void OnEnable()
        {
            UpdateModelVisual();
        }

        private void UpdateModelVisual()
        {
            _characterPartsHandler.DisableAll();
            for (int i = 0; i < 2; i++)
            {
                
                CharacterPartType partType = (CharacterPartType)i;
                var index = _dataHandler.GetPartIndexByPartType(partType);

                _characterPartsHandler.SetActiveValueIndexByPartType(partType, index, true);
                

            }
            
        }



        public void ChangePartByType(CharacterPartType partType,bool isNext)
        {
            _currentPartType = partType;
            ChangeCurrentSelectedParttToDirection(isNext);
        }

        public void ChangeCurrentSelectedParttToDirection(bool isNext)
        {
            SetActiveForPart(false);
            var direction = (isNext ? 1 : -1);
            ChangePartIndex(direction);
            SetActiveForPart(true);
        }

        private void ChangePartIndex(int direction)
        {
            var index = GetIndexFromCurrentPartType();
            int total = GetCurrentTotalParts();
            index = (index + direction + total) % total;

            _dataHandler.UpdateCharacterByPartType(_currentPartType, index);
            
        }

        private int GetCurrentTotalParts()
        {
            return _characterPartsHandler.GetTotalPartsByPartType(_currentPartType);
        }

        private void SetActiveForPart(bool active)
        {
            var currentIndex = GetIndexFromCurrentPartType();
            _characterPartsHandler.SetActiveValueIndexByPartType(_currentPartType, currentIndex, active);
        }

        private int GetIndexFromCurrentPartType()
        {
            return _dataHandler.GetPartIndexByPartType(_currentPartType);
        }

        internal void SaveData()
        {
            _dataHandler.SaveData();
        }


        public void GenerateRandomCharacter()
        {
            foreach (CharacterPartType part in Enum.GetValues(typeof(CharacterPartType)))
            {
                var limit = _characterPartsHandler.GetTotalPartsByPartType(part);
                var value = CharacterRandomizer.RandomizePart(limit);
                _dataHandler.UpdateCharacterByPartType(part, value);
            }
            UpdateModelVisual();
        }

    }

    public class CharacterRandomizer
    {
        public static int RandomizePart(int limit)
        {
            return UnityEngine.Random.Range(0, limit);
        }
        
    }
}
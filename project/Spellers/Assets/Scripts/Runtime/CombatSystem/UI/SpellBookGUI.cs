using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpellSystem;
using TMPro;
using CustomEventSystem;


namespace Runtime.CombatSystem.UI
{
    public class SpellBookGUI : MonoBehaviour
    {
        #region Public variables
        public RectTransform book_content;
        public GameObject spellSlot_prefab;
 
        public RectTransform minigame_bar;

        public Button str_game_button;
        public Button reg_game_button;
        public Button bln_game_button;
        public Button dif_game_button;

        public StrengthMinigame str_game;
        public RegenerationMinigame reg_game;
        public BlindMinigame blind_game;
        public DifficultyMinigame dif_game;

        #endregion

        #region private Fields
        private List<SpellSlotGUI> spellSlots;
        #endregion

        #region Unity CallBacks and public methods
        public void Awake()
        {
            spellSlots = new List<SpellSlotGUI>();

            str_game_button.onClick.AddListener(str_game.EnterGame);
            reg_game_button.onClick.AddListener(reg_game.EnterGame);
            bln_game_button.onClick.AddListener(blind_game.EnterGame);
            dif_game_button.onClick.AddListener(dif_game.EnterGame);
        }

        private void OnEnable()
        {
            Events.OnGenerateSpellSlots.AddListener(SetUpSpellSlots);
            Events.OnChangeSpellSlot.AddListener(SetLayoutSlot);
            Events.OnPlayerUseSpell.AddListener(GenerateMinigamesBar);
            Events.OnCompletePoisonMinigame.AddListener(GenerateMinigamesBar);
            Events.OnCompleteBlindMinigame.AddListener(GenerateMinigamesBar);
            Events.OnCompleteDifficultyMinigame.AddListener(GenerateMinigamesBar);
            Events.OnFailSpell.AddListener(GenerateMinigamesBar);
        }

        private void OnDisable()
        {
            Events.OnGenerateSpellSlots.RemoveListener(SetUpSpellSlots);
            Events.OnChangeSpellSlot.RemoveListener(SetLayoutSlot);
            Events.OnPlayerUseSpell.RemoveListener(GenerateMinigamesBar);
            Events.OnCompletePoisonMinigame.RemoveListener(GenerateMinigamesBar);
            Events.OnCompleteBlindMinigame.RemoveListener(GenerateMinigamesBar);
            Events.OnCompleteDifficultyMinigame.RemoveListener(GenerateMinigamesBar);
            Events.OnFailSpell.RemoveListener(GenerateMinigamesBar);
        }

        #endregion

        #region Private Methods

        // Genera la barra de minijuegos:
        private void GenerateMinigamesBar()
        {            
            SpellerStats stats = FindObjectOfType<SpellerPlayer>().stats;
            str_game_button.gameObject.SetActive(stats.AttackLevel < 2f);
            reg_game_button.gameObject.SetActive(stats.Regeneration < 1);
            bln_game_button.gameObject.SetActive(stats.Order < 1);
            dif_game_button.gameObject.SetActive(stats.Difficulty < 1);
        }

        // Genera la lista de hechizos:
        private void SetUpSpellSlots(List<SpellUnit> spells)
        {
            ShutDownSpellSlots();
            for (int i = 0; i < spells.Count; i++)
            {
                int idx = i;
                SpellSlotGUI spellSlot = Instantiate(spellSlot_prefab, book_content).GetComponent<SpellSlotGUI>();
                spellSlot.AddListener(() => FindObjectOfType<SpellerPlayer>().SelectSpell(idx));
                spellSlots.Add(spellSlot);
                SetLayoutSlot(idx, spells[idx]);
            }
        }

        // Destruye la lista de hechizos:
        private void ShutDownSpellSlots()
        {
            for (int i = spellSlots.Count - 1; i >= 0; i--)
            {
                Destroy(spellSlots[i].gameObject);
            }
            spellSlots.Clear();          
        }

        // Pinta el layout del hechizo:
        private void SetLayoutSlot(int idx, SpellUnit spellUnit)
        {
            spellSlots[idx].SetSpellGUI(spellUnit);
        }
   

        #endregion
    }



    

    

}
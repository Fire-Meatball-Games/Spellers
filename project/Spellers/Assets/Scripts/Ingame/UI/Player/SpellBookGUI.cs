using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpellSystem;
using TMPro;
using CustomEventSystem;
using Ingame;

namespace Ingame.UI
{
    public class SpellBookGUI : SpellPlayerGUI
    {
        #region Inspector fields
        [SerializeField] private RectTransform spellSlotsContent;
        [SerializeField] private GameObject spellSlot_prefab;
        [SerializeField] private Button reload_button;

        #endregion

        #region Private fields
        private SpellBook playerBook;
        private List<SpellSlotGUI> spellSlots;

        #endregion

        protected override void Init() 
        {
            base.Init();
            spellSlots = new List<SpellSlotGUI>();
        }

        public override void SetUp(SpellerPlayer spellerPlayer)
        {
            base.SetUp(spellerPlayer);
            playerBook = player.book;
            playerBook.OnAddSpellUnit += AddSpellUnit;
            playerBook.OnRemoveSpellUnit += RemoveSpellUnit;
            playerBook.OnUpdateSpellUnit += UpdateSpellUnit;
            //reload_button.onClick.AddListener...
            //Debug.Log("Interfaz de libro de hechizos configurada");
        } 

        // public RectTransform minigame_bar;

        // public Button str_game_button;
        // public Button reg_game_button;
        // public Button bln_game_button;
        // public Button dif_game_button;

        // public StrengthMinigame str_game;
        // public RegenerationMinigame reg_game;
        // public BlindMinigame blind_game;
        // public DifficultyMinigame dif_game;

        // #endregion

        // #region Unity CallBacks and public methods
        // public void Awake()
        // {
        //     spellSlots = new List<SpellSlotGUI>();

        //     str_game_button.onClick.AddListener(str_game.EnterGame);
        //     reg_game_button.onClick.AddListener(reg_game.EnterGame);
        //     bln_game_button.onClick.AddListener(blind_game.EnterGame);
        //     dif_game_button.onClick.AddListener(dif_game.EnterGame);
        // }

        // private void OnEnable()
        // {
        //     Events.OnGenerateSpellSlots.AddListener(SetUpSpellSlots);
        //     Events.OnChangeSpellSlot.AddListener(SetLayoutSlot);

        //     Events.OnPlayerUseSpell.AddListener(GenerateMinigamesBar);
        //     //Events.OnCompletePoisonMinigame.AddListener(GenerateMinigamesBar);
        //     //Events.OnCompleteBlindMinigame.AddListener(GenerateMinigamesBar);
        //     //Events.OnCompleteDifficultyMinigame.AddListener(GenerateMinigamesBar);
        //     Events.OnChangeStat.AddListener(GenerateMinigamesBar);
        //     Events.OnFailSpell.AddListener(GenerateMinigamesBar);
        // }

        // private void OnDisable()
        // {
        //     Events.OnGenerateSpellSlots.RemoveListener(SetUpSpellSlots);
        //     Events.OnChangeSpellSlot.RemoveListener(SetLayoutSlot);

        //     Events.OnPlayerUseSpell.RemoveListener(GenerateMinigamesBar);
        //     //Events.OnCompletePoisonMinigame.RemoveListener(GenerateMinigamesBar);
        //     //Events.OnCompleteBlindMinigame.RemoveListener(GenerateMinigamesBar);
        //     //Events.OnCompleteDifficultyMinigame.RemoveListener(GenerateMinigamesBar);
        //     Events.OnChangeStat.RemoveListener(GenerateMinigamesBar);
        //     Events.OnFailSpell.RemoveListener(GenerateMinigamesBar);
        // }

        // #endregion

        // #region Private Methods

        // // Genera la barra de minijuegos:
        // private void GenerateMinigamesBar()
        // {            
        //     SpellerStats stats = FindObjectOfType<SpellerPlayer>().Stats;
        //     str_game_button.gameObject.SetActive(stats.AttackLevel < 1f);
        //     reg_game_button.gameObject.SetActive(stats.Regeneration < 1f);
        //     bln_game_button.gameObject.SetActive(stats.Order < 0);
        //     dif_game_button.gameObject.SetActive(stats.Difficulty < 0);
        // }
        // #endregion

        private void AddSpellUnit(SpellUnit unit, int idx)
        {
            Debug.Log("Interfaz de Libro de hechizos: hechizo añadido: " + unit + " (" + idx + ")");
            var obj = Instantiate(spellSlot_prefab, spellSlotsContent);
            obj.transform.SetSiblingIndex(idx);
            var spellSlot = obj.GetComponent<SpellSlotGUI>();
            spellSlot.SetSpellGUI(unit);
            spellSlot.AddSelectButtonCallback(() => SelectSpellListener(idx));
            spellSlot.AddSelectButtonCallback(Hide);
            spellSlots.Insert(idx, spellSlot);
            // TODO: 
            //spellSlot.AddInfoButtonCallback(...);
        }

        private void RemoveSpellUnit()
        {
            var slot = spellSlots[spellSlots.Count - 1];
            spellSlots.Remove(slot);
            Destroy(slot.gameObject);
        }

        private void UpdateSpellUnit(SpellUnit unit, int idx)
        {
            var slot = spellSlots[idx];
            spellSlots.Remove(slot);
            Destroy(slot.gameObject);
            AddSpellUnit(unit, idx);
        }

        private void Clear()
        {
            for (int i = spellSlots.Count - 1; i >= 0; i--)
            {      
                 Destroy(spellSlots[i].gameObject);
            }
            spellSlots.Clear();
        }

        private void SelectSpellListener(int idx)
        {
            player.SelectSpell(idx);
            Events.OnSelectSpellSlot.Invoke();
        }
    }



    

    

}
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
        [SerializeField] private Button reroll_button;
        [SerializeField] private Slider reroll_slider;
        [SerializeField] private SpellInfoGUI infoGUI;
        [SerializeField] private Button stopWandGameButton;
        [SerializeField] private Button potionGameButton;
        [SerializeField] private Button flipCardsGameButton;
        [SerializeField] private int pointsToReroll;

        #endregion

        #region Private fields
        private SpellBook playerBook;

        private List<SpellSlotGUI> spellSlots;

        [SerializeField] private int rerollPoints;

        [SerializeField] private bool enablePowerGame;
        [SerializeField] private bool enableHealGame;
        [SerializeField] private bool enableRerollGame;

        #endregion

        protected override void Init() 
        {
            base.Init();
            spellSlots = new List<SpellSlotGUI>();
            reroll_slider.maxValue = pointsToReroll;
            infoGUI.HideInstant();
        }

        public override void SetUp(SpellerPlayer spellerPlayer)
        {
            base.SetUp(spellerPlayer);
            playerBook = player.book;
            playerBook.OnAddSpellUnit += AddSpellUnit;
            playerBook.OnRemoveSpellUnit += RemoveSpellUnit;
            playerBook.OnUpdateSpellUnit += UpdateSpellUnit;
            reroll_button.onClick.AddListener(Reroll);

            stopWandGameButton.onClick.AddListener(SelectStopWandGameButton);
            potionGameButton.onClick.AddListener(SelectPotionsGameButton);
            flipCardsGameButton.onClick.AddListener(SelectFlipCardsGameButton);
        } 

        private void OnEnable() 
        {
            Events.OnCompleteFlipCardsGame.AddListener(RechargeRerolls);
        }

        private void OnDisable() 
        {
            Events.OnCompleteFlipCardsGame.RemoveListener(RechargeRerolls);
        }

        private void SelectStopWandGameButton()
        {
            enablePowerGame = false;
            player.board.GenerateExtraGame(Board.GameType.attack);
            Events.OnSelectMinigame.Invoke();
        }

        private void SelectPotionsGameButton()
        {
            enableHealGame = false;
            player.board.GenerateExtraGame(Board.GameType.regeneration);
            Events.OnSelectMinigame.Invoke();
        }

        private void SelectFlipCardsGameButton()
        {
            enableRerollGame = false;
            player.board.GenerateExtraGame(Board.GameType.order);
            Events.OnSelectMinigame.Invoke();
        }
       
        private void Reroll()
        {
            playerBook.ReloadSpells();
            rerollPoints = 0;
            reroll_slider.value = 0;
            reroll_button.interactable = false;
        }

        private void RechargeRerolls()
        {
            rerollPoints = pointsToReroll;
            reroll_slider.value = rerollPoints;
            reroll_button.interactable = true;
        }

        private void AddSpellUnit(SpellUnit unit, int idx)
        {
            Debug.Log("Interfaz de Libro de hechizos: hechizo añadido: " + unit + " (" + idx + ")");
            var obj = Instantiate(spellSlot_prefab, spellSlotsContent);
            obj.transform.SetSiblingIndex(idx);
            var spellSlot = obj.GetComponent<SpellSlotGUI>();
            spellSlot.SetSpellGUI(unit);
            spellSlot.AddSelectButtonCallback(() => SelectSpellListener(idx));
            spellSlot.AddSelectButtonCallback(Hide);
            spellSlot.AddInfoButtonCallback(() => ShowSpellDetails(unit.spell));
            spellSlots.Insert(idx, spellSlot);
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

        private void ShowSpellDetails(Spell spell)
        {
            infoGUI.SetUp(spell);
        }

        public override void Hide()
        {
            base.Hide();
            if(infoGUI.active)
                infoGUI.Hide();
        }

        public override void Show()
        {
            rerollPoints++; //??
            rerollPoints = Mathf.Min(rerollPoints, pointsToReroll);
            base.Show();
            reroll_slider.value = rerollPoints;
            reroll_button.interactable = rerollPoints >= pointsToReroll;

            stopWandGameButton.interactable = enablePowerGame;
            potionGameButton.interactable = enableHealGame;
            flipCardsGameButton.interactable = enableRerollGame;
        }
    }

}
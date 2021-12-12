using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CustomEventSystem;
using System;
using Tweening;
using TMPro;

namespace Ingame.UI
{
    public class BoardGUI : SpellPlayerGUI
    {
        #region Inspector Fields
        [SerializeField] private TextMeshProUGUI tip;
        [SerializeField] private Slider time_slider;

        [Header("Games")]

        [SerializeField] private TestGame testGame; 
        [SerializeField] private RunestoneGame runestoneGame;
        [SerializeField] private StopWandGame stopWandGame;
        [SerializeField] private PotionGame potionGame;
        [SerializeField] private FlipCardsGame flipCardsGame;

        #endregion

        #region Private fields    
 
        private Board playerBoard;
        private GameBoard currentGame;
        private float time;

        private EffectBuilder failEffects;

        #endregion

        #region public Events

        public event Action OnTimerEnds = delegate{};

        #endregion

        #region Public Methods

        public override void SetUp(SpellerPlayer spellerPlayer)
        {
            base.SetUp(spellerPlayer);
            playerBoard = player.board;
            playerBoard.OnGenerateGame += GenerateBoardGUI;
            InitializeGames();
        }

        protected override void Init()
        {
            failEffects = new EffectBuilder(this)
            .AddEffect(new ShakeRectEffect(layout, 20, 3.5f));
            base.Init();
        }

        #endregion

        // Genera el tablero de juego con los datos del jugador:
        public void GenerateBoardGUI(Board.GameType type, int difficulty, float time)
        {
            SetTimer(time);
            switch(type)
            {
                case Board.GameType.spell: 
                    tip.text = "Pulsa las runas en orden!";
                    currentGame = runestoneGame;
                    runestoneGame.SetDifficulty(difficulty);
                    runestoneGame.Generate();
                    break;
                case Board.GameType.attack:
                    tip.text = "¡Pulsa en el momento justo!";
                    currentGame = stopWandGame;
                    stopWandGame.Generate();
                    break;
                case Board.GameType.regeneration:
                    tip.text = "¡Elige los frascos correctos!";
                    currentGame = potionGame;
                    potionGame.Generate();
                    break;
                case Board.GameType.order:
                    tip.text = "¡Encuentra todas las parejas!";
                    currentGame = flipCardsGame;
                    flipCardsGame.Generate();
                    break;
                default: break;
            }                       
        }

        private void FailListener()
        {
            failEffects.ExecuteEffects();
            time = 0;
            Invoke("NotifyFail", 0.2f);
        }

        private void SuccessListener()
        {
            time = 0;
            Events.OnCompleteGame.Invoke();
        }

        private void InitializeGames()
        {
            runestoneGame.AddSuccessListener(SuccessListener);
            runestoneGame.AddFailListener(FailListener);
            testGame.AddSuccessListener(SuccessListener);
            testGame.AddFailListener(FailListener);
            
            stopWandGame.AddSuccessListener(SuccessPowerGameListener);
            potionGame.AddSuccessListener(SuccessHealGameListener);
            flipCardsGame.AddSuccessListener(SuccessRerollGameListener);
        }

        private void SuccessPowerGameListener()
        {
            time = 0;
            Events.OnCompleteStopWandGame.Invoke();
        }

        private void SuccessHealGameListener()
        {
            time = 0;
            Events.OnCompletePotionsGame.Invoke();
        }
        private void SuccessRerollGameListener()
        {
            time = 0;
            Events.OnCompleteFlipCardsGame.Invoke();
        }

        private void SetTimer(float time)
        {
            Debug.Log("Timer: " + time);
            time_slider.maxValue = time;
            time_slider.value = time;
            this.time = time;
        }

        void Update()
        {
            if(time > 0)
            {
                time -= Time.deltaTime;
                time_slider.value = time;
                if(time < 0)
                {
                    currentGame.Clear();
                    Debug.Log("Se acabo el tiempo");
                    Events.OnTimerEnds.Invoke();
                }
            }
        }

        private void NotifyFail()
        {
            layout.rotation = new Quaternion{ eulerAngles = Vector3.zero };
            Events.OnFailGame.Invoke();
        }
        
        // No funciona: se interrumpe con las llamadas de EffectBuilder
        // private IEnumerator ClockCoroutine()
        // {
        //     var currentTime = 0f;
        //     while(currentTime < 8f)
        //     {
        //         currentTime += Time.deltaTime;
        //         Debug.Log(currentTime);
        //         yield return null;
        //     }
        // }
    }

}

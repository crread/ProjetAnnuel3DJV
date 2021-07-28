using System.Collections.Generic;
using Entity;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Scenes.MainMenu
{
    public class SceneLoader : MonoBehaviour , IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
    {
        public Text text;
        public string sceneName;
        public int idMap;

        private DDOL _ddol;
        private bool _selected = false; 
        private Color _initColor;
        private SceneLoader[] _buttonsScripts;
        private List<ScoreEntity> _scores;
        private List<ScoreEntity> _personnalScore;
        private List<GameObject> _scoreBoard;
        private GameObject _personalScoreBoard;
        private bool _isInit;

        private void Awake()
        {
            _buttonsScripts = FindObjectsOfType<SceneLoader>();
        }
        
        private void Start()
        {
            _initColor = text.color;
            _ddol = GameObject.Find("Preload").GetComponent<DDOL>();
            _scores = new List<ScoreEntity>();
            _scoreBoard = new List<GameObject>();
            _personnalScore = new List<ScoreEntity>();
            _isInit = false;

            _scoreBoard.Add(GameObject.Find("BestScoreOne"));
            _scoreBoard.Add(GameObject.Find("BestScoreTwo"));
            _scoreBoard.Add(GameObject.Find("BestScoreThree"));
            _scoreBoard.Add(GameObject.Find("BestScoreFour"));
            _scoreBoard.Add(GameObject.Find("BestScoreFive"));

            _personalScoreBoard = GameObject.Find("PersonnalBest");

            ResetScoreBoard();
        }

        private void Update()
        {
            if (_ddol.GetComponent<DDOL>().networkManager.requestTreated && _selected && !_isInit)
            {
                _isInit = true;
                
                for (var i = 0; i < _scores.Count; i++)
                {
                    _scoreBoard[i].transform.GetChild(0).GetComponent<Text>().text = _scores[i].name;
                    _scoreBoard[i].transform.GetChild(1).GetComponent<Text>().text = $"{_scores[i].score_date.Minute} : {_scores[i].score_date.Second}";
                }

                if (_personnalScore.Count > 0)
                {
                    _personalScoreBoard.transform.GetChild(0).GetComponent<Text>().text =
                        _ddol.translates.translation["campaign.boardPersonalScore"];
                    _personalScoreBoard.transform.GetChild(1).GetComponent<Text>().text =
                        $"{_personnalScore[0].score_date.Minute} : {_personnalScore[0].score_date.Second}";
                }
                
                _ddol.GetComponent<DDOL>().networkManager.requestTreated = false;
                _scores.Clear();
                _personnalScore.Clear();
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            text.color = Color.red;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!_selected)
            {
                text.color = _initColor;   
            }
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            foreach (var buttonScript in _buttonsScripts)
            {
                buttonScript.StopTargetingButton();
            }

            text.color = Color.red;
            StartTargetingButton();
            ResetScoreBoard();
            _ddol.gameData.selectedLevelName = sceneName;
            _ddol.gameData.idMap = idMap;
            
            var form = new WWWForm();
            form.AddField("map", _ddol.gameData.idMap);

            if (_ddol.player.name != null)
            {
                form.AddField("email", _ddol.player.email);
            }

            _ddol.networkManager.GetScores(form, _scores, _personnalScore);
            _isInit = false;
        }

        public void StopTargetingButton()
        {
            _selected = false;
            text.color = _initColor;
        }
        
        public void StartTargetingButton()
        {
            _selected = true;
            _isInit = false;
        }

        private void ResetScoreBoard()
        {
            foreach (var board in _scoreBoard)
            {
                if (board != null)
                {
                    board.transform.GetChild(0).GetComponent<Text>().text = "";
                    board.transform.GetChild(1).GetComponent<Text>().text = "";   
                }
            }

            _personalScoreBoard.transform.GetChild(0).GetComponent<Text>().text = "";
            _personalScoreBoard.transform.GetChild(1).GetComponent<Text>().text = "";
        }
    }
}

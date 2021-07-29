using UnityEngine;
using UnityEngine.UI;

namespace Translates
{
    public class EditorTranslate : MonoBehaviour
    {
        public GameObject cameraControlButton;
        public GameObject mapSizeButton;
        public GameObject validMapSizeButton;
        public GameObject characterButton;
        public GameObject doorButton;
        public GameObject wallButton;
        public GameObject fieldButton;
        public GameObject subWallLabel1;
        public GameObject subWallLabel2;
        public GameObject subWallLabel3;
        public GameObject subWallValidButton1;
        public GameObject subWallValidButton2;
        public GameObject subWallValidButton3;
        public GameObject subFieldLabel1;
        public GameObject subFieldLabel2;
        public GameObject subFieldLabel3;
        public GameObject subFieldValidButton1;
        public GameObject subFieldValidButton2;
        public GameObject subFieldValidButton3;
        public GameObject placeholderLoadPath;
        public GameObject validLoadPathButton;
        public GameObject loadSceneButton;
        public GameObject saveSceneButton;
        public GameObject placeholderNameFile;
        public GameObject validNameFileButton;
        public GameObject disableElementButton;
        public GameObject enableElementButton;
            
        private DDOL _ddol;
        void Start()
        {
            _ddol = GameObject.Find("Preload").GetComponent<DDOL>();
            
            cameraControlButton.GetComponent<Text>().text = _ddol.translates.translation["editor.cameraControl"];
            mapSizeButton.GetComponent<Text>().text = _ddol.translates.translation["editor.mapSize"];
            validMapSizeButton.GetComponent<Text>().text = _ddol.translates.translation["editor.validMapSize"];
            characterButton.GetComponent<Text>().text = _ddol.translates.translation["editor.character"];
            doorButton.GetComponent<Text>().text = _ddol.translates.translation["editor.door"];
            wallButton.GetComponent<Text>().text = _ddol.translates.translation["editor.wall"];
            fieldButton.GetComponent<Text>().text = _ddol.translates.translation["editor.field"];
            subWallLabel1.GetComponent<Text>().text = $"{_ddol.translates.translation["editor.subWall"]} 1";
            subWallLabel2.GetComponent<Text>().text = $"{_ddol.translates.translation["editor.subWall"]} 2";
            subWallLabel3.GetComponent<Text>().text = $"{_ddol.translates.translation["editor.subWall"]} 3";
            subWallValidButton1.GetComponent<Text>().text = _ddol.translates.translation["editor.subMenuSelect"];
            subWallValidButton2.GetComponent<Text>().text = _ddol.translates.translation["editor.subMenuSelect"];
            subWallValidButton3.GetComponent<Text>().text = _ddol.translates.translation["editor.subMenuSelect"];
            subFieldLabel1.GetComponent<Text>().text = $"{_ddol.translates.translation["editor.subField"]} 1";
            subFieldLabel2.GetComponent<Text>().text = $"{_ddol.translates.translation["editor.subField"]} 1";
            subFieldLabel3.GetComponent<Text>().text = $"{_ddol.translates.translation["editor.subField"]} 1";
            subFieldValidButton1.GetComponent<Text>().text = _ddol.translates.translation["editor.subMenuSelect"];
            subFieldValidButton2.GetComponent<Text>().text = _ddol.translates.translation["editor.subMenuSelect"];
            subFieldValidButton3.GetComponent<Text>().text = _ddol.translates.translation["editor.subMenuSelect"];
            placeholderLoadPath.GetComponent<Text>().text = _ddol.translates.translation["editor.placeholder.json"];
            validLoadPathButton.GetComponent<Text>().text = _ddol.translates.translation["editor.validPathButton"];
            loadSceneButton.GetComponent<Text>().text = _ddol.translates.translation["editor.loadSceneButton"];
            saveSceneButton.GetComponent<Text>().text = _ddol.translates.translation["editor.saveSceneButton"];
            placeholderNameFile.GetComponent<Text>().text = _ddol.translates.translation["editor.placeholder.nameFile"];
            validNameFileButton.GetComponent<Text>().text = _ddol.translates.translation["editor.validNameButton"];
            disableElementButton.GetComponent<Text>().text = _ddol.translates.translation["editor.disableElement"];
            enableElementButton.GetComponent<Text>().text = _ddol.translates.translation["editor.enableElement"];
        }
    }
}

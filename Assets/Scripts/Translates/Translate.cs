using System.Collections.Generic;
using UnityEngine;

namespace Translates
{
    public class Translate
    {
        public Dictionary<string, string> translation = new Dictionary<string, string>();
        public bool isEnglishVersionsLoaded;

        public Translate()
        {
            GenerateEnglishTranslate();
            isEnglishVersionsLoaded = true;
        }
    
        public void GenerateEnglishTranslate()
        {
            translation["mainPage.campaign"] = "Campaigns";
            translation["mainPage.newAccount"] = "New account";
            translation["mainPage.editor"] = "Editor";
            translation["mainPage.login"] = "Login";
            translation["mainPage.logout"] = "Log out";
            translation["mainPage.quitGame"] = "Quit";
            translation["mainPage.options"] = "Options";
            translation["mainPage.custom"] = "Select a personalized map";
            
            translation["network.noNetworkMessage"] = "No network available";
            
            translation["newAccount.title"] = "Create an account";
            translation["newAccount.placeholder.email"] = "Email";
            translation["newAccount.placeholder.name"] = "Name";
            translation["newAccount.placeholder.password"] = "Password";
            translation["newAccount.placeholder.validPassword"] = "Valid password";
            translation["newAccount.ValidCreateAccount"] = "Create";
            translation["newAccount.returnToMainPage"] = "Return";
            
            translation["login.title"] = "Login";
            translation["login.placeholder.email"] = "Email";
            translation["login.placeholder.password"] = "Password";
            translation["login.ValidLogin"] = "Login";
            translation["login.returnToMainPage"] = "Return";

            translation["editor.createNewMap"] = "New map";
            translation["editor.quitEditorMenu"] = "Return";

            translation["campaign.campaign"] = "Campaign";
            translation["campaign.boardPersonalScore"] = "Your best score";
            translation["campaign.boardScoreTitle"] = "Best scores for this map";
            translation["campaign.playGame"] = "Play";
            translation["campaign.quitCampaignMenu"] = "Return";
            
            translation["options.language.french"] = "French";
            translation["options.language.english"] = "English";
            translation["options.quit"] = "Return";
            
            translation["custom.quit"] = "Return";
            
            translation["game.menu.keepPlaying"] = "Continu";
            translation["game.menu.restartGame"] = "Restart";
            translation["game.menu.quitGame"] = "Quit";
            
            translation["game.endGame.win.title"] = "Congrulation, you achieved this map in : ";
            translation["game.endGame.win.mainMenu"] = "Main menu";
            translation["game.endGame.lose.title"] = "You lose !";
            translation["game.endGame.restart"] = "Play again";
            translation["game.endGame.quit"] = "Quit";
            
            translation["editor.cameraControl"] = "Camera control";
            translation["editor.mapSize"] = "Map size";
            translation["editor.validMapSize"] = "Valid";
            translation["editor.character"] = "Characters";
            translation["editor.door"] = "Door";
            
            translation["editor.wall"] = "Wall";
            translation["editor.subField"] = "Field";
            translation["editor.field"] = "Field";
            translation["editor.subWall"] = "Wall";
            translation["editor.subMenuSelect"] = "Select";
            
            translation["editor.placeholder.json"] = "saved file path";
            translation["editor.placeholder.nameFile"] = "Name file";
            translation["editor.validPathButton"] = "Valid path";
            
            translation["editor.loadSceneButton"] = "Load Scene";
            translation["editor.saveSceneButton"] = "Save Scene";
            translation["editor.validNameButton"] = "Valid name";

            translation["editor.disableElement"] = "Disable element";
            translation["editor.enableElement"] = "Enable element";
        }
                
        public void GenerateFrenchTranslate()
        {
            translation["mainPage.campaign"] = "Campagnes";
            translation["mainPage.newAccount"] = "Créer un compte";
            translation["mainPage.editor"] = "Editeur";
            translation["mainPage.login"] = "Connexion";
            translation["mainPage.logout"] = "Déconnexion";
            translation["mainPage.quitGame"] = "Quitter";
            translation["mainPage.options"] = "Options";
            translation["mainPage.custom"] = "Sélectionne une map personnalisé";
            
            translation["network.noNetworkMessage"] = "internet indisponible";
            
            translation["newAccount.title"] = "Créer un compte";
            translation["newAccount.placeholder.email"] = "Email";
            translation["newAccount.placeholder.name"] = "Nom";
            translation["newAccount.placeholder.password"] = "Mot de passe";
            translation["newAccount.placeholder.validPassword"] = "Mot de masse";
            translation["newAccount.ValidCreateAccount"] = "Créer";
            translation["newAccount.returnToMainPage"] = "Retour";
            
            translation["login.title"] = "Connexion";
            translation["login.placeholder.email"] = "Email";
            translation["login.placeholder.password"] = "Mot de passe";
            translation["login.ValidLogin"] = "Connexion";
            translation["login.returnToMainPage"] = "Retour";

            translation["editor.createNewMap"] = "Nouvelle carte";
            translation["editor.quitEditorMenu"] = "Retour";

            translation["campaign.campaign"] = "Campagne";
            translation["campaign.boardPersonalScore"] = "Votre meilleur score";
            translation["campaign.boardScoreTitle"] = "Les meilleurs scores";
            translation["campaign.playGame"] = "Jouer";
            translation["campaign.quitCampaignMenu"] = "Retour";
            
            translation["options.language.french"] = "Français";
            translation["options.language.english"] = "Anglais";
            translation["options.quit"] = "Retour";

            translation["custom.quit"] = "Retour";
            
            translation["game.menu.keepPlaying"] = "Continuer";
            translation["game.menu.restartGame"] = "Recommencer le niveau";
            translation["game.menu.quitGame"] = "Quitter le niveau";
            
            translation["game.endGame.win.title"] = "Félicitation, tu as fini le niveau en :";
            translation["game.endGame.lose.title"] = "Tu as perdu !";
            translation["game.endGame.win.mainMenu"] = "Menu princpical";
            translation["game.endGame.restart"] = "Rejouer";
            translation["game.endGame.quit"] = "Quitter";

            translation["editor.cameraControl"] = "Controle caméra";
            translation["editor.mapSize"] = "taille de la carte";
            translation["editor.validMapSize"] = "Validé";
            translation["editor.character"] = "Personnages";
            translation["editor.door"] = "Portes";
            
            translation["editor.wall"] = "Murs";
            translation["editor.subField"] = "Terrain";
            translation["editor.field"] = "Terrains";
            translation["editor.subWall"] = "Mur";
            translation["editor.subMenuSelect"] = "Choisir";
            
            translation["editor.placeholder.json"] = "Emplacement de la sauvegarde";
            translation["editor.placeholder.nameFile"] = "Nom du fichier";
            translation["editor.validPathButton"] = "Validé le chemin";
            
            translation["editor.loadSceneButton"] = "Chargé la scène";
            translation["editor.saveSceneButton"] = "Sauvegardé la scène";
            translation["editor.validNameButton"] = "Validé le nom";

            translation["editor.disableElement"] = "Désactivé élément";
            translation["editor.enableElement"] = "Activé élément";
        }
    }
}

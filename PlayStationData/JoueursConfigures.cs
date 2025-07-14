using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PlayStationData
{
    public class JoueursConfigures
    {
        //Fields
        #region Fields

        // List of joueurs
        List<Joueur> _joueurs = null;
        public List<Joueur> Joueurs
        {
            get { return _joueurs; }
            set { _joueurs = value; }
        }

        //Add last id mngt
        private int _newValidId = -1;

        public int NewValidId
        {
            get { return _newValidId; }
            set { _newValidId = value; }
        }

        #endregion Fields

        #region Public services

        /// <summary>
        /// Check if players name already added
        /// </summary>
        public bool IsValidPlayerName(string playerName)
        {
            // Check name
            if (String.IsNullOrEmpty(playerName))
                return false;

            // Check if name already added
            bool bFound = _joueurs.Any(item => string.Equals(item.Nom, playerName, StringComparison.OrdinalIgnoreCase));

            // Check if found
            if (bFound == true)
                return false;

            return true;
        }

        /// <summary>
        /// Check if players name already added
        /// </summary>
        public int GetNumberOfPlayers()
        {
            return _joueurs.Count;
        }

        /// <summary>
        /// Add new players
        /// </summary>
        public void AddNewPlayer(Joueur newPlayer)
        {
            //----------------
            //- Check values -
            //----------------
            // Check name
            if (string.IsNullOrEmpty(newPlayer.Nom))
            {
                PlayStationException err = new PlayStationException("Nom du joueur invalide", Err.invalid_player_name);
                throw err;
            }
            // Check if name exist
            else if (!IsValidPlayerName(newPlayer.Nom))
            {
                PlayStationException err = new PlayStationException("Nom de joueur déja utilisé", Err.invalid_player_name);
                throw err;
            }
            // Check team
            else if (string.IsNullOrEmpty(newPlayer.Equipe))
            {
                PlayStationException err = new PlayStationException("Nom de l'équipe invalide", Err.invalid_player_team);
                throw err;
            }
            // Check id
            else if (_newValidId != newPlayer.Id)
            {
                PlayStationException err = new PlayStationException("ID joueur invalide", Err.invalid_player_id);
                throw err;
            }
            
            //------------------
            //- Add new player -
            //------------------
            newPlayer.Numero = GetNumberOfPlayers()+1;
            _joueurs.Add(newPlayer);

            // Update new valid id
            _newValidId++;
        }

        /// <summary>
        /// Add new players
        /// </summary>
        public void AddNewPlayer(string name, string team, int id)
        {
            // Create player
            Joueur joueur = new Joueur();
            joueur.Nom = name;
            joueur.Equipe = team;
            joueur.Id = id;

            // Add player
            AddNewPlayer(joueur);
        }

        /// <summary>
        /// Add new players
        /// </summary>
        public void RemovePlayer(Joueur player)
        {
            _joueurs.Remove(player);
        }

        #endregion Public services
    }
}

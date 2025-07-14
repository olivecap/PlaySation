using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlayStationData
{
    public class Joueurs : List<Joueur>
    {
        #region Fileds

        // Random object
        private Random _randomObject = new Random();  

        //Joueur exemp
        Joueur _joueurExempt = null;

        public Joueur JoueurExempt
        {
            get { return _joueurExempt; }
            set { _joueurExempt = value; }
        }

        #endregion Fileds

        #region public services

        /// <summary>
        /// Check if joueur already added
        /// </summary>
        /// <param name="joueurToCheck"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public bool IsValidPlayer(Joueur joueurToCheck, bool throwException)
        {
            // Check new player
            if (joueurToCheck == null)
            {
                if (throwException == true)
                    throw new PlayStationException("Invalide joueur", Err.default_value);
                else
                    return false;
            }

            // Check name
            if (String.IsNullOrEmpty(joueurToCheck.Nom))
            {
                if (throwException == true)
                    throw new PlayStationException("Nom du joueur invalide", Err.invalid_player_name);
                else
                    return false;
            }

            // Check team
            if (String.IsNullOrEmpty(joueurToCheck.Equipe))
            {
                if (throwException == true)
                    throw new PlayStationException("Equipe du joueur invalide", Err.invalid_player_team);
                else
                    return false;
            }

            // Check team
            if (joueurToCheck.Id < 0)
            {
                if (throwException == true)
                    throw new PlayStationException("Id du joueur invalide", Err.invalid_player_team);
                else
                    return false;
            }

            // Check if name already added
            bool bFound = this.Any(item => item.Id == joueurToCheck.Id);

            // Check if found
            if (bFound == true)
            {
                if (throwException == true)
                    throw new PlayStationException("Le joueur a déjà été ajouté dans la liste", Err.player_already_added);
                else
                    return false;
            };

            return true;
        }

        /// <summary>
        /// Ajout d'un nouveau joueur
        /// </summary>
        /// <param name="joueurToAdd"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public bool AddNewPlayer(Joueur joueurToAdd, bool throwException)
        {
            // Check new player
            bool bValidJoueur = IsValidPlayer(joueurToAdd, throwException);
            if (!bValidJoueur)
            {
                if (throwException == true)
                    throw new PlayStationException("Impossible d'ajouter le joueur", Err.err_add_player);
                else
                    return false;
            }

            // Add new player
            Add(joueurToAdd);

            return true;
        }

        public void SortRandomlyListOfPlayers()
        {
            // Get count
            int n = this.Count;

            // iterator thraugh list
            while (n > 1)
            {
                // Decrease inc
                n--;

                // Create random index
                int k = _randomObject.Next(n + 1);

                // Sort list
                Joueur value = this[k];
                this[k] = this[n];
                this[k].Numero = k+1;
                this[n] = value;
                this[n].Numero = n+1;
            }
        }

        #endregion public services
    }
}

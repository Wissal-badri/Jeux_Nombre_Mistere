// Ce code définit la classe Game qui contient la logique du jeu "Jeu du Nombre Mystère".
using System;
//Declaration de l'espace de noms pour organiser le code et éviter les conflits de noms
namespace JeuxNombreM
{
    // La classe Game encapsule toute la logique du jeu, y compris la génération du nombre mystère, la gestion des entrées utilisateur et les vérifications des propositions
    internal class Game
    {
        // Instance de la classe Random pour générer des nombres aléatoires
        private Random random = new Random();

        // Génère et retourne un nombre aléatoire entre min et max (inclus)
        private int GenerateRandomNumber(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        // Demande à l'utilisateur d'entrer un nombre et le retourne sous forme d'entier (avec validation des bornes)
        private int GetUserGuess(int min, int max, string prefixMessage = "")
        {
            Console.Write($"{prefixMessage}Veuillez entrer un nombre entre {min} et {max} : ");
            int guess;
            // Boucle de validation pour s'assurer que l'utilisateur saisit un nombre entier valide et dans le bon intervalle
            while (!int.TryParse(Console.ReadLine(), out guess) || guess < min || guess > max)
            {
                Console.WriteLine($"Entrée invalide. Le nombre doit être compris entre {min} et {max}.");
                Console.Write($"{prefixMessage}Veuillez entrer un nombre entre {min} et {max} : ");
            }
            return guess;
        }

        // Compare la proposition de l'utilisateur avec le nombre cible et affiche un message
        private bool CheckGuess(int guess, int target)
        {
            if (guess == target)
            {
                Console.WriteLine("Bravo ! Vous avez trouvé le nombre mystère !");
                return true;
            }

            if (guess < target)
            {
                Console.WriteLine("C'est plus grand !");
            }
            else
            {
                Console.WriteLine("C'est plus petit !");
            }

            return false;
        }

        // Exécute la logique principale du jeu
        internal void Start()
        {
            Console.WriteLine("Choisissez le mode de jeu :");
            Console.WriteLine("1 - Mode Solo (1 joueur, 3 tentatives)");
            Console.WriteLine("2 - Mode Duel (2 joueurs, tour par tour, 3 tentatives par joueur)");
            Console.Write("Votre choix (1 ou 2) : ");
            
            string modeChoice = Console.ReadLine();
            bool isDualMode = (modeChoice == "2");

            // Définition des bornes globales du jeu
            int minGlobal = 1;
            int maxGlobal = 100;
            
            // Génération du nombre cible
            int target = GenerateRandomNumber(minGlobal, maxGlobal);
            bool found = false;
            
            // Gestion du nombre de tentatives (3 en mode solo, 6 au total en duel => 3 par joueur)
            int maxAttempts = isDualMode ? 6 : 3;
            int attempts = 0;

            // Intervalle courant (évolue au fil des tentatives)
            int currentMin = minGlobal;
            int currentMax = maxGlobal;

            int currentPlayer = 1;

            // Boucle jusqu'à ce que l'utilisateur trouve le nombre cible ou n'a plus de tentatives
            while (!found && attempts < maxAttempts)
            {
                string playerPrefix = isDualMode ? $"[Joueur {currentPlayer}] " : "";
                
                int tentativeJoueur = isDualMode ? (attempts / 2) + 1 : attempts + 1;
                Console.WriteLine($"\n--- {playerPrefix}Tentative {tentativeJoueur} sur 3 ---");
                
                // On demande le nombre en utilisant l'intervalle mis à jour
                int guess = GetUserGuess(currentMin, currentMax, playerPrefix);
                attempts++;
                
                found = CheckGuess(guess, target);

                if (found)
                {
                    if (isDualMode)
                    {
                        Console.WriteLine($"Félicitations au Joueur {currentPlayer}, tu as gagné !");
                    }
                    break;
                }

                // Si le joueur n'a pas trouvé et qu'il reste des tentatives pour quelqu'un, on donne l'indice
                if (!found && attempts < maxAttempts)
                {
                    // Calcul du nouvel intervalle pour réduire la plage
                    int borneInf = target - 5;
                    int borneSup = target + 5;

                    // On s'assure que le nouvel intervalle ne sort pas des bornes globales 1..100
                    if (borneInf < minGlobal) borneInf = minGlobal;
                    if (borneSup > maxGlobal) borneSup = maxGlobal;

                    // Mise à jour de l'intervalle pour la prochaine proposition
                    currentMin = borneInf;
                    currentMax = borneSup;

                    Console.WriteLine($"L'indice : Il est entre {currentMin} et {currentMax}.");

                    // Changement de joueur si on est en mode duel
                    if (isDualMode)
                    {
                        currentPlayer = (currentPlayer == 1) ? 2 : 1;
                    }
                }
            }

            // Si le nombre n'a pas été trouvé après l'épuisement des tentatives
            if (!found)
            {
                Console.WriteLine($"\nDommage ! Les tentatives sont épuisées.");
                Console.WriteLine($"Le nombre mystère était : {target}");
            }

            Console.WriteLine("Merci d'avoir joué !");
        }
    }
}
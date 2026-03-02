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
        private int GetUserGuess(int min, int max)
        {
            Console.Write($"Veuillez entrer un nombre entre {min} et {max} : ");
            int guess;
            // Boucle de validation pour s'assurer que l'utilisateur saisit un nombre entier valide
            while (!int.TryParse(Console.ReadLine(), out guess) || guess < min || guess > max)
            {
                Console.WriteLine($"Entrée invalide. Le nombre doit être compris entre {min} et {max}.");
                Console.Write($"Veuillez entrer un nombre entre {min} et {max} : ");
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

            // Calcul de l'intervalle pour donner un indice
            int borneInf = target - 5;
            int borneSup = target + 5;
            Console.WriteLine($"Vous êtes proche ! Il est entre {borneInf} et {borneSup}.");

            return false;
        }

        // Exécute la logique principale du jeu
        internal void Start()
        {
            // Définition des bornes
            int min = 1;
            int max = 100;
            
            // Génération du nombre cible
            int target = GenerateRandomNumber(min, max);
            bool found = false;
            
            // Gestion du nombre de tentatives
            int maxAttempts = 3;
            int attempts = 0;

            // Boucle jusqu'à ce que l'utilisateur trouve le nombre cible ou n'a plus de tentatives
            while (!found && attempts < maxAttempts)
            {
                Console.WriteLine($"--- Tentative {attempts + 1} sur {maxAttempts} ---");
                int guess = GetUserGuess(min, max);
                attempts++;
                
                found = CheckGuess(guess, target);
            }

            // Si le joueur n'a pas trouvé après ses 3 tentatives
            if (!found)
            {
                Console.WriteLine($"\nDommage ! Vous avez épuisé vos {maxAttempts} tentatives.");
                Console.WriteLine($"Le nombre mystère était : {target}");
            }

            Console.WriteLine("Merci d'avoir joué !");
        }
    }
}
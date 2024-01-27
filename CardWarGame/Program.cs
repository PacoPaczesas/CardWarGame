using Deck;
using Cards;

List<Card> deck = new List<Card>();
deck = UsingDeck.CreateDeck();

List<Card> playerADeck = new List<Card>();
List<Card> playerAGraveyard = new List<Card>();
List<Card> playerBDeck = new List<Card>();
List<Card> playerBGraveyard = new List<Card>();
List<Card> pull = new List<Card>();

Random random = new Random();
int rand;
Card drawCard;
int turnOfPlayer = 1;

do
{
    rand = random.Next(0, deck.Count());
    drawCard = deck[rand];
    deck.RemoveAt(rand);
    if (turnOfPlayer == 1)
    {
        playerADeck.Add(drawCard);
        turnOfPlayer = 2;
    }
    else
    {
        playerBDeck.Add(drawCard);
        turnOfPlayer = 1;
    }
} while (deck.Count() != 0);

Console.WriteLine(playerADeck.Count());
Console.WriteLine(playerBDeck.Count());

Card playerACard = null;
Card playerBCard = null;

string winner = null;
bool gameOver = false;

while (!gameOver)
{   
    //sprawdzanie gotowości graczy Jeżeli gracz ma za mało kart gameOver przyjmuje wartość true
    if (UsingDeck.ReadyCheck(playerADeck, playerAGraveyard) == true)
    {
        winner = "Gracz B";
    }

    if (UsingDeck.ReadyCheck(playerBDeck, playerBGraveyard) == true)
    {
        winner = "Gracz A";
    }
    //jeżeli nie mamy kart w tali a mamy na stosie kart odrzuconych to wtasowujemy je do tali
    if (playerADeck.Count() < 1 && playerAGraveyard.Count() > 0)
    {
        playerADeck = UsingDeck.ShufflingCards(playerAGraveyard);
    }
    if (playerBDeck.Count() < 1 && playerBGraveyard.Count() > 0)
    {
        playerBDeck = UsingDeck.ShufflingCards(playerBGraveyard);
    }

    //jeszcze raz sprawdzamy czy gracze jaką czym grać. Romimy to ponieważ jeżeli gracz A nie ma czym grać to game over ma wartość true ale potem wartość jest zmianiana na false przy graczu B, który ma jeszcze karty
    if (playerADeck.Count() < 1 || playerBDeck.Count() < 1)
    {
        gameOver = true;
    }

    if (gameOver == false)
    {
        //losujemy karte dla gracza A
        rand = random.Next(0, playerADeck.Count());
        playerACard = playerADeck[rand];
        playerADeck.RemoveAt(rand);
        pull.Add(playerACard);

        //losujemy karte dla gracza B
        rand = random.Next(0, playerBDeck.Count());
        playerBCard = playerBDeck[rand];
        playerBDeck.RemoveAt(rand);
        pull.Add(playerBCard);

        if (playerACard.value > playerBCard.value)
        {
            Console.WriteLine("wylosowano dla gracz A: " + playerACard.name);
            Console.WriteLine("wylosowano dla gracz B: " + playerBCard.name);
            Console.WriteLine("Wygrywa gracz A i zbiera karty ze stołu");
            playerAGraveyard = UsingDeck.AddFromPull(playerAGraveyard, pull);
            pull.Clear();
        }
        else if (playerACard.value < playerBCard.value)
        {
            Console.WriteLine("wylosowano dla gracz A: " + playerACard.name);
            Console.WriteLine("wylosowano dla gracz B: " + playerBCard.name);
            Console.WriteLine("Wygrywa gracz B i zbiera karty ze stołu");
            playerBGraveyard = UsingDeck.AddFromPull(playerBGraveyard, pull);
            pull.Clear();
        }
        // w razie remisu dzieje się poniższe. Gracze dokładają jeszcze po jednej karcie. W zasadzie jest to kopia powyższego z tą różnicą, że karty są niewidoczne.
        else
        {
            Console.WriteLine("wylosowano dla gracz A: " + playerACard.name);
            Console.WriteLine("wylosowano dla gracz B: " + playerBCard.name);
            Console.WriteLine("Remis. Gracze odkładają po jednej zakrytej karcie.");

            gameOver = UsingDeck.ReadyCheck(playerADeck, playerAGraveyard);
            if (gameOver == true)
            {
                winner = "gracz B";
            }

            gameOver = UsingDeck.ReadyCheck(playerBDeck, playerBGraveyard);
            if (gameOver == true)
            {
                winner = "gracz A";
            }

            if (playerADeck.Count() < 1 && playerAGraveyard.Count() > 0)
            {
                playerADeck = UsingDeck.ShufflingCards(playerAGraveyard);
            }
            if (playerBDeck.Count() < 1 && playerBGraveyard.Count() > 0)
            {
                playerBDeck = UsingDeck.ShufflingCards(playerBGraveyard);
            }

            if (playerADeck.Count() < 1 || playerBDeck.Count() < 1)
            {
                gameOver = true;
            }

            if (gameOver == false)
            {
                rand = random.Next(0, playerADeck.Count());
                playerACard = playerADeck[rand];
                playerADeck.RemoveAt(rand);
                pull.Add(playerACard);

                rand = random.Next(0, playerBDeck.Count());
                playerBCard = playerBDeck[rand];
                playerBDeck.RemoveAt(rand);
                pull.Add(playerBCard);

            }
        }
    }
}

Console.WriteLine("Koniec gry. Wygrywa gracz: " + winner);

Console.ReadKey();
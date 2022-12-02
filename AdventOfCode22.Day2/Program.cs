string inputText = File.ReadAllText("puzzleInput.txt");

var gameTuples = inputText.Split("\r\n").Select(game => game.Split(" "));

Console.WriteLine(gameTuples.Sum(gameTuple => GetTotalGameScore(gameTuple)));

int GetTotalGameScore(string[] gameTuple)
{
    RPS opponentPlays = GetOpponentRPS(gameTuple[0]);
    RPS youPlay = GetYourRPS(opponentPlays, gameTuple[1]);
    int totalScore = (int)youPlay;
    totalScore += GetGameScore(opponentPlays, youPlay);
    return totalScore;
}

int GetGameScore(RPS opponent, RPS you)
{
    if ((int) you == (int) opponent) return 3;
    else if (you == RPS.R && opponent == RPS.S) return 6;
    else if (you == RPS.R && opponent == RPS.P) return 0;
    else if (you == RPS.P && opponent == RPS.R) return 6;
    else if (you == RPS.P && opponent == RPS.S) return 0;
    else if (you == RPS.S && opponent == RPS.P) return 6;
    else return 0;
}

RPS GetOpponentRPS(string played)
{
    if (played == "A") return RPS.R;
    else if (played == "B") return RPS.P;
    else return RPS.S;
}

RPS GetYourRPS(RPS opponentPlayed, string played)
{
    if (played == "X")
    {
        if (opponentPlayed == RPS.R) return RPS.S;
        else if (opponentPlayed == RPS.P) return RPS.R;
        else return RPS.P;
    }
    else if (played == "Y") return opponentPlayed;
    else
    {
        if (opponentPlayed == RPS.R) return RPS.P;
        else if (opponentPlayed == RPS.P) return RPS.S;
        else return RPS.R;
    }
}

enum RPS
{
    R = 1,
    P = 2,
    S = 3
}
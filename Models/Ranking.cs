public static class Ranking
{
    public static Dictionary<string, TimeSpan> DicRanking { private set; get; } = new Dictionary<string, TimeSpan>();
    public static void AgregarUsuario(string NomUsu, TimeSpan Tiempo)
    {
        if (string.IsNullOrWhiteSpace(NomUsu))
            return;

        if (!DicRanking.ContainsKey(NomUsu))
            DicRanking.Add(NomUsu, Tiempo);
    }
    public static Dictionary<string, TimeSpan> ObtenerRankingOrdenadoDic()
    {
        return DicRanking
         .OrderBy(pair => pair.Value)
         .ToDictionary(pair => pair.Key, pair => pair.Value);
    }
}
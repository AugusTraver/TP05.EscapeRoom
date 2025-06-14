
using Newtonsoft.Json;
namespace Tp05.EscapeRoom.Models;
public class Escaperoom
{
    [JsonProperty]
    public int nivel { private set; get; }
    [JsonProperty]
    public Dictionary<int, string> pistas { private set; get; }
    [JsonProperty]
    public Dictionary<int, string> respuestas { private set; get; }
    public string NomUsu { private set; get; }
    public Escaperoom(string PNomUsu)
    {
        NomUsu = PNomUsu;
        nivel = 1;
        pistas = new Dictionary<int, string>();
        respuestas = new Dictionary<int, string>();
        pistas.Add(1, "Fijate en la grulla");
        pistas.Add(2, "Mira el nombre del barco");
        pistas.Add(3, "El video esta en loop, no toques para asi no pausarlo, apagado vale 0, titleo 1 y prendido 2, pone el codigo y pasa a la siguiente sala, termina cuando esta apagada");
        pistas.Add(4, "Fijate en el locer 7 y en el video cuando dice aguas...");
        pistas.Add(5, "Para sacar la calle mira la carta y para sacar el numero mira el plano");
        respuestas.Add(1, "ORIGAMI");
        respuestas.Add(2, "CHRISTINAROSE");
        respuestas.Add(3, "21210");
        respuestas.Add(4, "AGUAS TERMALES");
        respuestas.Add(5, "FOX RIVER ROAD 42");
    }
    public void CompararRespuesta(string RespuestaUsuario)
    {
        if (RespuestaUsuario == respuestas[nivel])
        {
            nivel++;
        }
    }
    public string DevolverPista()
    {
        return pistas[nivel];
    }
    
}
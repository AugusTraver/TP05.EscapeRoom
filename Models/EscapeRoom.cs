
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
    [JsonProperty]
    public string NomUsu { private set; get; }
    [JsonProperty]
    public DateTime TiempoInicio { private set; get; }
        
        [JsonProperty]
    public DateTime TiempoFinalizo { private set; get; }
    public Escaperoom(string PNomUsu, DateTime Hora)
    {
        TiempoInicio = Hora;
        NomUsu = PNomUsu;
        nivel = 1;
        pistas = new Dictionary<int, string>();
        respuestas = new Dictionary<int, string>();
        pistas.Add(1, "Fijate en la grulla");
        pistas.Add(2, "Mira el nombre del barco");
        pistas.Add(3, "El video esta en loop, no toques para asi no pausarlo, apagado vale 0, titleo 1 y prendido 2, pone el codigo y pasa a la siguiente sala, termina cuando esta apagada y tiene 5 digitos");
        pistas.Add(4, "Agua....");
        pistas.Add(5, " Toca los botones en el orden correcto para pasar");
        respuestas.Add(1, "ORIGAMI");
        respuestas.Add(2, "CHRISTINAROSE");
        respuestas.Add(3, "21210");
        respuestas.Add(4, "AGUATEMPLADA");
        respuestas.Add(5, "1234");
    }
    public void CompararRespuesta(string RespuestaUsuario)
    {

        if (RespuestaUsuario == respuestas[nivel])
        {
            nivel++;
        }
        if (nivel == 6)
        {
            TiempoFinalizo = DateTime.Now;
            TimeSpan tiempoTranscurrido = TiempoFinalizo - TiempoInicio;
            Console.WriteLine($"Inicio: {TiempoInicio}, Fin: {TiempoFinalizo}");
            Ranking.AgregarUsuario(NomUsu, tiempoTranscurrido);
        }
    }
    public string DevolverPista()
    {
        return pistas[nivel];
    }

}
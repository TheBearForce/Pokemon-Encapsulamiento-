using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Pokemon
{
    public class Pokemon
    {
        public string Nombre { get; set; }
        public int Nivel { get; set; }
        public string TipoPrimario { get; set; }
        public string TipoSecundario { get; set; }
        public string CaracteristicaPrincipal { get; set; }
        public List<string> Habilidades { get; set; }

        public string ObtenerResumen()
        {
            string tipo = TipoPrimario;
            if (!string.IsNullOrWhiteSpace(TipoSecundario))
                tipo += "/" + TipoSecundario;

            return $"{Nombre} - Nivel {Nivel} - Tipo: {tipo}";
        }

        public string ObtenerDetalle()
        {
            return $"Nombre: {Nombre}\n" +
                   $"Nivel: {Nivel}\n" +
                   $"Tipo: {TipoPrimario}" + (string.IsNullOrWhiteSpace(TipoSecundario) ? "" : $"/{TipoSecundario}") + "\n" +
                   $"Características: {CaracteristicaPrincipal}\n" +
                   $"Habilidades: {string.Join(", ", Habilidades)}";
        }
    }
    public static class Pokedex
    {
        private static readonly string rutaArchivo = "pokemons.json";

        public static List<Pokemon> Cargar()
        {
            if (!File.Exists(rutaArchivo))
            {
                var listaVacia = new List<Pokemon>();
                Guardar(listaVacia);
                return listaVacia;
            }

            string json = File.ReadAllText(rutaArchivo);
            return JsonConvert.DeserializeObject<List<Pokemon>>(json);
        }

        public static void Guardar(List<Pokemon> pokemones)
        {
            string json = JsonConvert.SerializeObject(pokemones, Formatting.Indented);
            File.WriteAllText(rutaArchivo, json);
        }
    }
}

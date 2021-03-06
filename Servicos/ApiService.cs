using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Aplicação_mvc_Principal.Models;
using Newtonsoft.Json;

namespace Aplicação_mvc_Principal.Servicos
{
  public class ApiService
  {

    public static async Task<List<Vaga>> GetVagas()
    {
      
      HttpClient http = new HttpClient();
      
      var response = await http.GetAsync("https://localhost:8081/Vagas");
      if(response.IsSuccessStatusCode)
      {
        var resultado = response.Content.ReadAsStringAsync().Result;
        var vagas = JsonConvert.DeserializeObject<List<Vaga>>(resultado);
        return vagas;
      }

      return new List<Vaga>();
    }


    public static async Task<List<Candidato>> GetCandidatos()
    {
      HttpClient http = new HttpClient();
      var response = await http.GetAsync("https://localhost:8081/Candidatos");
      if(response.IsSuccessStatusCode)
      {
        var resultado = response.Content.ReadAsStringAsync().Result;
        var candidatos = JsonConvert.DeserializeObject<List<Candidato>>(resultado);
        return candidatos;
      }

      return new List<Candidato>();
    }


  }
}
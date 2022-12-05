using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace Chamador.CrossCutting
{
    public class AD
    {
        public IConfiguration _configuration { get; }
        
        public AD(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> DesbloquearContaUsuario(string usuario, string dominio, string token)
        {

            var retorno = string.Empty;
            string uri = _configuration.GetSection("ADUrl").Value;
            uri += $"/Usuario/DesbloquearContaUsuario?conta={usuario}&dominio={dominio}";

            var dd = new Paths();

            var ee = dd.apiADUsuarioDesbloquearContaUsuario.ToString();

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.PostAsync(uri, null);
            if (response.IsSuccessStatusCode)
            {
                retorno = await response.Content.ReadAsStringAsync();
                return retorno;
            }
            return retorno;
        }

        public class _200
        {
            public string description { get; set; }
            public Content content { get; set; }
        }

        public class ApiADGrupoBuscarDadosGrupo
        {
            public Get get { get; set; }
        }

        public class ApiADGrupoBuscarGrupoMembros
        {
            public Get get { get; set; }
        }

        public class ApiADGrupoCriarGrupo
        {
            public Post post { get; set; }
        }

        public class ApiADGrupoExcluirGrupo
        {
            public Delete delete { get; set; }
        }

        public class ApiADUsuarioBuscarUsuario
        {
            public Get get { get; set; }
        }

        public class ApiADUsuarioDesabilitarContaUsuario
        {
            public Post post { get; set; }
        }

        public class ApiADUsuarioDesbloquearContaUsuario
        {
            public Post post { get; set; }
        }

        public class ApiADUsuarioExcluirUsuario
        {
            public Delete delete { get; set; }
        }

        public class ApiADUsuarioGrupoBuscarGruposUsuario
        {
            public Get get { get; set; }
        }

        public class ApiADUsuarioGrupoIncluirUsuarioGrupo
        {
            public Post post { get; set; }
        }

        public class ApiADUsuarioGrupoIncluirUsuarioGrupoBulk
        {
            public Post post { get; set; }
        }

        public class ApiADUsuarioGrupoRemoverUsuarioGrupo
        {
            public Delete delete { get; set; }
        }

        public class ApiADUsuarioHabilitarContaUsuario
        {
            public Post post { get; set; }
        }

        public class ApiADUsuarioTrocarSenhaUsuario
        {
            public Post post { get; set; }
        }

        public class ApiADUsuarioVerificarContaUsuarioBloqueada
        {
            public Get get { get; set; }
        }

        public class ApplicationJson
        {
            public Schema schema { get; set; }
        }

        public class ApplicationJson7
        {
            public Schema schema { get; set; }
        }

        public class Bearer
        {
            public string type { get; set; }
            public string description { get; set; }
            public string name { get; set; }
            public string @in { get; set; }
        }

        public class Components
        {
            public SecuritySchemes securitySchemes { get; set; }
        }

        public class Content
        {
            [JsonProperty("text/plain")]
            public TextPlain textplain { get; set; }

            [JsonProperty("application/json")]
            public ApplicationJson applicationjson { get; set; }

            [JsonProperty("text/json")]
            public TextJson textjson { get; set; }

            //[JsonProperty("application/*+json")]
            //public ApplicationJson applicationjson { get; set; }
        }

        public class Delete
        {
            public List<string> tags { get; set; }
            public List<Parameter> parameters { get; set; }
            public Responses responses { get; set; }
        }

        public class Get
        {
            public List<string> tags { get; set; }
            public List<Parameter> parameters { get; set; }
            public Responses responses { get; set; }
        }

        public class Info
        {
            public string title { get; set; }
            public string version { get; set; }
        }

        public class Items
        {
            public string type { get; set; }
        }

        public class Parameter
        {
            public string name { get; set; }
            public string @in { get; set; }
            public Schema schema { get; set; }
        }

        public class Paths
        {
            [JsonProperty("/api/AD/Grupo/CriarGrupo")]
            public ApiADGrupoCriarGrupo apiADGrupoCriarGrupo { get; set; }

            [JsonProperty("/api/AD/Grupo/ExcluirGrupo")]
            public ApiADGrupoExcluirGrupo apiADGrupoExcluirGrupo { get; set; }

            [JsonProperty("/api/AD/Grupo/BuscarDadosGrupo")]
            public ApiADGrupoBuscarDadosGrupo apiADGrupoBuscarDadosGrupo { get; set; }

            [JsonProperty("/api/AD/Grupo/BuscarGrupoMembros")]
            public ApiADGrupoBuscarGrupoMembros apiADGrupoBuscarGrupoMembros { get; set; }

            [JsonProperty("/api/AD/Usuario/BuscarUsuario")]
            public ApiADUsuarioBuscarUsuario apiADUsuarioBuscarUsuario { get; set; }

            [JsonProperty("/api/AD/Usuario/ExcluirUsuario")]
            public ApiADUsuarioExcluirUsuario apiADUsuarioExcluirUsuario { get; set; }

            [JsonProperty("/api/AD/Usuario/DesbloquearContaUsuario")]
            public ApiADUsuarioDesbloquearContaUsuario apiADUsuarioDesbloquearContaUsuario { get; set; }

            [JsonProperty("/api/AD/Usuario/DesabilitarContaUsuario")]
            public ApiADUsuarioDesabilitarContaUsuario apiADUsuarioDesabilitarContaUsuario { get; set; }

            [JsonProperty("/api/AD/Usuario/HabilitarContaUsuario")]
            public ApiADUsuarioHabilitarContaUsuario apiADUsuarioHabilitarContaUsuario { get; set; }

            [JsonProperty("/api/AD/Usuario/VerificarContaUsuarioBloqueada")]
            public ApiADUsuarioVerificarContaUsuarioBloqueada apiADUsuarioVerificarContaUsuarioBloqueada { get; set; }

            [JsonProperty("/api/AD/Usuario/TrocarSenhaUsuario")]
            public ApiADUsuarioTrocarSenhaUsuario apiADUsuarioTrocarSenhaUsuario { get; set; }

            [JsonProperty("/api/AD/UsuarioGrupo/IncluirUsuarioGrupo")]
            public ApiADUsuarioGrupoIncluirUsuarioGrupo apiADUsuarioGrupoIncluirUsuarioGrupo { get; set; }

            [JsonProperty("/api/AD/UsuarioGrupo/IncluirUsuarioGrupoBulk")]
            public ApiADUsuarioGrupoIncluirUsuarioGrupoBulk apiADUsuarioGrupoIncluirUsuarioGrupoBulk { get; set; }

            [JsonProperty("/api/AD/UsuarioGrupo/RemoverUsuarioGrupo")]
            public ApiADUsuarioGrupoRemoverUsuarioGrupo apiADUsuarioGrupoRemoverUsuarioGrupo { get; set; }

            [JsonProperty("/api/AD/UsuarioGrupo/BuscarGruposUsuario")]
            public ApiADUsuarioGrupoBuscarGruposUsuario apiADUsuarioGrupoBuscarGruposUsuario { get; set; }
        }

        public class Post
        {
            public List<string> tags { get; set; }
            public List<Parameter> parameters { get; set; }
            public Responses responses { get; set; }
            public RequestBody requestBody { get; set; }
        }

        public class RequestBody
        {
            public Content content { get; set; }
        }

        public class Responses
        {
            [JsonProperty("200")]
            public _200 _200 { get; set; }
        }

        public class Root
        {
            public string openapi { get; set; }
            public Info info { get; set; }
            public Paths paths { get; set; }
            public Components components { get; set; }
            public List<Security> security { get; set; }
        }

        public class Schema
        {
            public string type { get; set; }
            public Items items { get; set; }
        }

        public class Security
        {
            public List<object> Bearer { get; set; }
        }

        public class SecuritySchemes
        {
            public Bearer Bearer { get; set; }
        }

        public class TextJson
        {
            public Schema schema { get; set; }
        }

        public class TextPlain
        {
            public Schema schema { get; set; }
        }
    }
}
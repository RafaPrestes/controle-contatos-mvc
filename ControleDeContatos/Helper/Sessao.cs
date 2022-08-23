﻿using ControleDeContatos.Models;
using Newtonsoft.Json;

namespace ControleDeContatos.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public Sessao(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
    
        public UsuarioModel BuscarSessaoUsuario()
        {
            string sessaoUsuario = _contextAccessor.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) 
            {
                return null;
            }
            else
            {
                // convertendo novamente para um objeto
                return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
            }
        }

        public void CriarSessaoUsuario(UsuarioModel usuario)
        {
            // convertendo o usuario que é um objeto em uma string com o JsonConvert
            string valor = JsonConvert.SerializeObject(usuario);
            // criando uma sessão
            _contextAccessor.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoUsuario()
        {
            _contextAccessor.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteiraEletrica
{
    abstract class RecipienteDeContencao
    {
        private FonteDeAguaQuente _fonteDeAguaQuente;
        private InterfaceDoUsuario _interfaceDoUsuario;
        protected bool EstaFermentando;
        protected bool EstaTerminado;

        public RecipienteDeContencao()
        {
            EstaFermentando = false;
            EstaTerminado = true;
        }

        public void Iniciar(FonteDeAguaQuente _fonteDeAguaQuente, InterfaceDoUsuario _interfaceDoUsuario)
        {
            this._fonteDeAguaQuente = _fonteDeAguaQuente;
            this._interfaceDoUsuario = _interfaceDoUsuario;
        }

        internal void Comecar()
        {
            EstaFermentando = true;
            EstaTerminado = false;
        }

        internal void Terminado()
        {
            EstaFermentando = false;
        }

        protected void DeclareTerminado()
        {
            EstaTerminado = true;
            _interfaceDoUsuario.Terminado();
        }

        protected void RecipienteDisponivel()
        {
            _fonteDeAguaQuente.Retomar();
        }

        protected void RecipienteIndisponivel()
        {
            _fonteDeAguaQuente.Pausar();
        }

        protected internal abstract bool EstaPronto { get; }
    }
}

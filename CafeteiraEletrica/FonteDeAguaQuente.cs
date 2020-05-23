using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteiraEletrica
{
    abstract class FonteDeAguaQuente
    {
        private RecipienteDeContencao _recipienteDeContencao;
        private InterfaceDoUsuario _interfaceDoUsuario;
        protected bool EstaFermentando;
        protected internal abstract bool EstaPronto { get; }

        public abstract bool EstaTerminado(); 
        public abstract void ComecePreparar(); 
        public abstract void Pausar();
        public abstract void Retomar();

        public FonteDeAguaQuente()
        {
            EstaFermentando = false;
        }

        public void Iniciar(InterfaceDoUsuario _interfaceDoUsuario, RecipienteDeContencao _recipienteDeContencao)
        {
            this._interfaceDoUsuario = _interfaceDoUsuario;
            this._recipienteDeContencao = _recipienteDeContencao;
        }

        internal void Comecar()
        {
            EstaFermentando = true;
            ComecePreparar();
        }

        public void Terminado()
        {
            EstaFermentando = false;
        }

        public void DeclareTerminado()
        {
            _interfaceDoUsuario.Terminado();
            _recipienteDeContencao.Terminado();
            EstaFermentando = false;
        }
    }
}

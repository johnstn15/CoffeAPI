using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteiraEletrica
{
    public abstract class InterfaceDoUsuario
    {
        private FonteDeAguaQuente _fonteDeAguaQuente;
        private RecipienteDeContencao _recipienteDeContencao;
        protected bool EstaPronto;

        public abstract void Pronto(); 
        public abstract void CicloCompleto();

        public InterfaceDoUsuario()
        {
            EstaPronto = true;
        }

        void Iniciar(FonteDeAguaQuente _fonteDeAguaQuente, RecipienteDeContencao _recipienteDeContencao)
        {
            this._fonteDeAguaQuente = _fonteDeAguaQuente;
            this._recipienteDeContencao = _recipienteDeContencao;
        }

        public void Terminado()
        {
            EstaPronto = true;
            CicloCompleto();
        }

        public void ComecarPreparar()
        {
            if (_fonteDeAguaQuente.EstaPronto && _recipienteDeContencao.EstaPronto)
            {
                EstaPronto = false;
                _fonteDeAguaQuente.Comecar();
                _recipienteDeContencao.Comecar(); 
            }
        }
    }
}

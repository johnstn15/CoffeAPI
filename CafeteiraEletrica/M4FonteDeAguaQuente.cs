using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMakerApi;

namespace CafeteiraEletrica
{
    class M4FonteDeAguaQuente : FonteDeAguaQuente, IPrepararCafe
    {
        private ICoffeeMakerApi _api;

        protected internal override bool EstaPronto => throw new NotImplementedException();

        public M4FonteDeAguaQuente(ICoffeeMakerApi _api) 
        { 
            this._api = _api;
        }

        public override bool EstaTerminado()
        {
            BoilerStatus boilerStatus = _api.GetBoilerStatus(); 
            return boilerStatus == BoilerStatus.NOT_EMPTY;
        }

        public override void ComecePreparar()
        {
            _api.SetReliefValveState(ReliefValveState.CLOSED); 
            _api.SetBoilerState(BoilerState.ON);
        }

        public void Preparando()
        {
            BoilerStatus boilerStatus = _api.GetBoilerStatus();

            if (EstaFermentando) 
            { 
                if (boilerStatus == BoilerStatus.EMPTY) 
                { 
                    _api.SetBoilerState(BoilerState.OFF);
                    _api.SetReliefValveState(ReliefValveState.CLOSED); 
                    DeclareTerminado();
                } 
            }
        }

        public override void Pausar()
        {
            _api.SetBoilerState(BoilerState.OFF);
            _api.SetReliefValveState(ReliefValveState.OPEN);
        }

        public override void Retomar()
        {
            _api.SetBoilerState(BoilerState.ON); 
            _api.SetReliefValveState(ReliefValveState.CLOSED);
        }
    }
}

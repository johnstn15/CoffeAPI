using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMakerApi;

namespace CafeteiraEletrica
{
    class M4InterfaceDoUsuario : InterfaceDoUsuario, IPrepararCafe
    {
        private ICoffeeMakerApi _api;

        public M4InterfaceDoUsuario(ICoffeeMakerApi api)
        {
            this._api = api;
        }

        public void Preparando()
        {
            BrewButtonStatus status = _api.GetBrewButtonStatus();
            if (status == BrewButtonStatus.PUSHED)
            {
                ComecarPreparar();
            }
        }

        public override void CicloCompleto()
        {
            _api.SetIndicatorState(IndicatorState.ON);
        }

        public override void Pronto()
        {
            _api.SetIndicatorState(IndicatorState.OFF);
        }
    }
}

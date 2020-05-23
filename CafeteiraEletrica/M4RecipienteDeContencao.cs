using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMakerApi;

namespace CafeteiraEletrica
{
    class M4RecipienteDeContencao : RecipienteDeContencao, IPrepararCafe
    {
        private ICoffeeMakerApi _api;
        
        private WarmerPlateStatus lastPotStatus;

        public M4RecipienteDeContencao(ICoffeeMakerApi _api)
        {
            this._api = _api;
            lastPotStatus = WarmerPlateStatus.POT_EMPTY;
        }

        public void Preparando()
        {
            throw new NotImplementedException();
        }

        protected internal override bool EstaPronto => throw new NotImplementedException();
    }
}

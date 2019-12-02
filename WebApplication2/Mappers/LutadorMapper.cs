using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;
using WebApplication2.Utils.Response;

namespace WebApplication2.Mappers
{
    public class LutadorMapper : BaseMapper<Lutador, LutadorResponse>
    {
        public LutadorResponse entityToResponse(Lutador lutador)
        {
            LutadorResponse lutadorResponse = new LutadorResponse();
            var response = execER(lutador, lutadorResponse);

            return response;
        }

        public Lutador responseToEntity(LutadorResponse response)
        {
            Lutador lutador = new Lutador();
            var entity = execRE(lutador, response);

            return entity;
        }

    }
}
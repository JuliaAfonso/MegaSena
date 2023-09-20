using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MegaCenaController : Controller
    {
       [HttpPost("registrarJogo")]
       public ActionResult registrarJogo(NumeroMegaCena numeroMegaCena)
        {

            if(
               numeroMegaCena.num1 != numeroMegaCena.num2 &&
               numeroMegaCena.num1 != numeroMegaCena.num3  &&
               numeroMegaCena.num1 != numeroMegaCena.num4  &&
               numeroMegaCena.num1 != numeroMegaCena.num5  &&
               numeroMegaCena.num1 != numeroMegaCena.num6  &&
               numeroMegaCena.num2!= numeroMegaCena.num3   &&
               numeroMegaCena.num2!= numeroMegaCena.num4   &&
               numeroMegaCena.num2!= numeroMegaCena.num5   &&
               numeroMegaCena.num2!= numeroMegaCena.num6   &&
               numeroMegaCena.num3 != numeroMegaCena.num4  &&
               numeroMegaCena.num3 != numeroMegaCena.num5  &&
               numeroMegaCena.num3 != numeroMegaCena.num6  &&
               numeroMegaCena.num4 != numeroMegaCena.num5  &&
               numeroMegaCena.num4 != numeroMegaCena.num6  &&
               numeroMegaCena.num5 != numeroMegaCena.num6 
            )
            {
                return Ok("Jogo Registrado com sucesso! Seu jogo é : ");
            }

            return BadRequest("Jogo Inválido");

        }


        [HttpPost("registrarJogo2")]
        public ActionResult registrarJogo2(List<Exemplo2> exemplo2)
        {
            // 10 - 20 -30 -40 -50 -60
            if(exemplo2.Count() != 6)
            {
                return BadRequest("Jogo Inválido");
            }

            foreach (var item in exemplo2)
            {
                var resultado = exemplo2.Where(l => l.numeroJogo == item.numeroJogo);
                if (resultado.Count() > 1)
                    return BadRequest("Numero repetido!");
                if (item.numeroJogo < 1 || item.numeroJogo > 60)
                    return BadRequest("Numero invalido!");

            }

            return Ok("jOGO REGITRADO!");

        }

        [HttpPost("registrarJogo3")]
        public ActionResult registrarJogo3()
        {
            //enquanto nao sortiei 6 numeros repetir
            List<int> jogoAleaorio = new List<int>();
            int aux = 0;
            while (jogoAleaorio.Count() != 6)
            {

                 Random rnd = new Random();
                 aux = rnd.Next(1, 60);

                var resultado = jogoAleaorio.Where(l => l == aux);
                if (resultado.Count() == 0)
                {
                    jogoAleaorio.Add(aux);
                }
                //random
                //checar se ja foi soretedo, exise no array,

            }
            RetornoApi retornoApi = new RetornoApi();
            retornoApi.menssagem = "Jogo registrado com sucesso!";
            retornoApi.jogo = jogoAleaorio;

            return Ok(retornoApi);
        }


    }
}

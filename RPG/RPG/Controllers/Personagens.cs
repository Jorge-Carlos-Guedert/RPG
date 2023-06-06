using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPG.Models;
using System.Threading.Tasks;

namespace RPG.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonagensController : ControllerBase
    {
        private static List<Personagem> personagens = new List<Personagem>
        {
            new Personagem
            {
                Id = 1,
                Nome = "Harry",
                Sobrenome = "Potter",
                Fantasia = "Bruxo",
                Local = "Hogwarts"
            },
            new Personagem
            {
                Id = 2,
                Nome = "Bob",
                Sobrenome = "Esponja",
                Fantasia = "Esponja",
                Local = "Fenda do Bikini"
            },
             new Personagem
            {
                Id = 3,
                Nome = "Sr",
                Sobrenome = "Sirigueijo",
                Fantasia = "Siri",
                Local = "Fenda do Bikini"
            },
              new Personagem
            {
                Id = 4,
                Nome = "Alvo",
                Sobrenome = "Dumblamdor",
                Fantasia = "Mago",
                Local = "Terra Média"
            }


        };

        [HttpGet]
        public async Task <ActionResult<List<Personagem>>> TodosPersonagens()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(100));   
            return Ok(personagens);


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Personagem>>> UnicoPersonagem(int id)
        {
            var pesquisa = personagens.Find(x => x.Id == id);

            if (pesquisa is null)
            {
                await Task.Delay (TimeSpan.FromMilliseconds(100));
                return NotFound("Personagem não encontrado");
            }
            return Ok(pesquisa);
        }

        [HttpGet("local/{local}")]
        public async Task<ActionResult<List<Personagem>>> LocalPersonagem(string local)
        {
            var pesquisa = personagens.FindAll(x => x.Local == local);

            if (pesquisa is null)
            {
                await Task.Delay(TimeSpan.FromMilliseconds (100));
                return NotFound("Personagem não encontrado");
            }
            return Ok(pesquisa);
        }

        [HttpPost]
        public async Task<ActionResult<List<Personagem>>> AddPersonagem(Personagem novo)
        {
            //if (novo.Id == 0)
            //{

            //    novo.Id = personagens[personagens.Count - 1].Id + 1;

            //}

            if (novo.Id == 0)
            {
                novo.Id = novo.Id == 0 ? personagens[personagens.Count - 1].Id : novo.Id;

            }
                personagens.Add(novo);
            await Task.Delay(TimeSpan.FromMilliseconds(100));
            return Ok(personagens);
          
           
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Personagem>>> AlterarPersonagem(int id, Personagem editar)
        {
            var pesquisa = personagens.Find(x => x.Id == id);

            if (pesquisa is null)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(100));
                return NotFound("Personagem não existe");
            }


            pesquisa.Nome = editar.Nome == "" || editar.Nome == "string" ? pesquisa.Nome : editar.Nome;
            pesquisa.Sobrenome = editar.Sobrenome == "" || editar.Sobrenome == "string" ? pesquisa.Sobrenome : editar.Sobrenome;
            pesquisa.Fantasia = editar.Fantasia == "" || editar.Fantasia == "string" ? pesquisa.Fantasia : editar.Fantasia;
            pesquisa.Local = editar.Local == "" || editar.Local == "string" ? pesquisa.Local : editar.Local;

            return Ok(pesquisa);

        }
        [HttpDelete]
        public async Task<ActionResult<List<Personagem>>> DeletaPersonagem(int id, Personagem deletar)
        {
            var pesquisa = personagens.Find(x => x.Id == id);

            if (pesquisa is null)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(100));
                return NotFound("Personagem não exite");
            }

            personagens.Remove(pesquisa);
            return Ok(pesquisa);


        }
    }
}

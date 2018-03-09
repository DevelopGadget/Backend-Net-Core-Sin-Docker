using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.IRepositorio;
using Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class JugadoresController : Controller
    {
        private readonly IJugadores jugadores;
        public JugadoresController(IJugadores jugadores)
        {
            this.jugadores = jugadores;
        }
        // GET api/values
        [HttpGet]
        public Task<string> Get()
        {
            return this.GeJugadores();
        }
        private async Task<string> GeJugadores()
        {
            if(await jugadores.Get() == null){
                return "No hay documentos";
            }else{
                return JsonConvert.SerializeObject(await jugadores.Get());
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Task<string> Get(string id)
        {
            return this.GeJugadoresID(id);
        }
        private async Task<string> GeJugadoresID(string id)
        {
            if(id.Length < 24){
                return "Verifique el id";
            }
            if(await jugadores.Get(id) == null){
                return "No hay documentos";
            }
            return JsonConvert.SerializeObject(await jugadores.Get(id));
        }
        // POST api/values
        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync([FromBody]JugadoresModel value)
        {
            if(ModelState.IsValid){
                await jugadores.Add(value);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }else{
               return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<HttpResponseMessage> Put(string id, [FromBody] JugadoresModel value)
        {
            if (string.IsNullOrEmpty(id) || id.Length < 24)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }           
            if(await jugadores.Get(id) == null){
               return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            if(ModelState.IsValid){
               value.Id = id;
                var h = await jugadores.Update(id, value);
                if(h.MatchedCount > 0){
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }else{
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }else{
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> Delete(string id)
        {
            if (string.IsNullOrEmpty(id) || id.Length < 24)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            if(await jugadores.Get(id) == null){
               return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            var h =  await jugadores.Remove(id);
            if(h.DeletedCount > 0){
                return new HttpResponseMessage(HttpStatusCode.OK);
            }else{
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }    
       }
    }
}
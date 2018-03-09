using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
   public class JugadoresModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        public string sNombre { get; set; }
        [Required]
        public int sEdad { get; set; }
        [Required]
        public string sPosicion { get; set; }
        [Required]
        public EquipoModel sEquipo { get; set; }
        [Required]
        public string sNacionalidad { get; set; }
         [Required]
        public string uNacionalidad { get; set; }
        
        public JugadoresModel(string sNombre, int sEdad, string  sPosicion, EquipoModel sEquipo, string sNacionalidad, string uNacionalidad){

           this.sNombre = sNombre;
           this.sEdad = sEdad;
           this.sPosicion = sPosicion;
           this.sEquipo = sEquipo;                     
           this.sNacionalidad = sNacionalidad;
           this.uNacionalidad = uNacionalidad;
        }

        public JugadoresModel(){
            
        }
    }
}
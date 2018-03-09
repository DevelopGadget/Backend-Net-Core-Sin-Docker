using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
   public class EquipoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        public string sNombre { get; set; }
        [Required]
        public string sEstadio { get; set; }
        [Required]
        public string uEstadio { get; set; }
        [Required]
        public string uEscudo { get; set; }
        
        public EquipoModel(string sNombre, string sEstadio, 
                            string  uEstadio, string uEscudo){

           this.sNombre = sNombre;
           this.sEstadio = sEstadio;
           this.uEstadio = uEstadio;
           this.uEscudo = uEscudo;                     

        }

        public EquipoModel(){
            
        }
    }
}

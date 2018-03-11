using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Web.Models
{
   public class EquipoModel : IValidatableObject
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

           this.sNombre = sNombre.ToUpper();
           this.sEstadio = sEstadio.ToUpper();
           this.uEstadio = uEstadio;
           this.uEscudo = uEscudo;                     

        }
        public EquipoModel(){
            
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errores = new List<ValidationResult>();
            if(!ValUrl(uEscudo) || !ValUrl(uEstadio)){
                errores.Add(new ValidationResult("Urls No Validas"));
            }
            return errores;
        }

        private bool ValUrl(string url){
            HttpWebRequest wreq;
            HttpWebResponse wresp;
            wresp = null;
            try
            {
                wreq = (HttpWebRequest)HttpWebRequest.Create(url);
                wreq.AllowWriteStreamBuffering = true;
                wresp = (HttpWebResponse)wreq.GetResponse();
                if (wresp.GetResponseStream() != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                if (wresp != null)
                wresp.Close();
            }
        }
    }
}

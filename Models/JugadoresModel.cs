using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Web.Models
{
   public class JugadoresModel : IValidatableObject
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        public string sNombre { get; set; }
        [Required]
        public int iEdad { get; set; }
        [Required]
        public string sPosicion { get; set; }
        [Required]
        public EquipoModel sEquipo { get; set; }
        [Required]
        public string sNacionalidad { get; set; }
        [Required]
        public string uNacionalidad { get; set; }
        [Required]
        public string uJugador { get; set; }
        
        public JugadoresModel(string sNombre, int sEdad, string  sPosicion, EquipoModel sEquipo, string sNacionalidad, string uNacionalidad, string uJugador){

           this.sNombre = sNombre.ToUpper();
           this.sEdad = sEdad;
           this.sPosicion = sPosicion.ToUpper();
           this.sEquipo = sEquipo;                     
           this.sNacionalidad = sNacionalidad.ToUpper();
           this.uNacionalidad = uNacionalidad;
           this.uJugador = uJugador;
        }

        public JugadoresModel(){
            
        }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      var errores = new List<ValidationResult>();
      if(!ValUrl(uNacionalidad) || !ValUrl(uJugador)){
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
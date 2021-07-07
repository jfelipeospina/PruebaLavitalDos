using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoUsuario.Models
{
	public class UserModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Se requiere Usuario")]
		public string Usuario { get; set; }

		[Required(ErrorMessage = "La Contraseña es requerida")]
		[DataType(DataType.Password)]
		public string Contraseña { get; set; }

		public string Nombre { get; set; }

		public string Direccion { get; set; }

		public int IdRol { get; set; }

	}

	public class UserDetailsModel
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Digite Usuario")]
		public string Usuario { get; set; }

		[Required(ErrorMessage = "Digite Nombre")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "Digite Direccion")]
		public string Direccion { get; set; }

		[Required(ErrorMessage = "Digite IdRol")]
		public int IdRol { get; set; }

		public List<UserDetailsModel> ShowallUser { get; set; }

	}

}
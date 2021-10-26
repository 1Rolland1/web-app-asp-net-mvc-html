using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace web_app_asp_net_mvc_html.Models
{
	public enum Position
	{
		[Display(Name = "Профессор")]
		Professor = 1,

		[Display(Name = "Старший преподаватель")]
		SeniorLecturer = 2,

		[Display(Name = "Доцент")]
		AssistantProfessor = 3,
	}
}
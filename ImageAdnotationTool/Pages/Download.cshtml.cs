using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.Coco;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using ImageAnnotationToolDataAccessLibrary.JsonFiles;
using ImageAnnotationToolDataAccessLibrary.Services;

namespace ImageAnnotationTool.Pages
{
	public class DownloadModel : PageModel
	{
		private readonly IWebHostEnvironment _env;
		//private readonly Coco _cocoService;
		private readonly int _projectId;

		public DownloadModel(IWebHostEnvironment env, int projectId)
		{
			_env = env;
			//_cocoService = coco;
			_projectId = projectId;
		}
		public async Task<IActionResult> OnGetAsync()
		{
			//var projectServiceProvider = new ProjectServiceProvider();
			var coco = new Coco();
			var serialization = new JsonSerialization<Coco>();
			var jsonstr = serialization.Serialize(coco);
			byte[] byteArray = System.Text.ASCIIEncoding.ASCII.GetBytes(jsonstr);

			return File(byteArray, "application/force-download", "coco.json");
		}
	}
}
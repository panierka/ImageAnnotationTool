using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.Coco;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using ImageAnnotationToolDataAccessLibrary.JsonFiles;

namespace ImageAnnotationTool.Pages
{
	public class DownloadModel : PageModel
	{
		private readonly IWebHostEnvironment _env;
		private readonly Coco _cocoService;
		public DownloadModel(IWebHostEnvironment env, Coco coco)
		{
			_env = env;
			_cocoService = coco;
		}
		public async Task<IActionResult> OnGetAsync()
		{
			var serialization = new JsonSerialization<Coco>();
			var jsonstr = serialization.Serialize(_cocoService);
			byte[] byteArray = System.Text.ASCIIEncoding.ASCII.GetBytes(jsonstr);

			return File(byteArray, "application/force-download", "coco.json");
		}
	}
}
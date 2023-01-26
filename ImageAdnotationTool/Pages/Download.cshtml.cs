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
		private readonly IWebHostEnvironment env;
		private readonly IProjectServiceProvider projectServiceProvider;

		public DownloadModel(IWebHostEnvironment env, IProjectServiceProvider projectServiceProvider)
		{
			this.env = env;
			this.projectServiceProvider = projectServiceProvider;
		}
        
        public async Task<IActionResult> OnGetAsync(int? projectId)
		{
			if (projectId is not int id)
			{
				return new NotFoundResult();
			}
            
            var annotatedImages = await projectServiceProvider.GetAllAnnotatedImagesFromProject(id);
			var project = await projectServiceProvider.GetProjectById(id);

			if (project is null)
			{
				return new NotFoundResult();
			}

			var team = project.Team;

			var coco = CocoCreator.CreateCoco(team, annotatedImages);
			var serialization = new JsonSerialization<Coco>();
			var jsonstr = serialization.Serialize(coco);
			byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(jsonstr);

			var name = $"{project.Name}-COCO"; 

			return File(byteArray, "application/force-download", $"{name}.json");
		}
	}
}
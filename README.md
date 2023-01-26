# ImageAnnotationTool

*this project was created for a Software Engineering university course*

## The team
- [panierka](https://github.com/panierka) - a lot of backend with a bit of frontend, annotating tool, rendering, overall app architecture, database/ORM administration, object modelling, custom components creation, managing, front-back configuration, testing
- [joanbod](https://github.com/joanbod) - a lot of frontend, UI/UX design, stylesheets, basically all the forms and modals, front-back configuration
- [TR1PL3D0T](https://github.com/TR1PL3D0T) - CRUD backend services, unit testing, JSON serialization, EXIF extraction, COCO modelling, front-back configuration
- [TomaszBarnas](https://github.com/TomaszBarnas) - html/css help, logo and graphic elements, text content creation, testing

## The scope
The main functionality of the application is to provide:
- tools needed for online teamwork
  - user accounts
  - teams
  - projects (jobs linked by common theme and annotation classes) 
  - jobs (user to user tasks with given set of images to be annotated)
  - user roles in both teams and projects
- tools for user-friendly annotation
  - two types of shape creation: rectangular and free-form
  - 7 unique tools for vertex modifications
  - undo feature
  - storing the annotations inbetween user sessions
  - smart image/canvas scaling, that doesn't ruin the annotations
  - class frequency visualization
  - ability to export the data into COCO .json file

## The technology
- ASP.NET Core, Blazor
- Entity Framework Core (MS SQL Server)
- Bootstrap
- SCSS

# MessageApplication    
    
An application that posts messages from an console application to a web site.  
   
   
###Installation Instructions    
You will need to enable migration and update database schema:   
open: Nuget Package Console (Tools -> Nuget Package Manager -> Package Manager Console)    
in console, choose default project in drop down menu to be MessageApp.Domain     

write:    
Enable-Migrations -StartUpProjectName MessageApp.MVC    
write:    
update-database -StartUpProjectName MessageApp.MVC    
    
    

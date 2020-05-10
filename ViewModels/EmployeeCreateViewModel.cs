using Microsoft.AspNetCore.Http;

namespace FileUpload.ViewModels
{
    public class EmployeeCreateViewModel
    {
        public int Id {get;set;}

        public string Name {get;set;}

        public IFormFile Photo {get;set;}
    }
}
using System.Runtime.CompilerServices;

namespace Product.API.Extentions
{
    public static class ApplicationExtensions
    {
        public static void UseInfrastructure(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            //app.UseHttpsRedirection();  //for product

            app.UseAuthorization();
           

        }
       
    }
}

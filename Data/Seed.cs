using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ikigai.Data.Interface;
using Ikigai.Data.RepoUsuario;
using Ikigai.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ikigai.Data
{
    public class SeedDb
    {
        private IUserHelp _userHelp;
        private IkigaiDbContext _context;


        public SeedDb(IkigaiDbContext context, UserHelp userHelper)
                
        {
                _context = context;
                _userHelp = userHelper;
        }
         

        public async Task SeedAsync()
        {
                
                await CheckRoles();
                var manager = await CheckUserAsync( "joseedet@gmail.com", "604972505", "Admin");
                var customer = await CheckUserAsync("jschneiderligero@yahoo.es", "692464538", "Customer");
              
                InitialDatesCliente("X0999769J","Juan","De La Cosa","C/Montilla, 25 1º 4ª","Barcelona",,"08025","Barcelona","604972595","jeysoftware@yahoo.es");
                InitialDatesTipo("Extrangeria");
                InitialDatesDetalleCliente(1,1,1,"Reagrupación Familiar","llll");
                                     
                await CheckAgendasAsync();
        }
        private async InitialDatesDetalleCliente(clienteId,planinId,tipoId,descripcion,observaciones)
        {
            var detalleCliente=new DetalleCliente{
                clienteId=ClienteId,
                planinId=PlaninId,
                tipoId=TipoId,
                descripcion=Descripcion,
                observaciones=Observaciones
            };  
            awit _context.SaveChangesAsync(detalleCliente);

        }
        private async InitialDatesTipo(tipo)
        {
            var _tipo=new Tipo{
                Nombre=tipo;
            }
            await _context.SaveChangesAsync(_tipo);

        }
        private async Task CheckRoles()
        {
                await _userHelp.CheckRoleAsync("Admin");
                await _userHelp.CheckRoleAsync("Customer");
        }
        private async Task CheckAgendasAsync()
            {
                if (!_context.Planin.Any())
                {
                    var initialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
                    var finalDate = initialDate.AddYears(1);
                    while (initialDate < finalDate)
                    {
                        if (initialDate.DayOfWeek != DayOfWeek.Sunday)
                        {
                            var finalDate2 = initialDate.AddHours(10);
                            while (initialDate < finalDate2)
                            {
                                _context.Planin.Add(new Planin
                                {
                                    Date = initialDate,
                                    IsAvailable = true
                                });

                                initialDate = initialDate.AddMinutes(30);
                            }

                            initialDate = initialDate.AddHours(14);
                        }
                        else
                        {
                            initialDate = initialDate.AddDays(1);
                        }
                    }
                }

                await _context.SaveChangesAsync();
            }
        
        private async Task<IdentityUser> CheckUserAsync(
                string email,
                string phone,                
                string role)
        {
                var user = await _userHelp.GetUserByEmailAsync(email);
                if (user == null)
                {
                    user = new IdentityUser
                    {
                        
                        Email = email,
                        UserName = email,
                        PhoneNumber = phone
                        
                    };

                    await _userHelp.AddUserAsync(user, "123456");
                    await _userHelp.AddUserToRoleAsync(user, role);
                }

                return user;
        }
        private async InitialDatesCliente(dni,pasaporte,nombre,apellidos,direccion,poblacion
                                        ,codPostal,provincia,telefono,observaciones)
        {
            var client=new Cliente
            {
                Dni=dni,
                Pasaporte=pasaporte,
                Nombre=nombre,
                Apellidos=apellidos,
                Direccion=direccion,
                Poblacion=poblacion,
                codPostal=CodPostal,
                provincia=Provincia,
                telefono=Telefono,
                observaciones=Observaciones


            };
            await _context.SaveChangesAsync(client);

        }


    
    }
} 
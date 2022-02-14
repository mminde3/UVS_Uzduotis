using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UVS_Uzduotis.Models;

namespace UVS_Uzduotis.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            SaleCodeModel empty = new SaleCodeModel
            {
                CodeArray = new string[] { }
            };
            return View(empty);
        }

        public IActionResult Generate(SaleCodeModel CodeParameters)
        {
            SaleCodeModel output = new SaleCodeModel();

            // Creating object of random class
            Random rand = new Random();

            // Choosing the quantity of code and lenght
            int stringlen = Int32.Parse(CodeParameters.Lenght);
            int quantity = Int32.Parse(CodeParameters.Quantity);
            int number;
            string code;
            char letter;
            output.CodeArray = new string[quantity];

            for (int x = 0; x < quantity; x++)
            {
                code = "";
                for (int i = 0; i < stringlen; i++)
                {
                    // Random number for ASCII symbols 
                    number = rand.Next(48, 107);

                    if (number > 57 && number < 83)
                    {
                        number += 7;
                    }

                    if (number > 83)
                    {
                        number += 15;
                    }

                    letter = Convert.ToChar(number);
                    code += letter;
                }
                output.CodeArray[x] = code;
            }
            return View("Index", output);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

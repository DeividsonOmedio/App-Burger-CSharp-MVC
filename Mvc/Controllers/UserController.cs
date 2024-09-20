using Domain.Interfaces.InterfacesServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mvc.Areas.Identity.Data;
using Mvc.Models;

namespace Mvc.Controllers
{
    public class UserController(IClientService clientService, IAddressServices addressServices, UserManager<UserModel> userManager) : Controller
    {
        private readonly IClientService _clientService = clientService;
        private readonly IAddressServices _addressServices = addressServices;
        private readonly UserManager<UserModel> _userManager = userManager;

        // GET: UserController
        public async Task<ActionResult> Index()
        {
            Cadastre cadastre = new Cadastre();

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            var clientEmailClaim = User.Identities.FirstOrDefault().Claims.FirstOrDefault(x => x.Type.Contains("mail")).Value;
            var clientNameClaim = User.Identity.Name;

            cadastre.Email = clientEmailClaim;

            var nameResult = await _userManager.GetUserAsync(User);
            cadastre.Name = nameResult.Name;
            return View(cadastre);
        }

        // GET: UserController/Details/5
        public ActionResult Address(int id)
        {
            return View("Address");
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddNewCadastre(Cadastre cadastre)
        {
            
            Domain.Entities.Client client = new Domain.Entities.Client
            {
                Name = User.Identity.Name,
                Email = User.Identities.FirstOrDefault().Claims.FirstOrDefault(x => x.Type.Contains("mail")).Value,
                PhoneNumber = cadastre.PhoneNumber,
                DataBirth = cadastre.DataBirth,
                RegisteredIn = DateTime.Now
            };
            try
            {
                await _clientService.Add(client);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

            var clientDb = await _clientService.GetByEmail(client.Email);

            Domain.Entities.Address address = new Domain.Entities.Address
            {
                Street = cadastre.Street,
                Number = cadastre.Number,
                Referency = cadastre.Referency,
                City = cadastre.City,
                State = cadastre.State,
                ZipCode = cadastre.ZipCode,
                ClientId = clientDb.Id
            };

            try
            {
                await _addressServices.Add(address);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }


            try
            {
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

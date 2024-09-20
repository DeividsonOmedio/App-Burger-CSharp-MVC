using Domain.Entities;
using Domain.Interfaces.InterfacesServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mvc.Areas.Identity.Data;

namespace Mvc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly UserManager<UserModel> _userManager;
        private readonly IUserStore<UserModel> _userStore;
        private readonly IUserEmailStore<UserModel> _emailStore;

        public EmployeeController(IEmployeeService employeeService,
                                  UserManager<UserModel> userManager,
                                  IUserStore<UserModel> userStore)
        {
            _employeeService = employeeService;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = (IUserEmailStore<UserModel>)userStore;
        }

        // Listagem de funcionários
        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAll();

            // Converter a lista de Domain.Entities.Employee para uma lista de Models.Employee
            var employeeViewModels = employees.Select(employee => new Models.Employee
            {
                Id = employee.Id,
                Name = employee.Name,
                Function = (Models.Enums.EnumFunctionEmployee)employee.Function
            }).ToList();

            return View(employeeViewModels);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                // Criar um novo usuário no Identity
                var user = new UserModel
                {
                    UserName = employee.Email,
                    Email = employee.Email,
                    Name = employee.Name
                };

                await _userStore.SetUserNameAsync(user, employee.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, employee.Email, CancellationToken.None);

                var result = await _userManager.CreateAsync(user, employee.Password);

                if (result.Succeeded)
                {
                    // Após adicionar no Identity, adicionar o funcionário na tabela Employees
                    await _employeeService.Add(employee);

                    // Adicionar o funcionário no papel (role) específico
                    await _userManager.AddToRoleAsync(user, "Admin");

                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return RedirectToAction(nameof(Index));
        }

    // GET: Details
    public async Task<IActionResult> Details(int id)
        {
            var employee = await _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            Models.Employee employeeView = new Models.Employee
            {
                Id = employee.Id,
                Name = employee.Name,
                Function = (Models.Enums.EnumFunctionEmployee)employee.Function
            };
            return View(employeeView);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

                Domain.Entities.Employee employee1 = new Domain.Entities.Employee
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Password = employee.Password,
                    Function = (Domain.Entities.Enums.EnumFunctionEmployee)employee.Function
                };
                var result = await _employeeService.Update(employee1);
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Delete
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            Models.Employee employeeView = new Models.Employee
            {
                Id = employee.Id,
                Name = employee.Name,
                Function = (Models.Enums.EnumFunctionEmployee)employee.Function
            };
            return View(employeeView);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _employeeService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

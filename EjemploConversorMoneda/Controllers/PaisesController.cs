

namespace EjermploConversorMoneda.Controllers;

public class PaisesController : Controller {

    private readonly ApplicationDbContext _context;

    public PaisesController(ApplicationDbContext context) {
        _context = context;
    }

    // GET: Pais
    public async Task<IActionResult> Index() {
        return View(await _context.Paises.ToListAsync());
    }

    // GET: Pais/Details/5
    public async Task<IActionResult> Details(int? id) {
        if(id == null) {
            return NotFound();
        }

        var pais = await _context.Paises
            .FirstOrDefaultAsync(m => m.Id == id);
        if(pais == null) {
            return NotFound();
        }

        return View(pais);
    }

}

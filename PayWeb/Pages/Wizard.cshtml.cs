using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

public class WizardModel : PageModel
{
    [BindProperty]
    public int CurrentStep { get; set; } = 1;
    public string CurrentForm { get; set; } = string.Empty;
    public string ModalTitle { get; set; } = string.Empty;

    public void OnGet()
    {
        if (TempData.ContainsKey("CurrentStep"))
        {
            CurrentStep = (int)TempData["CurrentStep"];
        }

        // Leer de Session
        CurrentForm = HttpContext.Session.GetString("CurrentForm") ?? string.Empty;
        ModalTitle = HttpContext.Session.GetString("ModalTitle") ?? string.Empty;

        // Configurar ViewData/ViewBag para que esté disponible en la vista
        ViewData["CurrentForm"] = CurrentForm;
        ViewData["ModalTitle"] = ModalTitle;
    }

    public IActionResult OnPost(string direction)
    {
        if (direction == "next" && CurrentStep < 4)
        {
            CurrentStep++;
        }
        else if (direction == "previous" && CurrentStep > 1)
        {
            CurrentStep--;
        }
        else if (direction == "finish")
        {
            // Lógica para finalizar el wizard
            return RedirectToPage("Success");
        }

        TempData["CurrentStep"] = CurrentStep;
        return RedirectToPage();
    }
}
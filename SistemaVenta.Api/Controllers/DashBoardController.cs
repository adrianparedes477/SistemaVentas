using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVenta.Api.Utilidad;
using SistemaVenta.BLL.Servicios;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DTO;

namespace SistemaVenta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IDashBoardService _dashBoardServicio;

        public DashBoardController(IDashBoardService dashBoardServicio)
        {
            _dashBoardServicio = dashBoardServicio;
        }

        [HttpGet]
        [Route("Resumen")]
        public async Task<IActionResult> Resumen()
        {
            var rsp = new Response<DashBoardDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _dashBoardServicio.Resumen();
            }
            catch (Exception ex)
            {

                rsp.status = false;
                rsp.msg = ex.Message;
            }

            return Ok(rsp);
        }
    }
}
